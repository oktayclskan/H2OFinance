<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="H2OFinance.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Giris</title>
    <link href="AdminPanel/Css/AdminGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="height:100%">
        <div class="container silver">
            
            <div class="row">
                <img class="girisImg" src="AdminPanel/images/H2oDamlaLogo.png" />
            </div>
            <div class="row">
                <asp:TextBox ID="tb_mail" runat="server" CssClass="inputBox" placeholder="Mail Adresiniz"></asp:TextBox>
            </div>
            <div class="row">
                <asp:TextBox ID="Tb_sifre" runat="server" CssClass="inputBox" placeholder="Şifreniz" TextMode="Password"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtnGiris" runat="server" CssClass="LinkButonGiris" Text="GirisYap" OnClick="lbtnGiris_Click"></asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
