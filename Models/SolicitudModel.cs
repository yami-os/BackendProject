using System.ComponentModel.DataAnnotations;

namespace Api_Becas.Models
{
    public class SolicitudModel
    {
        [Key]
        public int Sol_Id { get; set; }

        //public DateTime Sol_Fecha { get; set; }

        public string? Sol_Estado { get; set; }
        public string? Sol_Comentarios { get; set; }
        public string? Sol_CorreoEst { get; set; }
        public string? Sol_CrearContra { get; set; }
        public string? Sol_Telefono { get; set; }
        public string? Sol_Direccion { get; set; }

        public int Con_Id { get; set; }
    }
}