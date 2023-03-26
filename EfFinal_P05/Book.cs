using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfFinal_P05
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int PageCount { get; set; }
        public string? Style { get; set; }
        public DateTime? Created { get; set; }
        [Column(TypeName = "money")]
        public decimal SelfPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal SellPrice { get; set; }
        public int Continuos { get; set; }
    }
}
