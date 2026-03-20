namespace Api_Becas.Models
{
    public class SolicitudModel
    {
        public int Sol_Id { get; set; }
        public DateTime Sol_Fecha { get; set; }
        public string? Sol_Estado { get; set; }
        public string? Sol_Comentarios { get; set; }
        public string? Sol_CorreoEstudiante { get; set; }
        public string? Sol_CrearContra { get; set; }
        public int Sol_TelefonoEstudiante { get; set; }
        public string? Sol_DireccionEstudiante {  get; set; }
        public string? Sol_Estatus { get; set; }
    }
}
