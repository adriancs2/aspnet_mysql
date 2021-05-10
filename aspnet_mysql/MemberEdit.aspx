<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberEdit.aspx.cs" Inherits="aspnet_mysql.MemberEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Member Details</h2>
    <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" />
    <asp:Button ID="btDelete" runat="server" Text="Delete" OnClick="btDelete_Click" />

    <div style="padding: 10px 0;">
        <asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
    </div>

    <table>
        <tr>
            <td>ID</td>
            <td>
                <asp:Label ID="lbId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Code</td>
            <td>
                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Name</td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Gender</td>
            <td>
                <asp:DropDownList ID="dropGender" runat="server">
                    <asp:ListItem Value="0" Text="Not Specified"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Content>
