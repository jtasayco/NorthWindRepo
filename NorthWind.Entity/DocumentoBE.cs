using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace NorthWind.Entity
{
    [DataContract]
    public class DocumentoBE
    {
        [DataMember]
        public CabDocumentoBE Cabecera { get; set; }
        [DataMember]
        public List<ItemBE> Detalle { get; set; }
    }
}
