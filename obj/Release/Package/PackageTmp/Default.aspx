<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineStore.Defaul" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Store</title>
    <Link rel="Stylesheet" href ="Hoja.css" /> 
  
</head>

<body>

<form id="form" runat="server">
   <h2>Bienvenido:  <asp:Label ID="lblClienteLog" runat="server"></asp:Label> <asp:Button ID="btnSalir" runat="server" Text="Log off" 
           onclick="btnSalir_Click" Class="boton" /></h2>
   
   <h1>Productos Disponibles
    </h1>
    <br />
     <asp:Button ID="btnNuevoPedido" runat="server" Text="Nuevo Pedido" 
        onclick="btnNuevoPedido_Click"  Class="boton" />
          <br />
    
    <div ID="dep">

<asp:Label ID="lblDepartamentos" runat="server" Text="Departamentos" AssociatedControlID= "ddlDepartamentos" Class="label"></asp:Label>
<asp:DropDownList ID="ddlDepartamentos" runat="server" AutoPostBack="True" 
    onselectedindexchanged="ddlDepartamentos_SelectedIndexChanged" 
    BackColor="#1C2833" Font-Bold= "true" Font-Overline= "false" 
    Font-Size= "14pt" ForeColor= "White"></asp:DropDownList>

   </div>
<br /> 

   <div id= "inventario">

<h3>Inventario</h3>
<asp:ListBox ID="lsbProductos" runat="server" 
    onselectedindexchanged="lsbProductos_SelectedIndexChanged"
    BackColor="#1C2833" Font-Bold= "true" Font-Overline= "false" 
    Font-Size= "20pt" ForeColor= "White" Width="312px"></asp:ListBox>

<asp:Label ID="Label4" runat="server" Text="Precio Item: " Class="label"></asp:Label>
<asp:Label ID="lblPrecio" runat="server" Class="labelTot"></asp:Label>
<asp:Label ID="Label2" runat="server" Text=" $" Class="labelTot"></asp:Label>
<br />

</div>
<br />


<div id="agregar">
<asp:Label ID="lblCant" runat="server" AssociatedControlID="txtCantidad" Text="Cantidad" Class="label" ></asp:Label>
<asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
<asp:Button ID="btnAgregar" runat="server" Text="Agregar item" 
       onclick="btnAgregar_Click" Class="boton" />
<asp:Button ID="btnCancelar" runat="server" Text="Cancelar"  onclick="btnCancelar_Click" Class="boton" />
<br />
<br />

 <asp:Label ID="lblItemAgregado" runat="server" Text= "Producto agregado con exito"></asp:Label>
</div>

<br />
<div id= "pedido">

 <asp:Button ID="btnPedido" runat="server" Text="Realizar Pedido" onclick="btnPedido_Click" Class="boton" />
    <br />
    <br />
    <asp:Label ID="lblPedido" runat="server" AssociatedControlID="btnPedido" 
    Text="Pedido Nro.:" Class="label"></asp:Label>
<asp:Label ID="lblNumPedido" runat="server" AssociatedControlID="txtCantidad"></asp:Label>

</div>

<br />
<div id= "carrito">
    
<h3>Carrito</h3>
<br />
<asp:GridView ID="dgvCarrito" runat="server" Font-Size="14pt" 
       AutoGenerateColumns="False" EnableModelValidation="True" Height="214px" 
       Width="567px" CellPadding="4" GridLines="None" ForeColor="#333333">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Id_Pedido" HeaderText="Pedido Nro" />
        <asp:BoundField DataField="Id_Prod" HeaderText="Id Item" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Cantidad_Item" HeaderText="Catidad" />
        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
    </Columns>
   
    <EditRowStyle BackColor="#7C6F57" />
   
    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
   
</asp:GridView>

</div>
<br />

<div id= "totales">

<asp:Label ID="lblTituloTotalItems" runat="server" 
    Text="Total Items:" Class="label"></asp:Label>
<asp:Label ID="lblTotItems" runat="server" AssociatedControlID="txtCantidad" Class="labelTot"></asp:Label>
   <br />
   <br /> 
   <asp:Label ID="lblTotalPedido" runat="server" AssociatedControlID="btnPedido" 
    Text="Total Pedido:" Class="label"></asp:Label>
<asp:Label ID="lblTotPedido" runat="server" AssociatedControlID="txtCantidad" Class="labelTot"></asp:Label>
 <br />
   <br /> 
   <asp:Label ID="lblMesajePedido" runat="server" Class="labelTot"></asp:Label>

</div>

    
   
    </form>

   
   
</body>
</html>
