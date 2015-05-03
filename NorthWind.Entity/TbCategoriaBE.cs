using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entity
{
    [DataContract]
    public class TbCategoriaBE
    {
        [DataMember]
        public int CodCategoria { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        //constructor
        public TbCategoriaBE()
        {
        }    

    }
}
