using System.ComponentModel.DataAnnotations;

namespace PerfilBackend.Dtos
{
    public class PerfilCreateDto
    {
        [Required]
        public string IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string IdImagenPerfil { get; set; }
        public string Texto { get; set; }
        public int NumfollowBy { get; set; }
        public int Numfollowers { get; set; }
    }
}
