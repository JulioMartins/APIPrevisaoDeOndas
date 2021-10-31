using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIClimaTempo.Controllers
{
    public class Clima
    {       
        public Clima(string Cidade, string UF, string dia, string tempo, string maxima, string minima)
        {
            this.Cidade = Cidade;
            this.UF = UF;
            this.dia = dia;
            this.tempo = tempo;
            this.maxima = maxima;
            this.minima = minima;
        }

        string Cidade { get; set; }
        string UF { get; set; }
        string dia { get; set; }
        string tempo { get; set; }
        string maxima { get; set; }
        string minima { get; set; }                   
    }

}
