using System;
using BudgetAplicationApi.Api;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Business.Authentication;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetAplicationApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        private const string username = "superuser";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngresoTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contabilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naturaleza = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contabilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jwt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiraEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jwt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jwt_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    CompañiaID = table.Column<int>(type: "int", nullable: false),
                    ContabilidadId = table.Column<int>(type: "int", nullable: false),
                    TransaccionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movimientos_Companias_CompañiaID",
                        column: x => x.CompañiaID,
                        principalTable: "Companias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Contabilidades_ContabilidadId",
                        column: x => x.ContabilidadId,
                        principalTable: "Contabilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Transacciones_TransaccionID",
                        column: x => x.TransaccionID,
                        principalTable: "Transacciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuarios",
                columns: table => new
                {
                    RolesID = table.Column<int>(type: "int", nullable: false),
                    UsuariosID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuarios", x => new { x.RolesID, x.UsuariosID });
                    table.ForeignKey(
                        name: "FK_RolUsuarios_Roles_RolesID",
                        column: x => x.RolesID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuarios_Usuarios_UsuariosID",
                        column: x => x.UsuariosID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jwt_UsuarioID",
                table: "Jwt",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CompañiaID",
                table: "Movimientos",
                column: "CompañiaID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ContabilidadId",
                table: "Movimientos",
                column: "ContabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_TransaccionID",
                table: "Movimientos",
                column: "TransaccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_UsuarioID",
                table: "Movimientos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuarios_UsuariosID",
                table: "RolUsuarios",
                column: "UsuariosID");

            //Add Roles
            migrationBuilder.InsertData("Roles",
                columns: new[] { nameof(Rol.Descripcion), nameof(Rol.Fecha), nameof(Rol.Estado) },
                values: new object[,] {
                   { (int)RolesEnum.Contador, DateTime.UtcNow, true},
                   { (int)RolesEnum.Admin, DateTime.UtcNow, true}
                    }
                );

            //MainUser
            PasswordHasher passwordHasher = new PasswordHasher();
            var passwordhash = passwordHasher.Hash("12345");
            migrationBuilder.InsertData("Usuarios",
                columns: new[] { nameof(Usuarios.Nombre), nameof(Usuarios.Contrasena), nameof(Usuarios.Fecha), nameof(Usuarios.Estado), nameof(Usuarios.CorreoElectronico), nameof(Usuarios.NumeroIdentificacion) },
                values: new object[,] {
                   { username, passwordhash, DateTime.UtcNow, true, "admin@osd.com", "admin"} }
                );

            //Assign Role to Super User
            migrationBuilder.InsertData("RolUsuarios",
                columns: new[] { "RolesID", "UsuariosID" },
                values: new object[,] {
                   { 1, 1 } }
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jwt");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "RolUsuarios");

            migrationBuilder.DropTable(
                name: "Companias");

            migrationBuilder.DropTable(
                name: "Contabilidades");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
