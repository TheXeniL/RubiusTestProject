using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;

namespace RubiusTestProject
{
   // Данный класс позволяет взаимодействовать с автокадом, его объектами, с помощью LoadElements мы сможем загружать и сохранять объекты для редактирования

    class LoadElements
    {
        private Database dataBase; // Данный класс позволяет обратится к объектам текущего проекта.
        private Transaction transaction; // Данный класс расширяет возможности работы с объектами Autocad и позволяет избегать ошибки связанные с открытием и сохранением объектов.
        private Data objects = new Data();

        public LoadElements()
        {
            dataBase = Application.DocumentManager.MdiActiveDocument.Database;
            transaction = dataBase.TransactionManager.StartTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Dispose()
        {
            transaction.Dispose();
        }

        // Метод позволяет загрузить все слои, выносим отдельно для удобства записи. 
        private List<LayerTableRecord> LoadLayers()
        {
            var loadedLayers = new List<LayerTableRecord>();
            LayerTable layerTable = transaction.GetObject(dataBase.LayerTableId, OpenMode.ForWrite) as LayerTable;

            foreach (ObjectId layerId in layerTable)
            {
                var layer = transaction.GetObject(layerId, OpenMode.ForWrite) as LayerTableRecord;
                loadedLayers.Add(layer);
            }

            return loadedLayers;
        }

        // Метод позволяет загружать все нужные объекты, которые затем мы расскладываем по созданым ранее массивам для удобство обращения к объектам.
        public Data LoadObjects()
        {
            
            BlockTableRecord table =(BlockTableRecord) transaction.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(dataBase), OpenMode.ForWrite);

            foreach(ObjectId objectId in table)
            {
                // Здесь я привожу каждый полученный объект к типу Object для удобного сравнения и распределения необходимых объектов.
                Object compareObject = (Object)transaction.GetObject(objectId, OpenMode.ForWrite);

                if (compareObject.GetType() == typeof(Line))
                {
                    objects.lines.Add(compareObject as Line);
                }

                if (compareObject.GetType() == typeof(Circle))
                {
                    objects.circles.Add(compareObject as Circle);
                }

                if (compareObject.GetType() == typeof(DBPoint))
                {
                    objects.dots.Add(compareObject as DBPoint);
                }

            }

            objects.layers = LoadLayers();

            return objects;

        }

    }
}