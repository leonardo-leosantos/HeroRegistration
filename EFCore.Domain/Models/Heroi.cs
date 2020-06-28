using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Heroi
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Arma> Armas { get; set; }
        public List<HeroiBatalha> HeroiBatalhas { get; set; }
    }
}