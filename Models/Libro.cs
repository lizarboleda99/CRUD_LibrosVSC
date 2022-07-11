using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_LibrosVSC.Models
{
    public class Libro
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int paginas { get; set; }
        [Required]
        public string editorial { get; set; }
        [Required]
        public string autor { get; set; }
        [Required]
        public float precio { get; set; }
    }
}