namespace laboratoriPizzeriaExpress
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnNuevoPedido;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListBox lstPedidos;
        private System.Windows.Forms.ListBox lstBitacora;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblContador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        	this.txtCliente = new System.Windows.Forms.TextBox();
        	this.btnNuevoPedido = new System.Windows.Forms.Button();
        	this.btnEntregar = new System.Windows.Forms.Button();
        	this.btnDeshacer = new System.Windows.Forms.Button();
        	this.btnLimpiar = new System.Windows.Forms.Button();
        	this.lstPedidos = new System.Windows.Forms.ListBox();
        	this.lstBitacora = new System.Windows.Forms.ListBox();
        	this.lblEstado = new System.Windows.Forms.Label();
        	this.lblContador = new System.Windows.Forms.Label();
        	this.chkPremium = new System.Windows.Forms.CheckBox();
        	this.lblColaPedidos = new System.Windows.Forms.Label();
        	this.lblbitacoradeacciones = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// txtCliente
        	// 
        	this.txtCliente.Location = new System.Drawing.Point(16, 15);
        	this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
        	this.txtCliente.Name = "txtCliente";
        	this.txtCliente.Size = new System.Drawing.Size(265, 22);
        	this.txtCliente.TabIndex = 0;
        	// 
        	// btnNuevoPedido
        	// 
        	this.btnNuevoPedido.Location = new System.Drawing.Point(435, 9);
        	this.btnNuevoPedido.Margin = new System.Windows.Forms.Padding(4);
        	this.btnNuevoPedido.Name = "btnNuevoPedido";
        	this.btnNuevoPedido.Size = new System.Drawing.Size(133, 28);
        	this.btnNuevoPedido.TabIndex = 1;
        	this.btnNuevoPedido.Text = "Nuevo Pedido";
        	this.btnNuevoPedido.UseVisualStyleBackColor = true;
        	this.btnNuevoPedido.Click += new System.EventHandler(this.BtnNuevoPedido_Click);
        	// 
        	// btnEntregar
        	// 
        	this.btnEntregar.Location = new System.Drawing.Point(576, 9);
        	this.btnEntregar.Margin = new System.Windows.Forms.Padding(4);
        	this.btnEntregar.Name = "btnEntregar";
        	this.btnEntregar.Size = new System.Drawing.Size(133, 28);
        	this.btnEntregar.TabIndex = 2;
        	this.btnEntregar.Text = "Entregar";
        	this.btnEntregar.UseVisualStyleBackColor = true;
        	this.btnEntregar.Click += new System.EventHandler(this.BtnEntregar_Click);
        	// 
        	// btnDeshacer
        	// 
        	this.btnDeshacer.Location = new System.Drawing.Point(717, 9);
        	this.btnDeshacer.Margin = new System.Windows.Forms.Padding(4);
        	this.btnDeshacer.Name = "btnDeshacer";
        	this.btnDeshacer.Size = new System.Drawing.Size(133, 28);
        	this.btnDeshacer.TabIndex = 3;
        	this.btnDeshacer.Text = "Deshacer";
        	this.btnDeshacer.UseVisualStyleBackColor = true;
        	this.btnDeshacer.Click += new System.EventHandler(this.BtnDeshacer_Click);
        	// 
        	// btnLimpiar
        	// 
        	this.btnLimpiar.Location = new System.Drawing.Point(857, 10);
        	this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
        	this.btnLimpiar.Name = "btnLimpiar";
        	this.btnLimpiar.Size = new System.Drawing.Size(133, 28);
        	this.btnLimpiar.TabIndex = 4;
        	this.btnLimpiar.Text = "Limpiar todo";
        	this.btnLimpiar.UseVisualStyleBackColor = true;
        	this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
        	// 
        	// lstPedidos
        	// 
        	this.lstPedidos.FormattingEnabled = true;
        	this.lstPedidos.ItemHeight = 16;
        	this.lstPedidos.Location = new System.Drawing.Point(16, 94);
        	this.lstPedidos.Margin = new System.Windows.Forms.Padding(4);
        	this.lstPedidos.Name = "lstPedidos";
        	this.lstPedidos.Size = new System.Drawing.Size(399, 260);
        	this.lstPedidos.TabIndex = 5;
        	// 
        	// lstBitacora
        	// 
        	this.lstBitacora.FormattingEnabled = true;
        	this.lstBitacora.ItemHeight = 16;
        	this.lstBitacora.Location = new System.Drawing.Point(427, 94);
        	this.lstBitacora.Margin = new System.Windows.Forms.Padding(4);
        	this.lstBitacora.Name = "lstBitacora";
        	this.lstBitacora.Size = new System.Drawing.Size(423, 260);
        	this.lstBitacora.TabIndex = 6;
        	this.lstBitacora.SelectedIndexChanged += new System.EventHandler(this.LstBitacoraSelectedIndexChanged);
        	// 
        	// lblEstado
        	// 
        	this.lblEstado.AutoSize = true;
        	this.lblEstado.Location = new System.Drawing.Point(16, 388);
        	this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lblEstado.Name = "lblEstado";
        	this.lblEstado.Size = new System.Drawing.Size(124, 17);
        	this.lblEstado.TabIndex = 7;
        	this.lblEstado.Text = "Listo para trabajar";
        	// 
        	// lblContador
        	// 
        	this.lblContador.AutoSize = true;
        	this.lblContador.Location = new System.Drawing.Point(16, 418);
        	this.lblContador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lblContador.Name = "lblContador";
        	this.lblContador.Size = new System.Drawing.Size(35, 17);
        	this.lblContador.TabIndex = 8;
        	this.lblContador.Text = "0 | 0";
        	// 
        	// chkPremium
        	// 
        	this.chkPremium.Location = new System.Drawing.Point(288, 14);
        	this.chkPremium.Name = "chkPremium";
        	this.chkPremium.Size = new System.Drawing.Size(140, 24);
        	this.chkPremium.TabIndex = 9;
        	this.chkPremium.Text = "Cliente Premiun";
        	this.chkPremium.UseVisualStyleBackColor = true;
        	this.chkPremium.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
        	// 
        	// lblColaPedidos
        	// 
        	this.lblColaPedidos.Location = new System.Drawing.Point(125, 56);
        	this.lblColaPedidos.Name = "lblColaPedidos";
        	this.lblColaPedidos.Size = new System.Drawing.Size(196, 23);
        	this.lblColaPedidos.TabIndex = 10;
        	this.lblColaPedidos.Text = "🍕 Cola de Pedidos";
        	// 
        	// lblbitacoradeacciones
        	// 
        	this.lblbitacoradeacciones.Location = new System.Drawing.Point(549, 56);
        	this.lblbitacoradeacciones.Name = "lblbitacoradeacciones";
        	this.lblbitacoradeacciones.Size = new System.Drawing.Size(192, 23);
        	this.lblbitacoradeacciones.TabIndex = 11;
        	this.lblbitacoradeacciones.Text = "📖 Bitácora de Acciones";
        	this.lblbitacoradeacciones.Click += new System.EventHandler(this.LblbitacoradeaccionesClick);
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(1002, 455);
        	this.Controls.Add(this.lblbitacoradeacciones);
        	this.Controls.Add(this.lblColaPedidos);
        	this.Controls.Add(this.chkPremium);
        	this.Controls.Add(this.lblContador);
        	this.Controls.Add(this.lblEstado);
        	this.Controls.Add(this.lstBitacora);
        	this.Controls.Add(this.lstPedidos);
        	this.Controls.Add(this.btnLimpiar);
        	this.Controls.Add(this.btnDeshacer);
        	this.Controls.Add(this.btnEntregar);
        	this.Controls.Add(this.btnNuevoPedido);
        	this.Controls.Add(this.txtCliente);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "MainForm";
        	this.Text = "Pizzería Campus Express";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label lblbitacoradeacciones;
        private System.Windows.Forms.Label lblColaPedidos;
        private System.Windows.Forms.CheckBox chkPremium;
    }
}