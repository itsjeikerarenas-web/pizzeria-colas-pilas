/*
 * Pizzería Campus Express - Gestión de pedidos con Queue y Stack
 * Compatible con SharpDevelop 4.4 / .NET Framework 2.0+
 */
/*
  Preguntas a responder del GIT:
  
  ¿Por qué un sistema de delivery usa Queue para los pedidos pero Stack para la bitácora? ¿Qué problema surgiría si invertimos las estructuras?
  
  Uso una fila para atender a los clientes en orden de llegada y una bitácora para poder deshacer mi último paso. Si los invierto,
  terminaría atendiendo al último en llegar y, al intentar corregir un error, borraría lo más viejo en vez de lo más reciente.
  
  ¿Por qué es obligatorio verificar Count == 0 antes de Dequeue() o Pop()? ¿Qué ocurre en ejecución si se omite?
  
  Para asegurarme de que hay algo guardado antes de intentar sacarlo. Si no reviso y está vacío, mi programa se confunde y se cierra de golpe.
  
  ¿En el método Deshacer, ¿por qué es necesario analizar el texto con .StartsWith() antes de revertir? ¿Qué error lógico evitaría esto?
  
  Lo necesito para saber exactamente qué fue lo último que hice y así poder revertirlo sin aplicarme una solución equivocada.
  
  ¿Qué ventaja tiene entregar mediante Fork + Pull Request en lugar de un archivo comprimido? ¿Cómo facilita la la retroalimentación?
  
  Porque me permite mostrar de forma clara qué agregué o cambié paso a paso, haciendo que sea mucho más fácil que me revisen el trabajo 
  y me dejen comentarios directos.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace laboratoriPizzeriaExpress
{
    public partial class MainForm : Form
    {
        //Colecciones principales: FIFO para pedidos, LIFO para bitácora
        private Queue<string> colaPedidos = new Queue<string>();
        
        //Creamos una segunda cola exclusiva para los clientes VIP
        private Queue<string> colaPremium = new Queue<string>();
        
        private Stack<string> pilaBitacora = new Stack<string>();

        public MainForm()
        {
            InitializeComponent();
            ActualizarUI();
        }

        //PASO 1: Nuevo pedido (FIFO entrada)
        private void BtnNuevoPedido_Click(object sender, EventArgs e)
        {
            string cliente = txtCliente.Text.Trim();

            //Validar entrada
            if (string.IsNullOrEmpty(cliente))
            {
                MessageBox.Show("Por favor ingresa el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Verificamos si el checkbox de Premium está marcado
            bool esPremium = chkPremium.Checked;

            if (esPremium)
            {
                //Lógica si es VIP: Va a la cola premium y se registra distinto en la bitácora
                colaPremium.Enqueue(cliente);
                pilaBitacora.Push(string.Format("PEDIDO PREMIUM: {0}", cliente));
                lblEstado.Text = string.Format("PEDIDO PREMIUM registrado para {0}", cliente);
            }
            else
            {
                // Lógica normal: Va a la cola estándar
                colaPedidos.Enqueue(cliente);
                pilaBitacora.Push(string.Format("PEDIDO: {0}", cliente));
                lblEstado.Text = string.Format("✅ Pedido normal registrado para {0}", cliente);
            }

            // Limpiar campo, desmarcar el checkbox de premium por defecto y actualizar
            txtCliente.Clear();
            chkPremium.Checked = false; 
            ActualizarUI();
        }

        // PASO 2: Entregar pedido (FIFO salida)
        private void BtnEntregar_Click(object sender, EventArgs e)
        {
            //Modificamos la entrega para darle prioridad absoluta a la cola Premium
            if (colaPremium.Count > 0)
            {
                // Si hay alguien en la cola VIP, lo sacamos a él primero
                string clienteVIP = colaPremium.Dequeue();
                pilaBitacora.Push(string.Format("ENTREGADO PREMIUM: {0}", clienteVIP));
                lblEstado.Text = string.Format("🍕 Pedido VIP entregado a {0}", clienteVIP);
            }
            else if (colaPedidos.Count > 0)
            {
                // Si no hay VIP, atendemos a la cola normal
                string clienteNormal = colaPedidos.Dequeue();
                pilaBitacora.Push(string.Format("ENTREGADO: {0}", clienteNormal));
                lblEstado.Text = string.Format("🍕 Pedido entregado a {0}", clienteNormal);
            }
            else
            {
                // Si ambas colas están vacías
                lblEstado.Text = string.Format("❌ No hay pedidos pendientes.");
                return; // Salimos para no actualizar la UI en vano
            }

            ActualizarUI();
        }

        // PASO 3: Deshacer última acción (LIFO + lógica de reversión)
        private void BtnDeshacer_Click(object sender, EventArgs e)
        {
            if (pilaBitacora.Count == 0)
            {
                lblEstado.Text = string.Format("📭 No hay acciones para deshacer.");
                return;
            }

            string ultimaAccion = pilaBitacora.Pop();

            //Agregamos las validaciones para deshacer acciones Premium
            if (ultimaAccion.StartsWith("PEDIDO PREMIUM:"))
            {
                string nombre = ultimaAccion.Replace("PEDIDO PREMIUM: ", "");
                
                // Reconstruimos la cola Premium saltándonos a esta persona
                string[] temporal = colaPremium.ToArray();
                colaPremium.Clear();
                foreach (string p in temporal)
                {
                    if (p != nombre)
                        colaPremium.Enqueue(p);
                }
                lblEstado.Text = string.Format("↩️ Se deshizo el pedido VIP de {0}", nombre);
            }
            else if (ultimaAccion.StartsWith("ENTREGADO PREMIUM:"))
            {
                string nombre = ultimaAccion.Replace("ENTREGADO PREMIUM: ", "");
                
                // Lo volvemos a meter de primero en la cola VIP
                List<string> listaTemp = new List<string>();
                listaTemp.Add(nombre); 
                listaTemp.AddRange(colaPremium.ToArray()); 
                
                colaPremium.Clear();
                foreach (string p in listaTemp)
                {
                    colaPremium.Enqueue(p);
                }
                lblEstado.Text = string.Format("↩️ Se deshizo la entrega VIP a {0}", nombre);
            }
            // Lógica original para clientes normales
            else if (ultimaAccion.StartsWith("PEDIDO:"))
            {
                string nombre = ultimaAccion.Replace("PEDIDO: ", "");
                string[] temporal = colaPedidos.ToArray();
                colaPedidos.Clear();
                foreach (string p in temporal)
                {
                    if (p != nombre)
                        colaPedidos.Enqueue(p);
                }
                lblEstado.Text = string.Format("↩️ Se deshizo el pedido de {0}", nombre);
            }
            else if (ultimaAccion.StartsWith("ENTREGADO:"))
            {
                string nombre = ultimaAccion.Replace("ENTREGADO: ", "");
                List<string> listaTemp = new List<string>();
                listaTemp.Add(nombre); 
                listaTemp.AddRange(colaPedidos.ToArray()); 
               
                colaPedidos.Clear();
                foreach (string p in listaTemp)
                {
                    colaPedidos.Enqueue(p);
                }
                lblEstado.Text = string.Format("↩️ Se deshizo la entrega a {0}", nombre);
            }
            else
            {
                lblEstado.Text = string.Format("⚠️ Acción desconocida en bitácora.");
            }

            ActualizarUI();
        }

        //PASO 4: Limpiar todo (reiniciar sistema)
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            //limpiamos también la cola premium
            colaPremium.Clear();
            colaPedidos.Clear();
            pilaBitacora.Clear();
            lblEstado.Text = string.Format("🧹 Sistema reiniciado.");
            ActualizarUI();
        }

        //Sincronizar la interfaz con el estado actual
        private void ActualizarUI()
        {
            // Limpiar listas visuales
            lstPedidos.Items.Clear();
            lstBitacora.Items.Clear();

            //Mostrar primero a los de la cola Premium con un indicativo visual(VIP)
            foreach (string p in colaPremium)
                lstPedidos.Items.Add("[VIP] " + p);

            //mostrar la cola de pedidos normales
            foreach (string p in colaPedidos)
                lstPedidos.Items.Add(p);

            // Mensaje si ambas colas están vacías
            if (colaPedidos.Count == 0 && colaPremium.Count == 0)
                lstPedidos.Items.Add("(Sin pedidos pendientes)");

            // Mostrar bitácora
            foreach (string accion in pilaBitacora)
                lstBitacora.Items.Add(accion);

            if (pilaBitacora.Count == 0)
                lstBitacora.Items.Add("(Sin acciones registradas)");

            // Actualizar contador sumando ambas colas
            int totalPedidos = colaPedidos.Count + colaPremium.Count;
            lblContador.Text = string.Format("Pedidos Totales: {0} | Bitácora: {1}",
                totalPedidos, pilaBitacora.Count);
        }

        void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            
        }
         
        void LstBitacoraSelectedIndexChanged(object sender, EventArgs e)
        {
        	
        }
        
        
        
        void LblbitacoradeaccionesClick(object sender, EventArgs e)
        {
        	
        }
        
        
    }
}﻿