using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMTilesDownloader.Models
{
    public class BoundaryModel
    {
        public double left { get; set; }
        public double bottom { get; set; }
        public double right { get; set; }
        public double top { get; set; }
    }
}
