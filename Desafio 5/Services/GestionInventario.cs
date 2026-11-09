
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaBotica.Models;

namespace SistemaBotica.Services
{
    public class GestionInventario
    {
        private readonly GestionMedicamentos gestion;

        // Constructor: recibe la gestion de medicamentos
        public GestionInventario(GestionMedicamentos gestion)
        {
            this.gestion = gestion;
        }

        // 1. Obtener todos los medicamentos
        public List<Medicamento> ObtenerInventario()
        {
            return gestion.ObtenerTodos();
        }

        // 2. Obtener medicamentos con stock bajo
        public List<Medicamento> ObtenerStockBajo(int limite = 5)
        {
            return gestion.ObtenerTodos()
                .Where(m => m.Stock <= limite)
                .ToList();
        }

        // 3. Obtener medicamentos proximos a vencer
        public List<Medicamento> ObtenerProximosAVencer(
            int dias = 90)
        {
            DateTime hoy = DateTime.Today;
            DateTime limite = hoy.AddDays(dias);

            return gestion.ObtenerTodos()
                .Where(m =>
                    m.FechaVencimiento.Date >= hoy &&
                    m.FechaVencimiento.Date <= limite)
                .ToList();
        }

        // 4. Obtener medicamentos vencidos
        public List<Medicamento> ObtenerVencidos()
        {
            return gestion.ObtenerTodos()
                .Where(m =>
                    m.FechaVencimiento.Date < DateTime.Today)
                .ToList();
        }

        // 5. Calcular el valor total del inventario
        public decimal CalcularValorTotal()
        {
            return gestion.ObtenerTodos()
                .Sum(m => m.Precio * m.Stock);
        }
    }
}
