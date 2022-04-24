using System.ComponentModel.DataAnnotations;

namespace PerfilBackend.Dtos
{
    public class PerfilCreateDto
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string IdImagenPerfil { get; set; }
        public string Texto { get; set; }
        [Required]
        public int Numfollows { get; set; }
        [Required]
        public int Numfollowers { get; set; }
    }
}
