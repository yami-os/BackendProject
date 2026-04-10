using System.ComponentModel.DataAnnotations;

namespace Api_Becas.Models
{
    public class AdministradorModel
    {
        [Key]
        public int Adm_Id { get; set; }

        public string? Adm_Nombre { get; set; }
        public string? Adm_Correo { get; set; }
        public string? Adm_Contra {  get; set; }
    }
}
