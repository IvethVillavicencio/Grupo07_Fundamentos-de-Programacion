
using System;

namespace SistemaBotica.Models
{
    public class Medicamento
    {
        // Atributos del medicamento
        public string Codigo { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Categoria { get; set; } = "";
        public string Laboratorio { get; set; } = "";

        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public DateTime FechaVencimiento { get; set; }

        // Constructor
        public Medicamento()
        {
        }

        // Verificar si tiene poco stock
        public bool TieneStockBajo()
        {
            return Stock <= 5;
        }

        // Obtener el valor total del inventario
        public decimal CalcularValorInventario()
        {
            return Precio * Stock;
        }
    }
}
