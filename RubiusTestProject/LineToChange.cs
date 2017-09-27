using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System.Windows.Forms;

namespace RubiusTestProject
{

    class LineToChange
    {
        private Line line;
        public String thikness;
        public Tuple<String, String, String> startPoint;
        public Tuple<String, String, String> endPoint;

        public LineToChange(Line line)
        {
            this.line = line;
        }

        public void ChangeElement()
        {
            line.Thickness = Convert.ToDouble(thikness);
            line.StartPoint = new Point3d(Convert.ToDouble(startPoint.Item1), Convert.ToDouble(startPoint.Item2), Convert.ToDouble(startPoint.Item3));
            line.EndPoint = new Point3d(Convert.ToDouble(endPoint.Item1), Convert.ToDouble(endPoint.Item2), Convert.ToDouble(endPoint.Item3));
        }
    }

}
