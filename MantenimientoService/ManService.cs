using NorthWind.Entity;
using NorthWind.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MantenimientoService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ManService : IManService
    {
        public List<TbClienteBE> SelectAllFromCliente()
        {
            return TbClienteBL.SelectAll();
        }

        public List<TbCategoriaBE> SelectAllFromCategoria()
        {
            return TbCategoriaBL.SelectAll();
        }

        public List<TbProductoBE> SelectAllFromProducto()
        {
            return TbProductoBL.SelectAll();
        }
    }
}
