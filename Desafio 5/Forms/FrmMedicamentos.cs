
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using SistemaBotica.Models;
using SistemaBotica.Services;

namespace SistemaBotica.Forms
{
    public partial class FrmMedicamentos : Form
    {
        // Conectar con la gestion de medicamentos
        private GestionMedicamentos gestion =
            new GestionMedicamentos();
        private Button btnVentas;

        public FrmMedicamentos()
        {
            InitializeComponent();

            // Boton adicional para abrir ventas
            btnVentas = new Button();
            btnVentas.Name = "btnVentas";
            btnVentas.Text = "Gestionar ventas";
            btnVentas.Size = new System.Drawing.Size(130, 32);
            btnVentas.Location = new System.Drawing.Point(btnInventario.Right + 10, btnInventario.Top);
            Controls.Add(btnVentas);
            btnVentas.Click += btnVentas_Click;

            // Configurar la tabla
            dgvMedicamentos.Columns.Clear();
            dgvMedicamentos.AutoGenerateColumns = true;
            dgvMedicamentos.ReadOnly = true;
            dgvMedicamentos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvMedicamentos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvMedicamentos.MultiSelect = false;

            // Conectar los botones
            btnRegistrar.Click += btnRegistrar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            // Botón para abrir el inventario
            btnInventario.Click += btnInventario_Click;
            dgvMedicamentos.CellClick +=

                dgvMedicamentos_CellClick;

            MostrarMedicamentos(gestion.ObtenerTodos());
        }

        // Obtener los datos del formulario
        private Medicamento ObtenerDatos()
        {
            decimal precio;
            int stock;

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el codigo y nombre del medicamento.");

                return null;
            }

            if (!decimal.TryParse(
                txtPrecio.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio valido.");
                return null;
            }

            if (!int.TryParse(txtStock.Text, out stock) ||
                stock < 0)
            {
                MessageBox.Show("Ingrese un stock valido.");
                return null;
            }

            return new Medicamento
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Categoria = txtCategoria.Text.Trim(),
                Laboratorio = txtLaboratorio.Text.Trim(),
                Precio = precio,
                Stock = stock,
                FechaVencimiento = dtpVencimiento.Value.Date
            };
        }

        // Mostrar medicamentos en la tabla
        private void MostrarMedicamentos(
            List<Medicamento> lista)
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = lista;
        }

        // Registrar medicamento
        private void btnRegistrar_Click(
            object sender, EventArgs e)
        {
            Medicamento nuevo = ObtenerDatos();

            if (nuevo == null)
                return;

            if (gestion.RegistrarMedicamento(nuevo))
            {
                MessageBox.Show(
                    "Medicamento registrado correctamente.");

                MostrarMedicamentos(gestion.ObtenerTodos());
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(
                    "El codigo del medicamento ya existe.");
            }
        }

        // Buscar medicamento
        private void btnBuscar_Click(
            object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                Medicamento encontrado =
                    gestion.BuscarPorCodigo(txtCodigo.Text.Trim());

                if (encontrado != null)
                {
                    MostrarMedicamentos(
                        new List<Medicamento> { encontrado });
                }
                else
                {
                    MessageBox.Show("Medicamento no encontrado.");
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                List<Medicamento> resultados =
                    gestion.BuscarPorNombre(txtNombre.Text.Trim());

                MostrarMedicamentos(resultados);

                if (resultados.Count == 0)
                    MessageBox.Show("No se encontraron resultados.");
            }
            else
            {
                MessageBox.Show(
                    "Ingrese un codigo o nombre para buscar.");
            }
        }

        // Actualizar medicamento
        private void btnActualizar_Click(
            object sender, EventArgs e)
        {
            Medicamento nuevosDatos = ObtenerDatos();

            if (nuevosDatos == null)
                return;

            bool actualizado =
                gestion.ActualizarMedicamento(
                    nuevosDatos.Codigo,
                    nuevosDatos);

            if (actualizado)
            {
                MessageBox.Show(
                    "Medicamento actualizado correctamente.");

                MostrarMedicamentos(gestion.ObtenerTodos());
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Medicamento no encontrado.");
            }
        }

        // Eliminar medicamento
        private void btnEliminar_Click(
            object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese el codigo del medicamento.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este medicamento?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (gestion.EliminarMedicamento(codigo))
                {
                    MessageBox.Show("Medicamento eliminado.");

                    MostrarMedicamentos(gestion.ObtenerTodos());
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Medicamento no encontrado.");
                }
            }
        }

        // Limpiar campos
        private void btnLimpiar_Click(
            object sender, EventArgs e)
        {
            LimpiarCampos();
            MostrarMedicamentos(gestion.ObtenerTodos());
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            txtLaboratorio.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            dtpVencimiento.Value = DateTime.Today;

            txtCodigo.Focus();
        }

        // Seleccionar un medicamento desde la tabla
        private void dgvMedicamentos_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Medicamento seleccionado =
                dgvMedicamentos.Rows[e.RowIndex]
                .DataBoundItem as Medicamento;

            if (seleccionado == null)
                return;

            txtCodigo.Text = seleccionado.Codigo;
            txtNombre.Text = seleccionado.Nombre;
            txtCategoria.Text = seleccionado.Categoria;
            txtLaboratorio.Text = seleccionado.Laboratorio;
            txtPrecio.Text = seleccionado.Precio.ToString();
            txtStock.Text = seleccionado.Stock.ToString();
            dtpVencimiento.Value =
                seleccionado.FechaVencimiento;
        }

        // Abrir formulario de inventario
        private void btnVentas_Click(object sender, EventArgs e)
        {
            using (FrmVentas ventana = new FrmVentas(gestion))
                ventana.ShowDialog();
            MostrarMedicamentos(gestion.ObtenerTodos());
        }

        private void btnInventario_Click(
            object sender, EventArgs e)
        {
            using (FrmInventario ventana =
                new FrmInventario(gestion))
            {
                ventana.ShowDialog();
            }
        }
    }
}
