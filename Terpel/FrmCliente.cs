using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace Terpel
{
    public partial class FrmCliente : Form
    {
        Cliente cliente;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ClienteService service = new ClienteService();
            Cliente cliente = MapearCliente();
            string Mensaje = service.Guardar(cliente);
            MessageBox.Show(Mensaje, "MENSAJE DE GUARDADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            LimpiarCajas();

        }

        private Cliente MapearCliente()
        {
            cliente = new Cliente();
            cliente.Cedula = TxtCedula.Text.Trim();
            cliente.Primernombre = TxtPrimerNombre.Text.Trim();
            cliente.Segundonombre = TxtSegundoNombre.Text.Trim();
            cliente.Primerapellido = TxtPrimerApellido.Text.Trim();
            cliente.Segundoapellido = TxtSegundoApellido.Text.Trim();
            cliente.Telefono = TxtTelefono.Text.Trim();
            cliente.Email = TxtEmail.Text.Trim();
            cliente.Marca = TxtMarca.Text.Trim();
            cliente.Modelo = TxtModelo.Text.Trim();
            cliente.Tipodeaceite = TxtTipoAceite.Text.Trim();
            cliente.Referenciaaceite = TxtReferenciaAceite.Text.Trim();
            cliente.Tipofiltro = TxtTipoFiltro.Text.Trim();
            cliente.Referenciafiltro = TxtReferenciaFiltro.Text.Trim();
            return cliente;

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            
            ClienteService service = new ClienteService();

            string cedula = TxtCedula.Text.Trim();
            if (cedula != "")
            {
                Cliente cliente = service.BuscarID(cedula);
                if (cliente != null)
                {
                    TxtCedula.Text = cliente.Cedula;
                    TxtPrimerNombre.Text = cliente.Primernombre;
                    TxtSegundoNombre.Text = cliente.Segundonombre;
                    TxtPrimerApellido.Text = cliente.Primerapellido;
                    TxtSegundoApellido.Text = cliente.Segundoapellido;
                    TxtTelefono.Text = cliente.Telefono;
                    TxtEmail.Text = cliente.Email;
                    TxtMarca.Text = cliente.Marca;
                    TxtModelo.Text = cliente.Modelo;
                    TxtTipoAceite.Text = cliente.Tipodeaceite;
                    TxtReferenciaAceite.Text = cliente.Referenciaaceite;
                    TxtTipoFiltro.Text = cliente.Tipofiltro;
                    TxtReferenciaFiltro.Text = cliente.Referenciafiltro;


                }
                else
                {
                    MessageBox.Show($"La cedula:  {cedula} no esta registrada");
                    LimpiarCajas();
                }
            }
            else
            {
                MessageBox.Show("Digite la cedula");
            }
        }

        private void LimpiarCajas()
        {
            TxtCedula.Text="";
            TxtPrimerNombre.Text = "";
            TxtSegundoNombre.Text = "";
            TxtSegundoApellido.Text = "";
            TxtPrimerApellido.Text = "";
            TxtTelefono.Text = "";
            TxtEmail.Text = "";
            TxtMarca.Text = "";
            TxtModelo.Text = "";
            TxtTipoAceite.Text = "";
            TxtReferenciaAceite.Text = "";
            TxtTipoFiltro.Text = "";
            TxtReferenciaFiltro.Text = "";
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            ClienteService service = new ClienteService();
            cliente = new Cliente();
            cliente.Cedula = TxtCedula.Text.Trim();
            cliente.Primernombre = TxtPrimerNombre.Text.Trim();
            cliente.Segundonombre = TxtSegundoNombre.Text.Trim();
            cliente.Primerapellido = TxtPrimerApellido.Text.Trim();
            cliente.Segundoapellido = TxtSegundoApellido.Text.Trim();
            cliente.Telefono = TxtTelefono.Text.Trim();
            cliente.Email = TxtEmail.Text.Trim();
            cliente.Marca = TxtMarca.Text.Trim();
            cliente.Modelo = TxtModelo.Text.Trim();
            cliente.Tipodeaceite = TxtTipoAceite.Text.Trim();
            cliente.Referenciaaceite = TxtReferenciaAceite.Text.Trim();
            cliente.Tipofiltro = TxtTipoFiltro.Text.Trim();
            cliente.Referenciafiltro = TxtReferenciaFiltro.Text.Trim();
            service.Modificar(cliente);
            MessageBox.Show("SE MODIFICO CORRECTAMENTE EL REGISTRO");
            LimpiarCajas();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            var respuesta = MessageBox.Show("ESTA SEGURO DE ELIMINAR EL CLIENTE", "MENSAJE DE ELIMINADO", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
                if (respuesta == DialogResult.Yes)
                {
                    ClienteService service = new ClienteService();
                    string cedula = TxtCedula.Text.Trim();
                    string mensaje = service.Eliminar(cedula);
                    MessageBox.Show(mensaje);
                }
            LimpiarCajas();

        }
    }
}
