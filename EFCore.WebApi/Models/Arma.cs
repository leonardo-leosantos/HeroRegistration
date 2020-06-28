using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebApi.Models
{
    public class Arma
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IdHeroi { get; set; }
    }
}
