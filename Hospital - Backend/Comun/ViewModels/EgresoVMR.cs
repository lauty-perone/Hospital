﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class EgresoVMR
    {
        public long id { get; set; }
        public System.DateTime fecha { get; set; }
        public string tratamiento { get; set; }
        public decimal monto { get; set; }
        public long medicoId { get; set; }
        public long pacienteId { get; set; }
    }
}
