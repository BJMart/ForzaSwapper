
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using ForzaSwapper.src;


namespace ForzaSwapper
{
    public partial class Form1 : Form
    {
        private string selectedEngineID = "";
        private string VehicleID;
        private string PathDB;
        private string PathCSV;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a Filer";
                ofd.Filter = "SLT Files (*.slt)|*.slt";
                ofd.DefaultExt = "slt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PathDB = ofd.FileName;
                    PopulateComboBox(new ComboBox[] { comboBox1}, "Data_Car", "MediaName");
                    PopulateComboBox(new ComboBox[] { comboBox2 }, "Data_Engine", "MediaName");
                }
            }
        }

        private void PopulateComboBox(ComboBox[] comboBoxes, string tableName, string columnName)
        {
            string connectionString = $@"Data Source={PathDB};Version=3;";

            try
            {
                using var connection = new SQLiteConnection(connectionString);
                connection.Open();
                EnsurePowertrainRecords(connection);

                using var command = new SQLiteCommand(connection);
                command.CommandText = $"SELECT * FROM List_UpgradeEngine";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (var cb in comboBoxes)
                {
                    if (tableName == "Data_Car")
                    {
                        command.CommandText = $"SELECT Id, {columnName} FROM {tableName} ORDER BY {columnName}";
                        var items = new List<MediaItem>();
                        using var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            items.Add(new MediaItem
                            {
                                Id = reader.GetInt32(0),
                                MediaName = reader.GetString(1)
                            });
                        }
                        cb.DataSource = items;
                        cb.DisplayMember = "MediaName";
                        cb.ValueMember = "Id";
                    }
                    else if (tableName == "Data_Engine")
                    {
                        command.CommandText = $"SELECT EngineID, {columnName} FROM {tableName} ORDER BY {columnName}";
                        var items = new List<MediaEngineItem>();
                        using var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            items.Add(new MediaEngineItem
                            {
                                EngineID = reader["EngineID"].ToString(),
                                MediaName = reader.GetString(1)
                            });
                        }
                        cb.DataSource = items;
                        cb.DisplayMember = "MediaName";
                        cb.ValueMember = "EngineID";
                    }
                }

                dgvSwaps.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {columnName} from {tableName}: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int selectedId)
            {
                LoadFilteredSwaps(selectedId);
                VehicleID = selectedId.ToString();
                UpdateCurrentEngineList();
                PopulateDrivetrainComboBox(Convert.ToInt32(VehicleID));

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is MediaEngineItem engine)
            {
                selectedEngineID = engine.EngineID;

            }
        }


        private void PopulateDrivetrainComboBox(int vehicleId)
        {
            using var connection = new SQLiteConnection($"Data Source={PathDB};Version=3;");
            connection.Open();

            var drivetrainMap = new Dictionary<int, string>
    {
        { 1, "FWD" },
        { 2, "RWD" },
        { 3, "AWD" }
    };

            var drivetrains = new HashSet<string>();

            using (var cmd = new SQLiteCommand(@"
        SELECT DISTINCT p.DrivetrainId
        FROM List_UpgradeDrivetrain lud
        JOIN Powertrains p ON lud.PowertrainId = p.Id
        WHERE lud.Ordinal = @VehicleId", connection))
            {
                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int drivetrainId = reader.GetInt32(0);
                        if (drivetrainMap.TryGetValue(drivetrainId, out string name))
                        {
                            drivetrains.Add(name);
                        }
                    }
                }
            }

            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(drivetrains.ToArray());
            comboBox4.Items.Add("Add new drivetrain");
        }




        private void LoadFilteredSwaps(int carId)
        {
            string query = "SELECT * FROM List_UpgradeEngine WHERE Ordinal = @carId";
            try
            {
                using var connection = new SQLiteConnection($@"Data Source={PathDB};Version=3;");
                using var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@carId", carId);
                var adapter = new SQLiteDataAdapter(command);
                var filteredTable = new DataTable();
                adapter.Fill(filteredTable);
                dgvSwaps.DataSource = filteredTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering swaps: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedEngineID) || string.IsNullOrEmpty(VehicleID))
            {
                MessageBox.Show($"Please select both a car and an engine.\nVehicleID: {VehicleID}\nEngineID: {selectedEngineID}");
                return;
            }

            try
            {
                using var connection = new SQLiteConnection($@"Data Source={PathDB};Version=3;");
                connection.Open();

                // Get previous row
                string getLastRowQuery = "SELECT Level, ManufacturerID FROM List_UpgradeEngine WHERE Ordinal = @vehicleID ORDER BY rowid DESC LIMIT 1";
                var getLastCmd = new SQLiteCommand(getLastRowQuery, connection);
                getLastCmd.Parameters.AddWithValue("@vehicleID", VehicleID);
                object levelResult = null, manufacturerResult = null;

                using (var reader = getLastCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        levelResult = reader["Level"];
                        manufacturerResult = reader["ManufacturerID"];
                    }
                }

                int nextLevel = (levelResult != null && int.TryParse(levelResult.ToString(), out int lastLevel)) ? lastLevel + 1 : 1;
                string formattedLevel = nextLevel.ToString("D3");
                string generatedId = VehicleID + formattedLevel;
                string manufacturerID = manufacturerResult?.ToString() ?? "";

                // Get mass info
                double selectedMass = GetEngineMass(connection, selectedEngineID);
                string stockEngineID = GetStockEngineID(connection, VehicleID);
                double stockMass = GetEngineMass(connection, stockEngineID);
                double massDiff = selectedMass - stockMass;

                // WeightDistDiff calculation
                double weightDistDiff = CalculateWeightDistDiff(connection, VehicleID, massDiff);

                // Price = 20% of base cost
                double price = GetEngineSwapPrice(connection, selectedEngineID);

                // Insert record
                string insertQuery = @"
