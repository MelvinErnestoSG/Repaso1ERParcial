using System.ComponentModel.DataAnnotations;

namespace Repaso1ERParcial.Entidades
{
    public class Colores
    {
        [Key]
        public int ColoresId { get; set; }
        public string Nombre { get; set; }
    }
}
