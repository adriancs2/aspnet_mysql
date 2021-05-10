<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="aspnet_mysql.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tb1 table {
            border-collapse: collapse;
        }
        .tb1 th, .tb1 td {
            border: 1px solid black;
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Member List</h2>

    <div class="tb1">
        <asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
