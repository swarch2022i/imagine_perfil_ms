using System.ComponentModel.DataAnnotations;

namespace PerfilBackend.Models{
    public class Follows{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string IdUsuarioFollower { get; set; }
        [Required]
        public string NombreFollower { get; set; }
        [Required]
        public string IdUsuarioFollowBy { get; set; }
        [Required]
        public string NombreFolloweBy { get; set; }
    }
}