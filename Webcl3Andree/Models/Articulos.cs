using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cl3AndreeChiquis.Models
{
    public class Articulos
    {

        [Display(Name = "Codigo")]
        public string? cod_art { get; set; }

        [Display(Name = "Nombre")]
        public string? nom_art { get; set; }

        [Display(Name = "U. Medida")]
        public string? uni_med { get; set; }
        [Display(Name = "Precio")]
        public decimal pre_art { get; set; }

        [Display(Name = "Stock")]
        public int stk_art { get; set; }
        public string? de_baja { get; set; }

    }
}
