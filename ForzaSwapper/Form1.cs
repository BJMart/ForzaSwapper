
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using ForzaSwapper.src;
using Microsoft.Data.Sqlite;
using System.Windows.Forms.DataVisualization.Charting;


namespace ForzaSwapper
{
    public partial class Form1 : Form
    {
        private string selectedEngineID = "";
        private string VehicleID;
        private string PathDB;
        private string PathCSV;
        private string PathExportDB;
        private int SelectedDriveType;
        public Form1()
        {
            InitializeComponent();
        }
        //Hey B if your reading this your trying to figure out how to add a new element to any of the side bars
        //Simply add a new TableLayoutPanel in the bottom area of the left side bar
        //From there simply set it's docking to fill and then remove a column and add as many rows as you need
        //Think of the tableLayoutPanel as a box and you put more boxes in for each item you have!
        //If you need anything please message me and i'll do my best to explain
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
                    PopulateComboBox(new ComboBox[] { CarSelectorComboBox }, "Data_Car", "MediaName");
                    PopulateComboBox(new ComboBox[] { comboBox2 }, "Data_Engine", "MediaName");
                    PopulateComboBox(new ComboBox[] { comboBoxEngineManager }, "Data_Engine", "MediaName");

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
            if (CarSelectorComboBox.SelectedValue is int selectedId)
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
            CarEngineListBox.Items.Clear();

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
                                        CarEngineListBox.Items.Add($"{carName}({engineName})");
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
                        PopulateComboBox(new ComboBox[] { CarSelectorComboBox }, "Data_Car", "MediaName");
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
                radioButton3.Checked = true;
                SelectedDriveType = 2;
            }
            if (comboBox4.Text == "AWD")
            {
                radioButton4.Checked = true;
                SelectedDriveType = 3;
            }
            if (comboBox4.Text == "FWD")
            {
                radioButton5.Checked = true;
                SelectedDriveType = 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(VehicleID))
            {
                MessageBox.Show("Please select a car first.");
                return;
            }

