using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Contracts
{
    interface IExportFactory
    {
        IExportFile getFileExporter(string type);
    }
}
