using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForzaSwapper.src
{
    internal class MediaItem
    {


        public int Id {  get; set; }
        public string MediaName { get; set; }

        public override string ToString()
        {
            return MediaName;
        }
    }
}
