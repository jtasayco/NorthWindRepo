﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entity
{

    public enum eTipoDocumento
    {
        Nothing,
        Factura,
        Boleta,
        GuiaRemision,
    }

    public enum eEstadoProceso
    {
        Nothing,
        Error,
        Correcto,
    }

}
