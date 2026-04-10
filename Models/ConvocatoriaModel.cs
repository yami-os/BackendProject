using System.ComponentModel.DataAnnotations;

namespace Api_Becas.Models
{
    public class ConvocatoriaModel
    {
        [Key]
        public int Con_Id { get; set; }

        public string? Con_Tipo { get; set; }
        public DateTime Con_Fecha { get; set; }
    }
}
