﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun.ViewModels
{
    public class MedicoVMR//View Model Resource
        //devolver los campos que se quiere mostrar en el Frontend
    {
        public long id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public bool esEspecialista { get; set; }
        public bool habilitado { get; set; }
    }
}
