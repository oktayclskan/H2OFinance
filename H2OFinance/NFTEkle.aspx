<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="NftEkle.aspx.cs" Inherits="H2OFinance.NftEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="EkleContainer">
        <div class="titleHeader">
            <h1>NFT Ekle</h1>
        </div>

        <div style="padding-top: 120px;" class="row">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kripto Ekleme işlemi Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:TextBox ID="tb_NFTIsim" runat="server" placeholder="İsmini giriniz" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_fiyat" runat="server" placeholder="Fiyatını Belirtiniz" CssClass="inputBox"></asp:TextBox>
        </div>


        <div class="row">
            <label>Resim Ekle</label>
            <br />
            <asp:FileUpload ID="fu_resim" runat="server" CssClass="resimEkle"></asp:FileUpload>
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_NftEkle" runat="server" Text="Ekle" CssClass="EkleBtn" OnClick="lbtn_NftEkle_Click"></asp:LinkButton>
        </div>
    </div>

</asp:Content>
