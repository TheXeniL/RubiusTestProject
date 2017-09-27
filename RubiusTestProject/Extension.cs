using System.Windows.Forms;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using System;
using System.Windows;
using System.Windows.Controls;
using Autodesk.AutoCAD.DatabaseServices;

// Данный класс представляет собой расширение, то есть плагин к AutoCad, в нем мы исполняем все необходимые условия задания.
namespace RubiusTestProject
{
    public class Extension : IExtensionApplication
    {
        private LoadElements autocadLoadContent;
        private PaletteSet palette;
        private Window window;

        // функция инициализации (выполняется при загрузке плагина)
        public void Initialize()
        {

        }

        // функция, выполняемая при выгрузке плагина
        public void Terminate()
        {

        }

        // эта функция будет вызываться при выполнении в AutoCAD команды «AUTOCAD»
        [CommandMethod("AUTOCAD")]
        public void MyCommand()
        {
            // Создаем соединение с AutoCad для получения элементов открытого проекта.
            autocadLoadContent = new LoadElements();

            // Создаем новое диологовое окно на котором будут распологаться загруженные элементы для редактирования.
            window = new Window();
            palette = new PaletteSet("Test"){};
            palette.AddVisual("windowToShow", window);
            palette.KeepFocus = true;
            palette.Visible = true;


        }

        public void LoadObjectsToWindow()
        {
            var objects = autocadLoadContent.LoadObjects();

            foreach (var layer in objects.layers)
            {
                var layerToChange = new LayerToChange(layer);

            }

        }

    }
}
