<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OnlineStore.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Log In</title>
    <Link rel="Stylesheet" href ="StyleCx.css" />  
</head>
<body>
<h1>Online Store Log In</h1>
    <form id="form1" runat="server">

    <div id= "form">
     <asp:Label ID= "lblUser" runat="server" Text="Ususario: " Class="label" AssociatedControlID= "txtUser"></asp:Label>
    <asp:TextBox ID= "txtUser" runat="server" Class= "text"></asp:TextBox>
    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUser" 
     ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio."
      ValidationGroup="Login1">*</asp:RequiredFieldValidator>
    <br />
    <br />
     <asp:Label ID= "lblId" runat="server" Text="Id Usuario: " Class="label" AssociatedControlID= "txtId" ></asp:Label>
    <asp:TextBox ID= "txtId" runat="server" Class= "text" TextMode="Password"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtId" 
     ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
      ValidationGroup="Login1">*</asp:RequiredFieldValidator>

    </div>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión"  CommandName="Login" 
        onclick="btnLogin_Click" ValidationGroup="Login1"/>
    <br />
    <br />
      <asp:Label ID= "lblMensaje" runat="server" ></asp:Label>
    <br />
      
    
    </form>
         
</body>
</html>
