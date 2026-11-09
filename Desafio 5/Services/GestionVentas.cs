using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SistemaBotica.Models;

namespace SistemaBotica.Services
{
    public class DetalleVenta
    {
        public string Codigo { get; set; }
        public string Medicamento { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get { return Cantidad * PrecioUnitario; } }
    }

    public class GestionVentas
    {
        private readonly GestionMedicamentos gestion;
        private readonly string archivo;
        public GestionVentas(GestionMedicamentos gestionMedicamentos)
        {
            gestion = gestionMedicamentos;

            string carpeta = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data")
            );

            Directory.CreateDirectory(carpeta);
            archivo = Path.Combine(carpeta, "ventas.txt");
        }
        public bool RegistrarVenta(List<DetalleVenta> detalles, out string mensaje)
        {
            if (detalles == null || detalles.Count == 0) { mensaje="Agregue al menos un producto."; return false; }
            foreach (var d in detalles)
            {
                Medicamento m=gestion.BuscarPorCodigo(d.Codigo);
                if(m==null || m.Stock<d.Cantidad) { mensaje="Stock insuficiente para: "+d.Medicamento; return false; }
            }
            foreach (var d in detalles) gestion.DescontarStock(d.Codigo,d.Cantidad);
            string registro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|" +
                string.Join(";", detalles.Select(d => d.Codigo+":"+d.Cantidad+":"+d.Subtotal.ToString(System.Globalization.CultureInfo.InvariantCulture))) + "|" +
                detalles.Sum(d=>d.Subtotal).ToString(System.Globalization.CultureInfo.InvariantCulture);
            File.AppendAllText(archivo, registro + Environment.NewLine);
            mensaje="Venta registrada correctamente."; return true;
        }
    }
}
