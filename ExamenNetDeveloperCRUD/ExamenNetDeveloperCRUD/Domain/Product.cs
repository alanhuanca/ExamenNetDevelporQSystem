using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenNetDeveloperCRUD.Domain
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
