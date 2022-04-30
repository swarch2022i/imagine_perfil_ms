namespace PerfilBackend.Dtos
{
    public class PerfilReadDto
    {

        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string IdImagenPerfil { get; set; }
        public string Texto { get; set; }
        public int NumfollowBy { get; set; }
        public int Numfollowers { get; set; }
    }
}