            try
            {
                using var connection = new SQLiteConnection($@"Data Source={PathDB};Version=3;");
                connection.Open();

                var levelCompoundMap = new Dictionary<int, int>
        {
            { 1, 6 },
            { 2, 9 },
            { 3, 11 },
            { 9, 14 },
            { 4, 11 },
            { 11, 12 },
            { 5, 51 }
        };

                int insertedCount = 0;

                foreach (var pair in levelCompoundMap)
                {
                    int level = pair.Key;
                    int compoundId = pair.Value;
                    string formattedLevel = level.ToString("D3");
                    string generatedId = VehicleID + formattedLevel;

                    // Check if this level already exists for the vehicle
                    using var checkCmd = new SQLiteCommand("SELECT COUNT(1) FROM List_UpgradeTireCompound WHERE Ordinal = @vehicleID AND Level = @level", connection);
                    checkCmd.Parameters.AddWithValue("@vehicleID", VehicleID);
                    checkCmd.Parameters.AddWithValue("@level", formattedLevel);

                    long exists = (long)checkCmd.ExecuteScalar();
                    if (exists > 0)
                        continue; // Skip this level if already present

                    // Insert the new record
                    string insertQuery = @"
                INSERT INTO List_UpgradeTireCompound 
                (Id, Ordinal, TireCompoundID, Level, ManufacturerID, Price, MassDiff, DragScale, WindInstabilityScale, RequiresGraphics, TireModelName, WetTireModelName, SnowTireModelName, IsStock) 
                VALUES 
                (@id, @vehicleID, @tireCompoundId, @level, 0, 1, 0.0, 1.0, 1.0, 0, 'WET_b', 'WET_b', 'WET_b', 0)";

                    using var insertCmd = new SQLiteCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@id", generatedId);
                    insertCmd.Parameters.AddWithValue("@vehicleID", VehicleID);
                    insertCmd.Parameters.AddWithValue("@tireCompoundId", compoundId);
                    insertCmd.Parameters.AddWithValue("@level", formattedLevel);

                    insertCmd.ExecuteNonQuery();
                    insertedCount++;
                }

                MessageBox.Show($"Inserted {insertedCount} new TireCompound record(s) for VehicleID: {VehicleID}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void comboBoxEngineManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePowerForSelectedEngine();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a Filer";
                ofd.Filter = "SLT Files (*.slt)|*.slt";
                ofd.DefaultExt = "slt";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string PathExportDB = ofd.FileName;

                    string selectedMediaName = comboBoxEngineManager.SelectedItem?.ToString();
                    if (string.IsNullOrEmpty(selectedMediaName))
                    {
                        MessageBox.Show("Please select an engine from the dropdown.");
                        return;
                    }

                    string sourceDbPath = PathDB;

                    using (var sourceConn = new SQLiteConnection($"Data Source={sourceDbPath};Version=3;"))
                    using (var destConn = new SQLiteConnection($"Data Source={PathExportDB};Version=3;"))
                    {
                        sourceConn.Open();
                        destConn.Open();

                        string selectQuery = "SELECT * FROM Data_Engine WHERE MediaName = @MediaName";
                        using (var selectCmd = new SQLiteCommand(selectQuery, sourceConn))
                        {
                            selectCmd.Parameters.AddWithValue("@MediaName", selectedMediaName);

                            using (var reader = selectCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int engineId = Convert.ToInt32(reader["EngineID"]);

                                    string checkQuery = "SELECT COUNT(*) FROM Data_Engine WHERE EngineID = @EngineID";
                                    using (var checkCmd = new SQLiteCommand(checkQuery, destConn))
                                    {
                                        checkCmd.Parameters.AddWithValue("@EngineID", engineId);
                                        long exists = (long)checkCmd.ExecuteScalar();

                                        if (exists > 0)
                                        {
                                            MessageBox.Show("This engine already exists in the selected database.");
                                            return;
                                        }
                                    }

                                    InsertEngineIntoDestination(destConn, reader);

                                    MessageBox.Show("Engine copied successfully.");

                                    // Copy related List_TorqueCurve rows
                                    long startId = engineId * 1000;
                                    long endId = startId + 999;

                                    CopyTorqueCurves(sourceConn, destConn, startId, endId);

                                    // Copy all upgrade tables
                                    string[] upgradeTables = new string[]
                                    {
                                "List_UpgradeEngineCSC",
                                "List_UpgradeEngineCamshaft",
                                "List_UpgradeEngineDSC",
                                "List_UpgradeEngineDisplacement",
                                "List_UpgradeEngineExhaust",
                                "List_UpgradeEngineFlywheel",
                                "List_UpgradeEngineFuelSystem",
                                "List_UpgradeEngineIgnition",
                                "List_UpgradeEngineIntake",
                                "List_UpgradeEngineIntercooler",
                                "List_UpgradeEngineManifold",
                                "List_UpgradeEngineOilCooling",
                                "List_UpgradeEnginePistonsCompression",
                                "List_UpgradeEngineRestrictorPlate",
                                "List_UpgradeEngineTurboQuad",
                                "List_UpgradeEngineTurboSingle",
                                "List_UpgradeEngineTurboTwin",
                                "List_UpgradeEngineValves"
                                    };

                                    foreach (var table in upgradeTables)
                                    {
                                        CopyUpgradeTable(sourceConn, destConn, table, engineId);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Engine not found in the source database.");
                                }
                            }
                        }
                    }
                }
            }
        }

        private HashSet<string> GetTableColumns(SQLiteConnection conn, string tableName)
        {
            var columns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string pragmaQuery = $"PRAGMA table_info([{tableName}])";
            using (var cmd = new SQLiteCommand(pragmaQuery, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader["name"].ToString();
                        columns.Add(columnName);
                    }
                }
            }
            return columns;
        }

        private string SanitizeParamName(string columnName)
        {
            // Replace anything that's not a letter, digit or underscore with underscore
            return "@" + System.Text.RegularExpressions.Regex.Replace(columnName, @"[^a-zA-Z0-9_]", "_");
        }

        private void InsertEngineIntoDestination(SQLiteConnection destConn, SQLiteDataReader engine)
        {
            var destColumns = GetTableColumns(destConn, "Data_Engine");

            var insertColumns = new List<string>();
            var insertParams = new List<string>();
            var insertCmd = new SQLiteCommand(destConn);

            // Get available source column names
            var sourceColumns = new HashSet<string>();
            for (int i = 0; i < engine.FieldCount; i++)
            {
                sourceColumns.Add(engine.GetName(i));
            }

            foreach (var colName in destColumns)
            {
                if (sourceColumns.Contains(colName))
                {
                    insertColumns.Add($"[{colName}]");

                    string paramName = SanitizeParamName(colName);
                    insertParams.Add(paramName);

                    var value = engine.GetValue(engine.GetOrdinal(colName));
                    insertCmd.Parameters.AddWithValue(paramName, value ?? DBNull.Value);
                }
            }

            if (insertColumns.Count == 0)
            {
                MessageBox.Show("No matching columns found between source and destination.");
                return;
            }

            insertCmd.CommandText = $"INSERT INTO Data_Engine ({string.Join(",", insertColumns)}) VALUES ({string.Join(",", insertParams)});";

            try
            {
                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Insert failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CopyTorqueCurves(SQLiteConnection sourceConn, SQLiteConnection destConn, long startId, long endId)
        {
            string torqueQuery = "SELECT * FROM List_TorqueCurve WHERE TorqueCurveID BETWEEN @StartID AND @EndID";
            using (var torqueSelectCmd = new SQLiteCommand(torqueQuery, sourceConn))
            {
                torqueSelectCmd.Parameters.AddWithValue("@StartID", startId);
                torqueSelectCmd.Parameters.AddWithValue("@EndID", endId);

                using (var torqueReader = torqueSelectCmd.ExecuteReader())
                {
                    int copied = 0;

                    var destColumns = GetTableColumns(destConn, "List_TorqueCurve");

                    while (torqueReader.Read())
                    {
                        long torqueCurveID = (long)torqueReader["TorqueCurveID"];

                        string checkTorqueQuery = "SELECT COUNT(*) FROM List_TorqueCurve WHERE TorqueCurveID = @TorqueCurveID";
                        using (var checkCmd = new SQLiteCommand(checkTorqueQuery, destConn))
                        {
                            checkCmd.Parameters.AddWithValue("@TorqueCurveID", torqueCurveID);
                            long exists = (long)checkCmd.ExecuteScalar();

                            if (exists > 0)
                                continue;
                        }

                        var columnNames = new List<string>();
                        var parameterNames = new List<string>();
                        var insertTorqueCmd = new SQLiteCommand(destConn);

                        for (int i = 0; i < torqueReader.FieldCount; i++)
                        {
                            string col = torqueReader.GetName(i);
                            if (!destColumns.Contains(col))
                                continue;

                            columnNames.Add($"[{col}]");
                            parameterNames.Add($"@{col}");
                            insertTorqueCmd.Parameters.AddWithValue($"@{col}", torqueReader[col] ?? DBNull.Value);
                        }

                        insertTorqueCmd.CommandText = $"INSERT INTO List_TorqueCurve ({string.Join(",", columnNames)}) VALUES ({string.Join(",", parameterNames)})";
                        insertTorqueCmd.ExecuteNonQuery();
                        copied++;
                    }

                    MessageBox.Show($"Copied {copied} torque curve(s) to destination.");
                }
            }
        }

        private void CopyUpgradeTable(SQLiteConnection sourceConn, SQLiteConnection destConn, string tableName, int engineId)
        {
            string selectQuery = $"SELECT * FROM {tableName} WHERE EngineID = @EngineID";
            using (var selectCmd = new SQLiteCommand(selectQuery, sourceConn))
            {
                selectCmd.Parameters.AddWithValue("@EngineID", engineId);
                using (var reader = selectCmd.ExecuteReader())
                {
                    var destColumns = GetTableColumns(destConn, tableName);
                    int copied = 0;

                    while (reader.Read())
                    {
                        long id = (long)reader["Id"];

                        string checkQuery = $"SELECT COUNT(*) FROM {tableName} WHERE Id = @Id";
                        using (var checkCmd = new SQLiteCommand(checkQuery, destConn))
                        {
                            checkCmd.Parameters.AddWithValue("@Id", id);
                            long exists = (long)checkCmd.ExecuteScalar();
                            if (exists > 0)
                                continue;
                        }

                        var insertColumns = new List<string>();
                        var paramNames = new List<string>();
                        var insertCmd = new SQLiteCommand(destConn);

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string col = reader.GetName(i);
                            if (!destColumns.Contains(col))
                                continue;

                            insertColumns.Add($"[{col}]");
                            string paramName = $"@{col}";
                            paramNames.Add(paramName);
                            insertCmd.Parameters.AddWithValue(paramName, reader[col] ?? DBNull.Value);
                        }

                        insertCmd.CommandText = $"INSERT INTO {tableName} ({string.Join(",", insertColumns)}) VALUES ({string.Join(",", paramNames)})";
                        insertCmd.ExecuteNonQuery();
                        copied++;
                    }

                    if (copied > 0)
                        MessageBox.Show($"Copied {copied} rows from {tableName}.");
                }
            }
        }

        private void buttonDuplicateEngine_Click(object sender, EventArgs e)
        {
            if (comboBoxEngineManager.SelectedItem == null)
            {
                MessageBox.Show("Please select an engine first.");
                return;
            }

            int originalEngineId = Convert.ToInt32(comboBoxEngineManager.SelectedValue);

            using (var conn = new SQLiteConnection($"Data Source={PathDB};"))

            {
                conn.Open();

                // Step 1: Get the engine row
                SQLiteCommand getEngineCmd = new SQLiteCommand("SELECT * FROM Data_Engine WHERE EngineID = @EngineID", conn);
                getEngineCmd.Parameters.AddWithValue("@EngineID", originalEngineId);
                var reader = getEngineCmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Engine not found.");
                    return;
                }

                // Step 2: Prompt for MediaName
                string newMediaName = Microsoft.VisualBasic.Interaction.InputBox("Enter a new MediaName for the duplicated engine:", "New MediaName", reader["MediaName"].ToString());
                if (string.IsNullOrWhiteSpace(newMediaName))
                {
                    MessageBox.Show("MediaName is required.");
                    return;
                }

                // Step 3: Get next available EngineID
                int newEngineId = 100000;
                using (var getMaxCmd = new SQLiteCommand("SELECT MAX(EngineID) FROM Data_Engine", conn))
                {
                    var result = getMaxCmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        newEngineId = Convert.ToInt32(result) + 1;
                }

                // Step 4: Insert new engine
                var destColumns = new HashSet<string>();
                using (var pragmaCmd = new SQLiteCommand("PRAGMA table_info(Data_Engine)", conn))
                using (var pragmaReader = pragmaCmd.ExecuteReader())
                {
                    while (pragmaReader.Read())
                        destColumns.Add(pragmaReader["name"].ToString());
                }

                var insertCols = new List<string>();
                var insertVals = new List<string>();
                var insertCmd = new SQLiteCommand(conn);

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string col = reader.GetName(i);
                    if (!destColumns.Contains(col)) continue;

                    object val = reader[col];
                    if (col == "EngineID")
                        val = newEngineId;
                    if (col == "MediaName")
                        val = newMediaName;

                    string safeParam = col.Replace("-", "_");
                    insertCols.Add($"[{col}]");
                    insertVals.Add($"@{safeParam}");
                    insertCmd.Parameters.AddWithValue($"@{safeParam}", val ?? DBNull.Value);
                }

                insertCmd.CommandText = $"INSERT INTO Data_Engine ({string.Join(",", insertCols)}) VALUES ({string.Join(",", insertVals)})";
                insertCmd.ExecuteNonQuery();

                // Step 5: Copy TorqueCurves
                long newBaseTorqueId = newEngineId * 1000;
                long oldBaseTorqueId = originalEngineId * 1000;

                SQLiteCommand torqueSelect = new SQLiteCommand("SELECT * FROM List_TorqueCurve WHERE TorqueCurveID BETWEEN @Start AND @End", conn);
                torqueSelect.Parameters.AddWithValue("@Start", oldBaseTorqueId);
                torqueSelect.Parameters.AddWithValue("@End", oldBaseTorqueId + 999);
                using (var torqueReader = torqueSelect.ExecuteReader())
                {
                    var torqueCols = new HashSet<string>();
                    using (var pragma = new SQLiteCommand("PRAGMA table_info(List_TorqueCurve)", conn))
                    using (var pReader = pragma.ExecuteReader())
                        while (pReader.Read())
                            torqueCols.Add(pReader["name"].ToString());

                    while (torqueReader.Read())
                    {
                        long oldId = (long)torqueReader["TorqueCurveID"];
                        long newId = oldId - oldBaseTorqueId + newBaseTorqueId;

                        var colNames = new List<string>();
                        var valNames = new List<string>();
                        var insertTorque = new SQLiteCommand(conn);

                        for (int i = 0; i < torqueReader.FieldCount; i++)
                        {
                            string col = torqueReader.GetName(i);
                            if (!torqueCols.Contains(col)) continue;

                            object val = torqueReader[col];
                            if (col == "TorqueCurveID")
                                val = newId;

                            string safeParam = col.Replace("-", "_");
                            colNames.Add($"[{col}]");
                            valNames.Add($"@{safeParam}");
                            insertTorque.Parameters.AddWithValue($"@{safeParam}", val ?? DBNull.Value);
                        }

                        insertTorque.CommandText = $"INSERT INTO List_TorqueCurve ({string.Join(",", colNames)}) VALUES ({string.Join(",", valNames)})";
                        insertTorque.ExecuteNonQuery();
                    }
                }

                // Step 6: Copy upgrades from all relevant tables
                string[] upgradeTables = new[] {
                                "List_UpgradeEngineCSC",
                                "List_UpgradeEngineCamshaft",
                                "List_UpgradeEngineDSC",
                                "List_UpgradeEngineDisplacement",
                                "List_UpgradeEngineExhaust",
                                "List_UpgradeEngineFlywheel",
                                "List_UpgradeEngineFuelSystem",
                                "List_UpgradeEngineIgnition",
                                "List_UpgradeEngineIntake",
                                "List_UpgradeEngineIntercooler",
                                "List_UpgradeEngineManifold",
                                "List_UpgradeEngineOilCooling",
                                "List_UpgradeEnginePistonsCompression",
                                "List_UpgradeEngineRestrictorPlate",
                                "List_UpgradeEngineTurboQuad",
                                "List_UpgradeEngineTurboSingle",
                                "List_UpgradeEngineTurboTwin",
                                "List_UpgradeEngineValves"
        };

                long newBaseUpgradeId = newEngineId * 1000;
                long oldBaseUpgradeId = originalEngineId * 1000;

                foreach (var table in upgradeTables)
                {
                    var destCols = new HashSet<string>();
                    using (var pragma = new SQLiteCommand($"PRAGMA table_info({table})", conn))
                    using (var pReader = pragma.ExecuteReader())
                        while (pReader.Read())
                            destCols.Add(pReader["name"].ToString());

                    var selectUpgrades = new SQLiteCommand($"SELECT * FROM {table} WHERE EngineID = @OldID", conn);
                    selectUpgrades.Parameters.AddWithValue("@OldID", originalEngineId);

                    using (var upgradeReader = selectUpgrades.ExecuteReader())
                    {
                        while (upgradeReader.Read())
                        {
                            var insertColsU = new List<string>();
                            var insertValsU = new List<string>();
                            var insertUpgrade = new SQLiteCommand(conn);

                            long oldId = Convert.ToInt64(upgradeReader["Id"]);
                            long newId = oldId - oldBaseUpgradeId + newBaseUpgradeId;

                            for (int i = 0; i < upgradeReader.FieldCount; i++)
                            {
                                string col = upgradeReader.GetName(i);
                                if (!destCols.Contains(col)) continue;

                                object val = upgradeReader[col];
                                if (col == "Id")
                                    val = newId;
                                else if (col == "EngineID")
                                    val = newEngineId;

                                insertColsU.Add($"[{col}]");
                                insertValsU.Add($"@{col}");
                                insertUpgrade.Parameters.AddWithValue($"@{col}", val ?? DBNull.Value);
                            }

                            insertUpgrade.CommandText = $"INSERT INTO {table} ({string.Join(",", insertColsU)}) VALUES ({string.Join(",", insertValsU)})";
                            insertUpgrade.ExecuteNonQuery();
                        }
                    }
                }


                MessageBox.Show($"Engine duplicated with ID {newEngineId} and MediaName '{newMediaName}'.");
            }
        }

        private void buttonDeleteEngine_Click(object sender, EventArgs e)
        {
            if (comboBoxEngineManager.SelectedItem == null)
            {
                MessageBox.Show("Please select an engine to delete.");
                return;
            }

            int engineId = Convert.ToInt32(comboBoxEngineManager.SelectedValue);

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete engine ID {engineId} and all related data?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                using (var conn = new SQLiteConnection($"Data Source={PathDB};"))
                {
                    conn.Open();

                    using (var trans = conn.BeginTransaction())
                    {
                        // Delete dependent upgrades
                        string[] upgradeTables = new[] {
    "List_UpgradeEngineCSC",
    "List_UpgradeEngineCamshaft",
    "List_UpgradeEngineDSC",
    "List_UpgradeEngineDisplacement",
    "List_UpgradeEngineExhaust",
    "List_UpgradeEngineFlywheel",
    "List_UpgradeEngineFuelSystem",
    "List_UpgradeEngineIgnition",
    "List_UpgradeEngineIntake",
    "List_UpgradeEngineIntercooler",
    "List_UpgradeEngineManifold",
    "List_UpgradeEngineOilCooling",
    "List_UpgradeEnginePistonsCompression",
    "List_UpgradeEngineRestrictorPlate",
    "List_UpgradeEngineTurboQuad",
    "List_UpgradeEngineTurboSingle",
    "List_UpgradeEngineTurboTwin",
    "List_UpgradeEngineValves"
};

                        foreach (var table in upgradeTables)
                        {
                            using (var cmd = new SQLiteCommand($"DELETE FROM {table} WHERE EngineID = @EngineID", conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@EngineID", engineId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Delete torque curves
                        long torqueStart = engineId * 1000;
                        long torqueEnd = torqueStart + 999;
                        using (var cmdTorque = new SQLiteCommand("DELETE FROM List_TorqueCurve WHERE TorqueCurveID BETWEEN @Start AND @End", conn, trans))
                        {
                            cmdTorque.Parameters.AddWithValue("@Start", torqueStart);
                            cmdTorque.Parameters.AddWithValue("@End", torqueEnd);
                            cmdTorque.ExecuteNonQuery();
                        }

                        // Delete engine
                        using (var cmdEngine = new SQLiteCommand("DELETE FROM Data_Engine WHERE EngineID = @EngineID", conn, trans))
                        {
                            cmdEngine.Parameters.AddWithValue("@EngineID", engineId);
                            int rowsAffected = cmdEngine.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("Engine not found or already deleted.");
                                trans.Rollback();
                                return;
                            }
                        }

                        trans.Commit();
                    }
                }

                MessageBox.Show($"Engine ID {engineId} and related data deleted.");
                // Optionally refresh UI here after deletion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting engine: " + ex.Message);
            }
        }

        private void CalculatePowerForSelectedEngine()
        {
            if (comboBoxEngineManager.SelectedItem == null)
            {
                MessageBox.Show("Please select an engine.");
                return;
            }

            string selectedMediaName = comboBoxEngineManager.Text;

            try
            {
                using (var conn = new SQLiteConnection($"Data Source={PathDB};"))
                {
                    conn.Open();

                    // Step 1: Lookup EngineID
                    int? engineId = null;
                    int EngineID = 0;
                    using (var cmd = new SQLiteCommand("SELECT EngineID FROM Data_Engine WHERE MediaName = @MediaName", conn))
                    {
                        cmd.Parameters.AddWithValue("@MediaName", selectedMediaName);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            engineId = Convert.ToInt32(result);
                        EngineID = Convert.ToInt32(result);
                    }

                    if (engineId == null)
                    {
                        MessageBox.Show($"EngineID not found for MediaName '{selectedMediaName}'.");
                        return;
                    }

                    long baseTorqueCurveId = engineId.Value * 1000;
                    long highestTorqueCurveId = -1;

                    // Step 2: Find highest TorqueCurveID
                    using (var cmd = new SQLiteCommand(@"
                SELECT TorqueCurveID
                FROM List_TorqueCurve
                WHERE TorqueCurveID BETWEEN @Start AND @End
                ORDER BY TorqueCurveID DESC
                LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@Start", baseTorqueCurveId);
                        cmd.Parameters.AddWithValue("@End", baseTorqueCurveId + 999);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            highestTorqueCurveId = Convert.ToInt64(result);
                    }

                    if (highestTorqueCurveId == -1)
                    {
                        MessageBox.Show("No torque curves found for this engine.");
                        return;
                    }
                    double TorqueMultiplier = 1.0;
                    TorqueMultiplier = GetTorqueScaleFromUpgrades(conn, EngineID);
                    // Step 3: Calculate stock and max power
                    var stockPower = CalculatePowerFromTorqueCurve(conn, baseTorqueCurveId);
                    var maxPower = CalculatePowerFromTorqueCurve(conn, highestTorqueCurveId);
                    double adjustedMaxPowerKw = maxPower.powerKw * TorqueMultiplier;

                    lblStockPower.Text = $"{stockPower.powerKw:F1} kW @ {stockPower.rpm} RPM\n";
                    lblMaxPower.Text = $"{adjustedMaxPowerKw:F1} kW @ {maxPower.rpm} RPM";

                        

                    // Step 4: Load and show the stock torque curve chart
                    double[] torquePercentages = new double[246];
                    double torqueScale = 0;

                    double[] stockTorquePercentages = new double[246];
                    double[] maxTorquePercentages = new double[246];
                    double stockTorqueScale = 0;
                    double maxTorqueScale = 0;

                    string stockTorqueCurveId = EngineID.ToString("D6") + "000";
                    string maxTorqueCurveId = EngineID.ToString("D6") + "999";

                    // Load stock values
                    using (var cmd = new SQLiteCommand("SELECT * FROM List_TorqueCurve WHERE TorqueCurveID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", stockTorqueCurveId);
                        using var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            stockTorqueScale = Convert.ToDouble(reader["TorqueScale"]);
                            for (int i = 0; i <= 245; i++)
                            {
                                string column = "v" + i;
                                if (reader[column] != DBNull.Value)
                                    stockTorquePercentages[i] = Convert.ToDouble(reader[column]);
                            }
                        }
                    }

                    // Load max values
                    using (var cmd = new SQLiteCommand("SELECT * FROM List_TorqueCurve WHERE TorqueCurveID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", highestTorqueCurveId);
                        using var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            maxTorqueScale = Convert.ToDouble(reader["TorqueScale"]) * TorqueMultiplier;

                            for (int i = 0; i <= 245; i++)
                            {
                                string column = "v" + i;
                                if (reader[column] != DBNull.Value)
                                    maxTorquePercentages[i] = Convert.ToDouble(reader[column]);
                            }
                        }
                    }

                    // ✅ Show the chart with both stock and max curves
                    ShowTorqueCurveChartInPanel(
                        panelChart,
                        selectedMediaName,
                        maxTorquePercentages,
                        maxTorqueScale,
                        stockTorquePercentages,
                        stockTorqueScale);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating power: " + ex.Message);
            }
        }

        private double GetTorqueScaleFromUpgrades(SQLiteConnection conn, int engineId)
        {
            double totalMultiplier = 1.0;
            string[] upgradeTables = new[]
            {
        "List_UpgradeEngineDisplacement",
        "List_UpgradeEngineExhaust",
        "List_UpgradeEngineFuelSystem",
        "List_UpgradeEngineIgnition",
        "List_UpgradeEngineIntake",
        "List_UpgradeEngineManifold",
        "List_UpgradeEngineOilCooling",
        "List_UpgradeEnginePistonsCompression",
        "List_UpgradeEngineValves"
    };
            string[] upgradeAspirationTables = new[]
            {
        "List_UpgradeEngineTurboSingle",
        "List_UpgradeEngineTurboTwin",
        "List_UpgradeEngineTurboQuad",
        "List_UpgradeEngineDSC",
        "List_UpgradeEngineCSC"


            };

            List<double> torqueScales = new List<double>();

            double finalTorque = GetBaseTorqueScaleFromEngineID(conn, engineId); // Start with the base torque

            foreach (var table in upgradeTables)
            {
                using var cmd = new SQLiteCommand($@"
        SELECT TorqueScale 
        FROM {table} 
        WHERE EngineID = @EngineID 
        ORDER BY TorqueScale DESC 
        LIMIT 1;", conn);

                cmd.Parameters.AddWithValue("@EngineID", engineId);

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    double scale = Convert.ToDouble(result);
                    double scaledIncrease = GetBaseTorqueScaleFromEngineID(conn, engineId) * (scale - 1);
                    finalTorque += scaledIncrease;
                }
            }
            double highestScale = 1.0; // Default fallback

            bool ColumnExists(SQLiteConnection conn, string tableName, string columnName)
            {
                using var cmd = new SQLiteCommand($"PRAGMA table_info({tableName})", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["name"].ToString().Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
                return false;
            }

            foreach (var table2 in upgradeAspirationTables)
            {
                bool hasMax = ColumnExists(conn, table2, "MaxScale");
                bool hasRedline = ColumnExists(conn, table2, "RedlineRPMScale");

                if (!hasMax && !hasRedline)
                    continue; // Skip if neither column exists

                string selectedColumnExpr;
                if (hasMax && hasRedline)
                {
                    selectedColumnExpr = @"
            CASE 
                WHEN MaxScale IS NOT NULL THEN MaxScale
                ELSE RedlineRPMScale
            END AS ScaleValue";
                }
                else if (hasMax)
                {
                    selectedColumnExpr = "MaxScale AS ScaleValue";
                }
                else // hasRedline only
                {
                    selectedColumnExpr = "RedlineRPMScale AS ScaleValue";
                }

                string query = $@"
        SELECT {selectedColumnExpr}
        FROM {table2}
        WHERE EngineID = @EngineID
        ORDER BY ScaleValue DESC
        LIMIT 1;";

                using var cmd2 = new SQLiteCommand(query, conn);
                cmd2.Parameters.AddWithValue("@EngineID", engineId);

                var result = cmd2.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    double scale = Convert.ToDouble(result);
                    if (scale > highestScale)
                        highestScale = scale;

                }
            }

            // Now use `highestScale` instead of `totalMultiplier`

            totalMultiplier = totalMultiplier * highestScale;
            return totalMultiplier;
        }

        private double GetBaseTorqueScaleFromEngineID(SQLiteConnection conn, int engineId)
        {
            long torqueCurveId = engineId * 1000; // e.g., 123456 becomes 123456000

            using (var cmd = new SQLiteCommand("SELECT TorqueScale FROM List_TorqueCurve WHERE TorqueCurveID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", torqueCurveId);

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDouble(result);
                }
            }

            return 0.0; // or throw an exception if you want to enforce that it must exist
        }


        private (double powerKw, int rpm) CalculatePowerFromTorqueCurve(SQLiteConnection conn, long torqueCurveId)
        {
            using (var cmd = new SQLiteCommand("SELECT * FROM List_TorqueCurve WHERE TorqueCurveID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", torqueCurveId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return (0, 0);

                    double torqueScale = Convert.ToDouble(reader["TorqueScale"]);
                    double maxPowerKw = 0;
                    int maxPowerRpm = 0;

                    for (int i = 0; i <= 245; i++)
                    {
                        string column = "v" + i;
                        if (reader[column] is DBNull) continue;

                        double percent = Convert.ToDouble(reader[column]);
                        double torqueNm = percent * torqueScale;
                        int rpm = i * 100;

                        double powerKw = (torqueNm * rpm) / 9550.0;

                        if (powerKw > maxPowerKw)
                        {
                            maxPowerKw = powerKw;
                            maxPowerRpm = rpm;
                        }
                    }

                    return (maxPowerKw, maxPowerRpm);
                }
            }
        }

        private void ShowTorqueCurveChartInPanel(
    Panel panel,
    string mediaName,
    double[] maxTorquePercentages,
    double maxTorqueScale,
    double[] stockTorquePercentages,
    double stockTorqueScale)
        {
            var chart = new Chart();
            chart.Dock = DockStyle.Fill;

            var chartArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(chartArea);

            chartArea.AxisX.Title = "RPM";
            chartArea.AxisY.Title = "Torque / Power";
            chartArea.AxisX.Interval = 1000;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            // Enforce Y-axis >= 0
            chartArea.AxisY.Minimum = 0;

            // Cursor interaction setup
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = false;
            chartArea.CursorX.LineColor = Color.Gray;
            chartArea.CursorX.LineDashStyle = ChartDashStyle.Dash;

            // Tooltip label
            var tooltip = new Label
            {
                AutoSize = true,
                BackColor = Color.FromArgb(200, 255, 255, 255),
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            chart.Controls.Add(tooltip);

            int maxRpmIndex = 0;

            var seriesMaxTorque = new Series("Max Torque")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2
            };

            var seriesMaxPower = new Series("Max Power")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Blue,
                BorderWidth = 2
            };

            var seriesStockTorque = new Series("Stock Torque")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderDashStyle = ChartDashStyle.Dash,
                BorderWidth = 2
            };

            var seriesStockPower = new Series("Stock Power")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Blue,
                BorderDashStyle = ChartDashStyle.Dash,
                BorderWidth = 2
            };

            bool reachedZeroMax = false;
            bool reachedZeroStock = false;

            for (int i = 0; i <= 245; i++)
            {
                int rpm = i * 100;

                double maxTorque = maxTorquePercentages[i] * maxTorqueScale;
                double maxPower = (maxTorque * rpm) / 9550.0;

                double stockTorque = stockTorquePercentages[i] * stockTorqueScale;
                double stockPower = (stockTorque * rpm) / 9550.0;

                if (!reachedZeroMax && maxTorque > 0)
                {
                    seriesMaxTorque.Points.AddXY(rpm, maxTorque);
                    seriesMaxPower.Points.AddXY(rpm, maxPower);
                    maxRpmIndex = i;
                }
                else
                {
                    reachedZeroMax = true;
                }

                if (!reachedZeroStock && stockTorque > 0)
                {
                    seriesStockTorque.Points.AddXY(rpm, stockTorque);
                    seriesStockPower.Points.AddXY(rpm, stockPower);
                    maxRpmIndex = Math.Max(maxRpmIndex, i);
                }
                else
                {
                    reachedZeroStock = true;
                }
            }


            int maxRpm = ((maxRpmIndex * 100 + 999) / 1000) * 1000;
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = maxRpm;

            chart.Series.Add(seriesMaxTorque);
            chart.Series.Add(seriesMaxPower);
            chart.Series.Add(seriesStockTorque);
            chart.Series.Add(seriesStockPower);

            chart.Titles.Add($"Torque & Power Curve for {mediaName}");

            chart.MouseMove += (s, e) =>
            {
                var pos = e.Location;
                var result = chart.HitTest(pos.X, pos.Y);

                try
                {
                    if (result.ChartArea != null)
                    {
                        double xVal = chartArea.AxisX.PixelPositionToValue(pos.X);
                        int rpm = (int)Math.Round(xVal);

                        if (rpm >= 0 && rpm <= 24500)
                        {
                            int i0 = rpm / 100;
                            int i1 = Math.Min(i0 + 1, 245);
                            double fraction = (rpm % 100) / 100.0;

                            double interp(double[] values, double scale) =>
                                Math.Max(0, ((1 - fraction) * values[i0] + fraction * values[i1]) * scale);

                            double maxTorque = interp(maxTorquePercentages, maxTorqueScale);
                            double stockTorque = interp(stockTorquePercentages, stockTorqueScale);

                            double maxPower = Math.Max(0, (maxTorque * rpm) / 9550.0);
                            double stockPower = Math.Max(0, (stockTorque * rpm) / 9550.0);

                            tooltip.Text =
                                $"RPM: {rpm}\n" +
                                $"Max Torque: {maxTorque:F1} Nm\n" +
                                $"Max Power: {maxPower:F1} kW\n" +
                                $"Stock Torque: {stockTorque:F1} Nm\n" +
                                $"Stock Power: {stockPower:F1} kW";

                            tooltip.Location = new Point(pos.X + 15, pos.Y + 15);
                            tooltip.Visible = true;
                        }
                        else
                        {
                            tooltip.Visible = false;
                        }
                    }
                }
                catch
                {
                    tooltip.Visible = false;
                }
            };


            panel.Controls.Clear();
            panel.Controls.Add(chart);
        }




        private void lblStock_Click(object sender, EventArgs e)
        {

        }
    }


}





    
