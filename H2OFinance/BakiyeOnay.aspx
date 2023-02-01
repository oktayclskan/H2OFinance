<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="BakiyeOnay.aspx.cs" Inherits="H2OFinance.BakiyeOnay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="TaleplerSayfası">
        <div class="btnlar">
            <asp:LinkButton CssClass="OnayBtn" ID="lbtn_onay" runat="server" CommandArgument='<%#Eval("ID") %>' OnClick="lbtn_onay_Click">Onaylananlar</asp:LinkButton>
            <asp:LinkButton CssClass="RedBtn" ID="lbtn_reddet" runat="server" CommandArgument='<%#Eval("ID") %>' OnClick="lbtn_reddet_Click">Reddetilenler</asp:LinkButton>
            <asp:LinkButton CssClass="onayBekleyenler" ID="lbtn_onayBekleyen" runat="server" OnClick="lbtn_onayBekleyen_Click">Onay Bekleyenler</asp:LinkButton>
        </div>
        <div class="TalepList">
            <asp:ListView ID="lv_bekleyen" runat="server" OnItemCommand="lv_talepler_ItemCommand" Visible="false">
                <LayoutTemplate>
                    <table class="TalepTable" border="1" cellspacing="0" cellpadding="7">
                        <tr>
                            <th>ID</th>
                            <th>Uye No</th>
                            <th>Uye Adı</th>
                            <th>Miktar</th>
                            <th>Talep Tarihi</th>
                            <th>Secenek</th>
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
                        
                        <td>
                            <asp:LinkButton ID="lbtn_onaybtn" runat="server" CssClass="OnayBtn" CommandArgument='<%# Eval("ID") %>' CommandName="onay">Onay</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_redbtn" runat="server" CssClass="RedBtn" CommandArgument='<%# Eval("ID") %>' CommandName="red" >Red</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="lv_onaylanan" runat="server" OnItemCommand="lv_talepler_ItemCommand" Visible="false">
                <LayoutTemplate>
                    <table class="TalepTable" border="1" cellspacing="0" cellpadding="7">
                        <tr>
                            <th>ID</th>
                            <th>Uye No</th>
                            <th>Uye Adı</th>
                            <th>Miktar</th>
                            <th>Talep Tarihi</th>
                            <th>Onay Tarihi</th>
                            <th>Onaylayan</th>
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
                        <td><%# Eval("OnayTarih") %></td>
                        <td><%#Eval("YoneticiAdi") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:ListView ID="lv_reddedilenler" runat="server" OnItemCommand="lv_talepler_ItemCommand" Visible="false">
                <LayoutTemplate>
                    <table class="TalepTable" border="1" cellspacing="0" cellpadding="7">
                        <tr>
                            <th>ID</th>
                            <th>Uye No</th>
                            <th>Uye Adı</th>
                            <th>Miktar</th>
                            <th>Talep Tarihi</th>
                            
                            <th>Durum</th>

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

                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>


    </div>
</asp:Content>
