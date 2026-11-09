using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SistemaBotica.Models;

namespace SistemaBotica.Services
{
    public class GestionMedicamentos
    {
        private readonly List<Medicamento> medicamentos = new List<Medicamento>();
        private readonly string archivo;

        public GestionMedicamentos()
        {
            string carpeta = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data")
            );

            Directory.CreateDirectory(carpeta);
            archivo = Path.Combine(carpeta, "medicamentos.txt");

            Cargar();
        }

        private void Cargar()
        {
            if (!File.Exists(archivo)) return;
            foreach (string linea in File.ReadAllLines(archivo))
            {
                string[] p = linea.Split('|');
                decimal precio; int stock; DateTime fecha;
                if (p.Length != 7 || !decimal.TryParse(p[4], out precio) ||
                    !int.TryParse(p[5], out stock) || !DateTime.TryParse(p[6], out fecha)) continue;
                medicamentos.Add(new Medicamento { Codigo=p[0], Nombre=p[1], Categoria=p[2], Laboratorio=p[3], Precio=precio, Stock=stock, FechaVencimiento=fecha });
            }
        }

        private void Guardar()
        {
            File.WriteAllLines(archivo, medicamentos.Select(m => string.Join("|", new[] {
                Limpiar(m.Codigo), Limpiar(m.Nombre), Limpiar(m.Categoria), Limpiar(m.Laboratorio),
                m.Precio.ToString(System.Globalization.CultureInfo.InvariantCulture), m.Stock.ToString(), m.FechaVencimiento.ToString("yyyy-MM-dd")
            })));
        }
        private string Limpiar(string valor) { return (valor ?? "").Replace("|", "/").Replace("\r", " ").Replace("\n", " "); }

        public bool RegistrarMedicamento(Medicamento medicamento)
        {
            if (medicamento == null || medicamentos.Any(m => m.Codigo.Equals(medicamento.Codigo, StringComparison.OrdinalIgnoreCase))) return false;
            medicamentos.Add(medicamento); Guardar(); return true;
        }
        public Medicamento BuscarPorCodigo(string codigo)
        { return medicamentos.FirstOrDefault(m => m.Codigo.Equals(codigo ?? "", StringComparison.OrdinalIgnoreCase)); }
        public List<Medicamento> BuscarPorNombre(string nombre)
        { return medicamentos.Where(m => m.Nombre.IndexOf(nombre ?? "", StringComparison.OrdinalIgnoreCase) >= 0).ToList(); }
        public bool ActualizarMedicamento(string codigo, Medicamento nuevosDatos)
        {
            Medicamento m = BuscarPorCodigo(codigo); if (m == null || nuevosDatos == null) return false;
            m.Nombre=nuevosDatos.Nombre; m.Categoria=nuevosDatos.Categoria; m.Laboratorio=nuevosDatos.Laboratorio;
            m.Precio=nuevosDatos.Precio; m.Stock=nuevosDatos.Stock; m.FechaVencimiento=nuevosDatos.FechaVencimiento;
            Guardar(); return true;
        }
        public bool EliminarMedicamento(string codigo)
        { Medicamento m=BuscarPorCodigo(codigo); if(m==null)return false; medicamentos.Remove(m); Guardar(); return true; }
        public List<Medicamento> ObtenerTodos() { return medicamentos.ToList(); }
        public bool DescontarStock(string codigo, int cantidad)
        { Medicamento m=BuscarPorCodigo(codigo); if(m==null || cantidad<=0 || m.Stock<cantidad)return false; m.Stock-=cantidad; Guardar(); return true; }
    }
}
