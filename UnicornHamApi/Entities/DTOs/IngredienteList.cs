using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnicornHamApi.Entities.Models;

namespace UnicornHamApi.Entities.DTOs
{
    public class IngredienteList
    {
        public int idHam { get; set; }
        public List<Hamburguesas> ingredientesAgregados { get; set; }

    }
}
