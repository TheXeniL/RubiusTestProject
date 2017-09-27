using System;
using System.Windows.Controls;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;

namespace RubiusTestProject
{
    class LayerToChange
    {
        public LayerTableRecord layer;
        public TextBox name;
        public Tuple<String, String, String> rgbColor;
        public CheckBox visible;

        public LayerToChange(LayerTableRecord layer)
        {
            this.layer = layer;
        }

        public void ChangeElement()
        {
            layer.IsOff = (bool) visible.IsChecked;
            layer.Color = Color.FromRgb(Convert.ToByte(rgbColor.Item1), Convert.ToByte(rgbColor.Item2), Convert.ToByte(rgbColor.Item3));
        }

    }
}