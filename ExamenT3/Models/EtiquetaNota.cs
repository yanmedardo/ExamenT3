﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class EtiquetaNota
    {
        public int EtiquetaId { get; set; }
        public Etiqueta Etiqueta { get; set; }
        public int NotaId { get; set; }
        public Nota Nota { get; set; }
    }
}
