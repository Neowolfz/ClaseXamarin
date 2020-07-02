using System;
using System.Collections.Generic;

namespace UnicornHamApi.Entities.Models
{
    public partial class Ingredientes
    {
        public int Id { get; set; }
        public int HamId { get; set; }
        public string Ingre1 { get; set; }
        public string Ingre2 { get; set; }
        public string Ingre3 { get; set; }

        public virtual Hamburguesas Ham { get; set; }
    }
}
