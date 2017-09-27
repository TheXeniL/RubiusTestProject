using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;

namespace RubiusTestProject
{
    class Data
    {
        public List<DBPoint> dots;
        public List<Line> lines;
        public List<Circle> circles;
        public List<LayerTableRecord> layers;

        public Data()
        {
            dots = new List<DBPoint>();
            lines = new List<Line>();
            circles = new List<Circle>();
            layers = new List<LayerTableRecord>();
        }
    }
}
