using Datos.Admin;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebVentas
{
    public partial class frmVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mostrarVendedores();
            }
        }

        private void mostrarVendedores()
        {
            gridVendedor.DataSource = AdmVendedor.Listar();
            gridVendedor.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarVendedor();
        }

        private void guardarVendedor()
        {
            Vendedor vendedor = new Vendedor(txtNombre.Text, txtApellido.Text, txtDNI.Text, Decimal.Parse(txtComision.Text));

            int filasAfectadas = AdmVendedor.Insertar(vendedor);

            if (filasAfectadas > 0)
            {
                mostrarVendedores();
                borrarCampos();
            }
        }

        private void borrarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtComision.Text = string.Empty;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            modificarVendedor();
        }

        private void modificarVendedor()
        {
            Vendedor vendedorModificado = new Vendedor(int.Parse(txtId.Text), txtNombre.Text, txtApellido.Text, txtDNI.Text, Decimal.Parse(txtComision.Text));

            int filasAfectadas = AdmVendedor.Modificar(vendedorModificado);

            if (filasAfectadas > 0)
            {
                mostrarVendedores();
                borrarCampos();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarVendedor();
        }

        private void eliminarVendedor()
        {
            int vendedorEliminar = int.Parse(txtId.Text);

            int filasAfectadas = AdmVendedor.Eliminar(vendedorEliminar);

            if (filasAfectadas > 0)
            {
                mostrarVendedores();
                borrarCampos();
            }
        }

        protected void btnMostrarPorId_Click(object sender, EventArgs e)
        {
            mostrarVendedorPorId();
        }

        private void mostrarVendedorPorId()
        {
            int idVendedor = int.Parse(txtId.Text);

            gridVendedor.DataSource = AdmVendedor.TraerPorId(idVendedor);
            gridVendedor.DataBind();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            mostrarVendedores();
        }

        protected void btnBuscarPorComision_Click(object sender, EventArgs e)
        {
            mostrarVendedorPorComision();
        }

        private void mostrarVendedorPorComision()
        {
            int comisionVendedor = int.Parse(txtBuscarPorComision.Text);

            gridVendedor.DataSource = AdmVendedor.traerVendedoresPorComision(comisionVendedor);
            gridVendedor.DataBind();
        }
    }
}