using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundaries.Persistence.Migrations
{
    public partial class changeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoPermisos_Permisos_PermisoId",
                table: "TipoPermisos");

            migrationBuilder.DropIndex(
                name: "IX_TipoPermisos_PermisoId",
                table: "TipoPermisos");

            migrationBuilder.DropColumn(
                name: "PermisoId",
                table: "TipoPermisos");

            migrationBuilder.InsertData(
                table: "TipoPermisos",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Enfermedad" },
                    { 2, "Diligencias" },
                    { 3, "Universidad" },
                    { 4, "Dentista" },
                    { 5, "Almorzar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_TipoPermisoId",
                table: "Permisos",
                column: "TipoPermisoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_TipoPermisos_TipoPermisoId",
                table: "Permisos",
                column: "TipoPermisoId",
                principalTable: "TipoPermisos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_TipoPermisos_TipoPermisoId",
                table: "Permisos");

            migrationBuilder.DropIndex(
                name: "IX_Permisos_TipoPermisoId",
                table: "Permisos");

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoPermisos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "PermisoId",
                table: "TipoPermisos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPermisos_PermisoId",
                table: "TipoPermisos",
                column: "PermisoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPermisos_Permisos_PermisoId",
                table: "TipoPermisos",
                column: "PermisoId",
                principalTable: "Permisos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
