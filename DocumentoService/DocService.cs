﻿using NorthWind.Entity;
using NorthWind.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DocumentoService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class DocService : IDocService
    {

        public void GuardarDocumento(DocumentoBE oDocumentoDTO)
        {
            TbDocumentoBL documento = new TbDocumentoBL();
            documento.GuardarDocumentoFromServiceLogic(oDocumentoDTO);
            //documento.GuardarDocumento(oDocumentoDTO);
        }
    }
}
