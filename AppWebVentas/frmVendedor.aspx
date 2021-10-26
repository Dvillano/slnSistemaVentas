<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmVendedor.aspx.cs" Inherits="AppWebVentas.frmVendedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        Nombre <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        Apellido <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        DNI <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
        Comision <asp:TextBox ID="txtComision" runat="server"></asp:TextBox>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <br />
        <br />
        Buscar por Id: <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <asp:Button ID="btnMostrarPorId" runat="server" Text="Mostrar" OnClick="btnMostrarPorId_Click" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <br />
        <br />
        Buscar por Comision:  <asp:TextBox ID="txtBuscarPorComision" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscarPorComision" runat="server" Text="Mostrar" OnClick="btnBuscarPorComision_Click" />
        <br />
        <br />
        <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar Todos" OnClick="btnMostrarTodos_Click" />
        <asp:GridView ID="gridVendedor" runat="server"></asp:GridView>
    </form>
</body>
</html>
