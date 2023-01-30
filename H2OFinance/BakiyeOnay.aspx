<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="BakiyeOnay.aspx.cs" Inherits="H2OFinance.BakiyeOnay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="TaleplerSayfası">

        <div class="TalepList">
            <asp:ListView ID="lv_talepler" runat="server" OnItemCommand="lv_talepler_ItemCommand">
                <LayoutTemplate>
                    <table class="TalepTable"  border="1" cellspacing="0" cellpadding="7">
                        <tr>
                            <th>ID</th>
                            <th>Uye No</th>
                            <th>Uye Adı</th>
                            <th>Miktar</th>
                            <th>Talep Tarihi</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("UyeID") %></td>
                        <td><%# Eval("UyeAdi") %></td>
                        <td><%# Eval("Miktar") %></td>
                        <td><%# Eval("TalepTarih") %></td>
                        <td><%# Eval("Durum") %></td>
                        <td>
                            <asp:LinkButton CssClass="OnayBtn" ID="lbtn_onay" runat="server" CommandArgument='<%#Eval("ID") %>'>Onayla</asp:LinkButton>
                            <asp:LinkButton CssClass="RedBtn" ID="lbtn_reddet" runat="server" CommandArgument='<%#Eval("ID") %>'>Reddet</asp:LinkButton>
                        </td>
                        
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
