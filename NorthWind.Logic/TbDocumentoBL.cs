using NorthWind.DAO;
using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Logic
{
    public class TbDocumentoBL
    {
        public eEstadoProceso GuardarDocumento(DocumentoBE oDocumentoDTO)
        {
            return new TbDocumentoDao().GuardarDocumento(oDocumentoDTO);
            //TbDocumentoDao demo = new TbDocumentoDao();
            //demo.GuardarDocumento(oDocumentoDTO);
        }

        public void GuardarDocumentoFromServiceLogic(DocumentoBE oDocumentoDTO)
        {
            TbDocumentoDao documento = new TbDocumentoDao();
            documento.GuardarDocumentoFromService(oDocumentoDTO);
        }

    }
}
