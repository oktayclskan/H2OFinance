<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="KriptoDuzenle.aspx.cs" Inherits="H2OFinance.KriptoDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="DuzenleContainer">
        <div class="titleHeader">
            <h1>Kripto Duzenle</h1>
        </div>
        <div style="padding-top: 50px;" class="row">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kripto Düzenleme işlemi Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label>Isim</label>
                <br />
                <asp:TextBox ID="kriptoIsim" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>

        </div>
        <div class="row">
            <label>CoinNick</label>
            <br />
            <asp:TextBox ID="kriptoNick" runat="server" CssClass="inputBox"></asp:TextBox>

        </div>
        <div class="row">
            <label>Max Arz</label>
            <br />
            <asp:TextBox ID="tb_MaxArz" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Resim Ekle</label>
            <br />
            <asp:FileUpload ID="fu_resim" runat="server" CssClass="resimEkle"></asp:FileUpload>
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_Guncelle" runat="server" Text="Güncelle" CssClass="EkleBtn" OnClick="lbtn_Guncelle_Click"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
