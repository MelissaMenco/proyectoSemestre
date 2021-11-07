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
    public partial class FrmConsultaCliente : Form
    {

        public FrmConsultaCliente()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            LlenarTabla();
        }
        private void LlenarTabla()
        {
            DgvClientes.DataSource = null;
            DgvClientes.DataSource = ClienteService.ConsultarTodos();
        }

    }
}
