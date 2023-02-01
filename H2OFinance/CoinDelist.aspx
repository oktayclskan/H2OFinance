<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="CoinDelist.aspx.cs" Inherits="H2OFinance.CoinDelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="coinDelist">

        <asp:ListView ID="lv_coinDelist" runat="server">
            <LayoutTemplate>
                <table class="TalepTable" border="1" cellspacing="1" cellpadding="7">
                    <tr>
                        <th>ID</th>
                        <th>Coin Nick</th>
                        <th>İsim</th>
                        <th>Max Arz</th>
                        <th>Fiyat</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("CoinNick") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("Max_Arz") %></td>
                        <td><%# Eval("Fiyat") %></td>
                    </tr>
                
            </ItemTemplate>
        </asp:ListView>

    </div>
</asp:Content>