INSERT INTO List_UpgradeEngine 
(Id, Ordinal, EngineID, Level, IsStock, ManufacturerID, Price, MassDiff, WeightDistDiff, DragScale, WindInstabilityScale) 
VALUES 
(@id, @vehicleID, @engineId, @level, 0, @manufacturerID, @price, @massDiff, @weightDistDiff, 1, 1)";

                using var insertCmd = new SQLiteCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@id", generatedId);
                insertCmd.Parameters.AddWithValue("@vehicleID", VehicleID);
                insertCmd.Parameters.AddWithValue("@engineId", selectedEngineID);
                insertCmd.Parameters.AddWithValue("@level", formattedLevel);
                insertCmd.Parameters.AddWithValue("@manufacturerID", manufacturerID);
                insertCmd.Parameters.AddWithValue("@price", price);
                insertCmd.Parameters.AddWithValue("@massDiff", massDiff);
                insertCmd.Parameters.AddWithValue("@weightDistDiff", weightDistDiff);

                if (insertCmd.ExecuteNonQuery() > 0)
                    MessageBox.Show($"Record added:\nId: {generatedId}\nEngineID: {selectedEngineID}\nMassDiff: {massDiff}\nWeightDistDiff: {weightDistDiff}\nPrice: {price}");
                else
                    MessageBox.Show("Insert failed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record: " + ex.Message);
            }
        }

        private double GetEngineMass(SQLiteConnection conn, string engineID)
        {
            if (string.IsNullOrEmpty(engineID)) return 0;
            var cmd = new SQLiteCommand("SELECT [EngineMass-kg] FROM Data_Engine WHERE EngineID = @engineID", conn);
            cmd.Parameters.AddWithValue("@engineID", engineID);
            var result = cmd.ExecuteScalar();
            return result != null && double.TryParse(result.ToString(), out double mass) ? mass : 0;
        }

        private string GetStockEngineID(SQLiteConnection conn, string vehicleID)
        {
            var cmd = new SQLiteCommand("SELECT EngineID FROM List_UpgradeEngine WHERE Ordinal = @vehicleID AND IsStock = 1 LIMIT 1", conn);
            cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
            return cmd.ExecuteScalar()?.ToString() ?? "";
        }

        private double CalculateWeightDistDiff(SQLiteConnection conn, string vehicleID, double massDiff)
        {
            var cmd = new SQLiteCommand("SELECT MassDiff, WeightDistDiff FROM List_UpgradeEngine WHERE Ordinal = @vehicleID ORDER BY rowid DESC LIMIT 1", conn);
            cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (double.TryParse(reader["MassDiff"].ToString(), out double prevMassDiff) &&
                    double.TryParse(reader["WeightDistDiff"].ToString(), out double prevDist) &&
                    prevMassDiff != 0)
                {
                    return (prevDist / prevMassDiff) * massDiff;
                }
            }
            return 0;
        }

        private double GetEngineSwapPrice(SQLiteConnection conn, string engineID)
        {
            string stockVehicleID = "";
            var stockCmd = new SQLiteCommand("SELECT Ordinal FROM List_UpgradeEngine WHERE EngineID = @engineId AND IsStock = 1 LIMIT 1", conn);
            stockCmd.Parameters.AddWithValue("@engineId", engineID);
            var result = stockCmd.ExecuteScalar();
            if (result != null)
                stockVehicleID = result.ToString();

            if (!string.IsNullOrEmpty(stockVehicleID))
            {
                var costCmd = new SQLiteCommand("SELECT BaseCost FROM Data_Car WHERE Id = @carId", conn);
                costCmd.Parameters.AddWithValue("@carId", stockVehicleID);
                var costResult = costCmd.ExecuteScalar();
                if (costResult != null && double.TryParse(costResult.ToString(), out double baseCost))
                    return baseCost * 0.2;
            }

            return 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCurrentEngineList()
        {
            listBox1.Items.Clear();

            // Query to get all EngineIDs under the selected Ordinal
            string query = @"
        SELECT EngineID 
        FROM List_UpgradeEngine 
        WHERE Ordinal = @selectedOrdinal";

            string connectionString = $@"Data Source={PathDB};Version=3;";
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                using (var command = new SQLiteCommand(query, connection))
                {
                    // Use VehicleID (selected car) to filter by Ordinal
                    command.Parameters.AddWithValue("@selectedOrdinal", VehicleID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string engineId = reader["EngineID"].ToString();

                            // Query to get both MediaName (car name) and EngineName using the EngineID from Data_Engine
                            string carNameQuery = "SELECT MediaName, EngineName FROM Data_Engine WHERE EngineID = @engineID";
                            using (var carCommand = new SQLiteCommand(carNameQuery, connection))
                            {
                                carCommand.Parameters.AddWithValue("@engineID", engineId);

                                // Execute the query to get both car name and engine name
                                using (var carReader = carCommand.ExecuteReader())
                                {
                                    if (carReader.Read())
                                    {
                                        string carName = carReader["MediaName"].ToString();
                                        string engineName = carReader["EngineName"].ToString();

                                        // Format as carname(engineName) and add to listBox
                                        listBox1.Items.Add($"{carName}({engineName})");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching car names with engine names: " + ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EnsurePowertrainRecords(SQLiteConnection connection)
        {
            // Check if the Powertrains table exists before doing anything
            using (var checkTableCmd = new SQLiteCommand(@"
        SELECT name 
        FROM sqlite_master 
        WHERE type='table' AND name='Powertrains';", connection))
            {
                var tableExists = checkTableCmd.ExecuteScalar();
                if (tableExists == null)
                {
                    // Table doesn't exist; skip insertion
                    return;
                }
            }

            var baseIconPath = @"GAME:\Media\UI\Textures\Data_Bound\Drivetrain_Icons\Drivetrain_FWD_Front.swatchbin";

            // First Record
            InsertPowertrainIfNotExists(connection, 8, 1, 3, baseIconPath, baseIconPath);

            // Second Record (ID + 1, EnginePlacementID + 1)
            InsertPowertrainIfNotExists(connection, 9, 1, 2, baseIconPath, baseIconPath); // Fixed EnginePlacementId to +1 (was 2, should be 4)
        }

        private void InsertPowertrainIfNotExists(SQLiteConnection connection, int id, int drivetrainId, int enginePlacementId, string iconPath, string smallIconPath)
        {
            using (var checkCmd = new SQLiteCommand("SELECT COUNT(1) FROM Powertrains WHERE Id = @Id", connection))
            {
                checkCmd.Parameters.AddWithValue("@Id", id);

                long exists = (long)checkCmd.ExecuteScalar();

                if (exists == 0)
                {
                    using (var insertCmd = new SQLiteCommand(@"
                INSERT INTO Powertrains (Id, DrivetrainId, EnginePlacementId, IconPath, SmallIconPath)
                VALUES (@Id, @DrivetrainId, @EnginePlacementId, @IconPath, @SmallIconPath)", connection))
                    {
                        insertCmd.Parameters.AddWithValue("@Id", id);
                        insertCmd.Parameters.AddWithValue("@DrivetrainId", drivetrainId);
                        insertCmd.Parameters.AddWithValue("@EnginePlacementId", enginePlacementId);
                        insertCmd.Parameters.AddWithValue("@IconPath", iconPath);
                        insertCmd.Parameters.AddWithValue("@SmallIconPath", smallIconPath);

                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Select a Filer";
                    ofd.Filter = "CSV Files (*.csv)|*.csv";
                    ofd.DefaultExt = "csv";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        PathCSV = ofd.FileName;
                        PopulateComboBox(new ComboBox[] { comboBox1 }, "Data_Car", "MediaName");
                        PopulateComboBox(new ComboBox[] { comboBox2 }, "Data_Engine", "MediaName");
                    }
                }
                ImportEngineNamesFromCsv(PathCSV);
            }
            catch (Exception ex)
            {

            }


        }

        private void ImportEngineNamesFromCsv(string csvFilePath)
        {
            using (var connection = new SQLiteConnection("Data Source=" + PathDB))
            {
                connection.Open();

                var lines = File.ReadAllLines(csvFilePath);

                // Skip header
                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');

                    if (parts.Length < 2) continue;

                    string carDBName = parts[0].Trim();
                    string engineName = parts[1].Trim();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                    UPDATE Data_Engine
                    SET EngineName = @EngineName
                    WHERE MediaName = @CarDBName;
                ";
                        command.Parameters.AddWithValue("@EngineName", engineName);
                        command.Parameters.AddWithValue("@CarDBName", carDBName);
                        command.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Engine names imported successfully from CSV.");
        }
        /*
        public class MediaItem
        {
            public int Id { get; set; }
            public string MediaName { get; set; }
            public override string ToString() => MediaName;
        }
        
        public class MediaEngineItem
        {
            public string EngineID { get; set; }
            public string MediaName { get; set; }
            public override string ToString() => MediaName;
        }
        
        public class EngineMapping
        {
            public string CarDBName { get; set; } = "";
            public string EngineName { get; set; } = "";
        }
        */
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "RWD")
            {

            }
        }
    }
}
