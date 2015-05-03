using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entity
{
    [DataContract]
    public class CabDocumentoBE
    {
        [DataMember]
        public string CodDocumento { get; set; }
        [DataMember]
        public TbClienteBE Cliente { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public decimal IGV { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public DateTime FechaHora { get; set; }
        [DataMember]
        public eTipoDocumento TipoDocumento { get; set; }
    }
}
