using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetAplicationApi.Data.Migrations
{
    public partial class updateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Companias_CompañiaID",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Transacciones_TransaccionID",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Usuarios_UsuarioID",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_CompañiaID",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_UsuarioID",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "CompañiaID",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Movimientos");

            migrationBuilder.RenameColumn(
                name: "TransaccionID",
                table: "Movimientos",
                newName: "TransaccionId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimientos_TransaccionID",
                table: "Movimientos",
                newName: "IX_Movimientos_TransaccionId");

            migrationBuilder.AddColumn<int>(
                name: "CompaniaId",
                table: "Transacciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Transacciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Transacciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Transacciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompaniaID",
                table: "Movimientos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosID",
                table: "Movimientos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_CompaniaId",
                table: "Transacciones",
                column: "CompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_UsuarioId",
                table: "Transacciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CompaniaID",
                table: "Movimientos",
                column: "CompaniaID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_UsuariosID",
                table: "Movimientos",
                column: "UsuariosID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Companias_CompaniaID",
                table: "Movimientos",
                column: "CompaniaID",
                principalTable: "Companias",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Transacciones_TransaccionId",
                table: "Movimientos",
                column: "TransaccionId",
                principalTable: "Transacciones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Usuarios_UsuariosID",
                table: "Movimientos",
                column: "UsuariosID",
                principalTable: "Usuarios",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Companias_CompaniaId",
                table: "Transacciones",
                column: "CompaniaId",
                principalTable: "Companias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Usuarios_UsuarioId",
                table: "Transacciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Companias_CompaniaID",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Transacciones_TransaccionId",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Usuarios_UsuariosID",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Companias_CompaniaId",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Usuarios_UsuarioId",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_CompaniaId",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_UsuarioId",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_CompaniaID",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_UsuariosID",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "CompaniaId",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "CompaniaID",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "UsuariosID",
                table: "Movimientos");

            migrationBuilder.RenameColumn(
                name: "TransaccionId",
                table: "Movimientos",
                newName: "TransaccionID");

            migrationBuilder.RenameIndex(
                name: "IX_Movimientos_TransaccionId",
                table: "Movimientos",
                newName: "IX_Movimientos_TransaccionID");

            migrationBuilder.AddColumn<int>(
                name: "CompañiaID",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CompañiaID",
                table: "Movimientos",
                column: "CompañiaID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_UsuarioID",
                table: "Movimientos",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Companias_CompañiaID",
                table: "Movimientos",
                column: "CompañiaID",
                principalTable: "Companias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Transacciones_TransaccionID",
                table: "Movimientos",
                column: "TransaccionID",
                principalTable: "Transacciones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Usuarios_UsuarioID",
                table: "Movimientos",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
