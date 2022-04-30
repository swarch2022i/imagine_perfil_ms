using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfilBackend.Migrations
{
    public partial class PefilsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FollowsT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuarioFollower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreFollower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioFollowBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreFolloweBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowsT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdImagenPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumfollowBy = table.Column<int>(type: "int", nullable: false),
                    Numfollowers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowsT");

            migrationBuilder.DropTable(
                name: "Perfiles");
        }
    }
}
