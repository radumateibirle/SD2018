using Assignment1.ServicesLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Services
{
    class ExportFactory : IExportFactory
    {
        public IExportFile getFileExporter(string type)
        {
            switch (type.ToLower())
            {
                case "xml": return new ExportXML();
                case "csv": return new ExportCSV();
                default: return null;
            }
        }
    }
}
