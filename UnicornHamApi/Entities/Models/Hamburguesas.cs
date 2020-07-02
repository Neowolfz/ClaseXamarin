using System;
using System.Collections.Generic;

namespace UnicornHamApi.Entities.Models
{
    public partial class Hamburguesas
    {
        public Hamburguesas()
        {
            Ingredientes = new HashSet<Ingredientes>();
        }

        public int Id { get; set; }
        public string HamName { get; set; }

        public virtual ICollection<Ingredientes> Ingredientes { get; set; }
    }
}
