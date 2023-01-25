<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="KriptoEkle.aspx.cs" Inherits="H2OFinance.KriptoEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="EkleContainer">
 
        <div style="padding-top:150px;" class="row">
            <asp:TextBox ID="kriptoIsim" runat="server" placeholder="Kripto ismini giriniz" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="kriptoNick" runat="server" placeholder="Kripto Nick giriniz" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="MaxArz" runat="server" placeholder="Max Arz" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_Ekle" runat="server" Text="Ekle" CssClass="EkleBtn" OnClick="lbtn_Ekle_Click"></asp:LinkButton>
        </div>
    </div>



</asp:Content>
