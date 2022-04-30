using System.ComponentModel.DataAnnotations;

namespace PerfilBackend.Dtos{
    public class FollowsCreateDto{
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