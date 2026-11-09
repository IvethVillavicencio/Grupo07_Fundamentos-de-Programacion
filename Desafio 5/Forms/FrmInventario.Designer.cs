namespace SistemaBotica.Forms
{
    partial class FrmInventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnStockBajo = new System.Windows.Forms.Button();
            this.btnProximos = new System.Windows.Forms.Button();
            this.btnVencidos = new System.Windows.Forms.Button();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(247, 26);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(104, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Control de inventario";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(77, 52);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(96, 13);
            this.lblValorTotal.TabIndex = 1;
            this.lblValorTotal.Text = "Valor total: S/ 0.00";
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(66, 87);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(88, 23);
            this.btnTodos.TabIndex = 2;
            this.btnTodos.Text = "Ver inventario";
            this.btnTodos.UseVisualStyleBackColor = true;
            // 
            // btnStockBajo
            // 
            this.btnStockBajo.Location = new System.Drawing.Point(160, 87);
            this.btnStockBajo.Name = "btnStockBajo";
            this.btnStockBajo.Size = new System.Drawing.Size(75, 23);
            this.btnStockBajo.TabIndex = 3;
            this.btnStockBajo.Text = "Stock bajo";
            this.btnStockBajo.UseVisualStyleBackColor = true;
            // 
            // btnProximos
            // 
            this.btnProximos.Location = new System.Drawing.Point(41, 116);
            this.btnProximos.Name = "btnProximos";
            this.btnProximos.Size = new System.Drawing.Size(113, 23);
            this.btnProximos.TabIndex = 4;
            this.btnProximos.Text = "Próximos a vencer";
            this.btnProximos.UseVisualStyleBackColor = true;
            // 
            // btnVencidos
            // 
            this.btnVencidos.Location = new System.Drawing.Point(160, 116);
            this.btnVencidos.Name = "btnVencidos";
            this.btnVencidos.Size = new System.Drawing.Size(75, 23);
            this.btnVencidos.TabIndex = 5;
            this.btnVencidos.Text = "Vencidos";
            this.btnVencidos.UseVisualStyleBackColor = true;
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.Nombre,
            this.Stock,
            this.Precio,
            this.Fecha});
            this.dgvInventario.Location = new System.Drawing.Point(12, 181);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(543, 150);
            this.dgvInventario.TabIndex = 6;
            // 
            // Código
            // 
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "LISTADO DE MEDICAMENTOS";
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.btnVencidos);
            this.Controls.Add(this.btnProximos);
            this.Controls.Add(this.btnStockBajo);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmInventario";
            this.Text = "FrmInventario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnStockBajo;
        private System.Windows.Forms.Button btnProximos;
        private System.Windows.Forms.Button btnVencidos;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Label label1;
    }
}