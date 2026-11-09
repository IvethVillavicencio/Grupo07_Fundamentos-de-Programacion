using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using SistemaBotica.Models;
using SistemaBotica.Services;

namespace SistemaBotica.Forms
{
    public class FrmVentas : Form
    {
        private readonly GestionMedicamentos medicamentos;
        private readonly GestionVentas ventas;
        private ComboBox cboMedicamento;
        private NumericUpDown nudCantidad;
        private DataGridView dgvCarrito;
        private Label lblTotal;
        private readonly List<DetalleVenta> carrito = new List<DetalleVenta>();

        public FrmVentas(GestionMedicamentos gestion)
        {
            medicamentos=gestion; ventas=new GestionVentas(gestion);
            Text="Sistema Botica - Gestión de ventas"; StartPosition=FormStartPosition.CenterParent;
            Size=new Size(850,560); MinimumSize=new Size(750,480); Font=new Font("Segoe UI",9F);
            var titulo=new Label { Text="REGISTRO DE VENTAS", Font=new Font("Segoe UI",18F,FontStyle.Bold), ForeColor=Color.FromArgb(28,65,105), AutoSize=true, Location=new Point(25,20) };
            Controls.Add(titulo);
            Controls.Add(new Label { Text="Medicamento",Location=new Point(30,85),AutoSize=true });
            cboMedicamento=new ComboBox { Location=new Point(30,110),Width=430,DropDownStyle=ComboBoxStyle.DropDownList };
            cboMedicamento.DataSource=medicamentos.ObtenerTodos(); cboMedicamento.DisplayMember="Nombre"; cboMedicamento.ValueMember="Codigo"; Controls.Add(cboMedicamento);
            Controls.Add(new Label { Text="Cantidad",Location=new Point(480,85),AutoSize=true });
            nudCantidad=new NumericUpDown { Location=new Point(480,110),Width=90,Minimum=1,Maximum=100000,Value=1 }; Controls.Add(nudCantidad);
            var btnAgregar=new Button { Text="Agregar al carrito",Location=new Point(590,108),Size=new Size(150,30),BackColor=Color.FromArgb(37,99,160),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; btnAgregar.Click+=Agregar; Controls.Add(btnAgregar);
            dgvCarrito=new DataGridView { Location=new Point(30,165),Size=new Size(770,250),ReadOnly=true,AllowUserToAddRows=false,AutoGenerateColumns=false,SelectionMode=DataGridViewSelectionMode.FullRowSelect,BackgroundColor=Color.White };
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText="Código",DataPropertyName="Codigo",Width=100 });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText="Medicamento",DataPropertyName="Medicamento",Width=250 });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText="Cantidad",DataPropertyName="Cantidad",Width=90 });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText="Precio",DataPropertyName="PrecioUnitario",Width=100,DefaultCellStyle={Format="C2"} });
            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn { HeaderText="Subtotal",DataPropertyName="Subtotal",Width=120,DefaultCellStyle={Format="C2"} }); Controls.Add(dgvCarrito);
            lblTotal=new Label { Text="TOTAL: S/ 0.00",Location=new Point(540,435),AutoSize=true,Font=new Font("Segoe UI",14F,FontStyle.Bold),ForeColor=Color.FromArgb(28,65,105) }; Controls.Add(lblTotal);
            var btnQuitar=new Button { Text="Quitar seleccionado",Location=new Point(30,435),Size=new Size(160,32) }; btnQuitar.Click+=Quitar; Controls.Add(btnQuitar);
            var btnConfirmar=new Button { Text="Confirmar venta",Location=new Point(620,475),Size=new Size(180,35),BackColor=Color.FromArgb(30,130,80),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; btnConfirmar.Click+=Confirmar; Controls.Add(btnConfirmar);
        }
        private void Agregar(object sender,EventArgs e)
        {
            Medicamento m=cboMedicamento.SelectedItem as Medicamento;
            int cantidad=(int)nudCantidad.Value;
            if(m==null){MessageBox.Show("No hay medicamentos registrados.");return;}
            int ya=carrito.Where(x=>x.Codigo==m.Codigo).Sum(x=>x.Cantidad);
            if(m.Stock<ya+cantidad){MessageBox.Show("Stock insuficiente. Disponible: "+(m.Stock-ya));return;}
            var existente=carrito.FirstOrDefault(x=>x.Codigo==m.Codigo);
            if(existente==null) carrito.Add(new DetalleVenta{Codigo=m.Codigo,Medicamento=m.Nombre,Cantidad=cantidad,PrecioUnitario=m.Precio}); else existente.Cantidad+=cantidad;
            Refrescar();
        }
        private void Quitar(object sender,EventArgs e)
        { if(dgvCarrito.CurrentRow==null)return; var d=dgvCarrito.CurrentRow.DataBoundItem as DetalleVenta; if(d!=null)carrito.Remove(d); Refrescar(); }
        private void Refrescar(){dgvCarrito.DataSource=null;dgvCarrito.DataSource=carrito.ToList();lblTotal.Text="TOTAL: S/ "+carrito.Sum(x=>x.Subtotal).ToString("N2");}
        private void Confirmar(object sender,EventArgs e)
        {
            string mensaje; if(!ventas.RegistrarVenta(carrito,out mensaje)){MessageBox.Show(mensaje,"Venta",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
            MessageBox.Show(mensaje+"\nTotal: S/ "+carrito.Sum(x=>x.Subtotal).ToString("N2")); carrito.Clear(); Refrescar();
            cboMedicamento.DataSource=null; cboMedicamento.DataSource=medicamentos.ObtenerTodos(); cboMedicamento.DisplayMember="Nombre"; cboMedicamento.ValueMember="Codigo";
        }
    }
}
