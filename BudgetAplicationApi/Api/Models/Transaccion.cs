﻿namespace BudgetAplicationApi.Api.Models
{
    public class Transaccion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public bool Estado { get; set; } = true;
        public ICollection<Movimiento> Movimientos { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
        public int CompaniaId { get; set; }
        public Compania Compania { get; set; }
    }
}
