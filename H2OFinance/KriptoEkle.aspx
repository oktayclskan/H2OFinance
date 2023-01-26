<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="KriptoEkle.aspx.cs" Inherits="H2OFinance.KriptoEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="EkleContainer">
        <div class="titleHeader">
            <h1>Kripto Ekle</h1>
        </div>
        <div style="padding-top: 150px;" class="row">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kripto Ekleme işlemi Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:TextBox ID="kriptoIsim" runat="server" placeholder="İsmini giriniz" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="kriptoNick" runat="server" placeholder="Kısaltmasını girisniz" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_MaxArz" runat="server" placeholder="Max Arz giriniz" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_Ekle" runat="server" Text="Ekle" CssClass="EkleBtn" OnClick="lbtn_Ekle_Click"></asp:LinkButton>
        </div>


    </div>



</asp:Content>
