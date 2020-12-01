using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models.ViewModels
{
    public class BandaInstrumentosViewModel
    {
        public Banda Banda { get; set; }

        public List<Instrumento> Instrumentos { get; set; }
    }
}