using System.ComponentModel.DataAnnotations;

namespace PerfilBackend.Models
{
    public class Perfil
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string IdImagenPerfil { get; set; }
        public string Texto { get; set; }
        [Required]
        public int NumfollowBy { get; set; }
        [Required]
        public int Numfollowers { get; set; }
    }
}
