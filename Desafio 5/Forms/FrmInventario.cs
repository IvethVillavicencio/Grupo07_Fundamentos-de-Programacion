
using System;
using System.Windows.Forms;
using SistemaBotica.Services;

namespace SistemaBotica.Forms
{
    public partial class FrmInventario : Form
    {
        private GestionInventario inventario;

        public FrmInventario(GestionMedicamentos gestion)
        {
            InitializeComponent();

            inventario = new GestionInventario(gestion);

            dgvInventario.Columns.Clear();
            dgvInventario.AutoGenerateColumns = true;
            dgvInventario.ReadOnly = true;
            dgvInventario.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventario.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvInventario.MultiSelect = false;

            // Conectar botones
            btnTodos.Click += btnTodos_Click;
            btnStockBajo.Click += btnStockBajo_Click;
            btnProximos.Click += btnProximos_Click;
            btnVencidos.Click += btnVencidos_Click;

            MostrarInventario();
        }

        // Mostrar todos los medicamentos
        private void MostrarInventario()
        {
            dgvInventario.DataSource =
                inventario.ObtenerInventario();

            ActualizarValorTotal();
        }

        // Actualizar valor del inventario
        private void ActualizarValorTotal()
        {
            decimal total = inventario.CalcularValorTotal();

            lblValorTotal.Text =
                "Valor total: S/ " + total.ToString("N2");
        }

        // Ver todos
        private void btnTodos_Click(
            object sender, EventArgs e)
        {
            MostrarInventario();
        }

        // Ver stock bajo
        private void btnStockBajo_Click(
            object sender, EventArgs e)
        {
            dgvInventario.DataSource =
                inventario.ObtenerStockBajo();
        }

        // Ver proximos a vencer
        private void btnProximos_Click(
            object sender, EventArgs e)
        {
            dgvInventario.DataSource =
                inventario.ObtenerProximosAVencer();
        }

        // Ver medicamentos vencidos
        private void btnVencidos_Click(
            object sender, EventArgs e)
        {
            dgvInventario.DataSource =
                inventario.ObtenerVencidos();
        }
    }
}
