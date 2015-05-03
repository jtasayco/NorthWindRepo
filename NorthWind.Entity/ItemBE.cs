using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entity
{
    [DataContract]
    public class ItemBE
    {
        [DataMember]
        public int Item { get; set; }
        [DataMember]
        public string CodigoDetalle { get; set; }
        [DataMember]
        public string CodDocumento { get; set; }
        [DataMember]
        public TbProductoBE Producto { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public decimal Total
        {
            get { return Precio * Cantidad; }
        }

    }
}
