namespace PerfilBackend.Dtos{
    public class FollowsReadDto{
        public int Id { get; set; }
        public string IdUsuarioFollower{ get; set; } 
        public string NombreFollower { get; set; }
        public string IdUsuarioFollowBy { get; set; }
        public string NombreFolloweBy { get; set; }
    }
}