<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form1.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Form1 Index</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <telerik:RadComboBox ID="RadComboBox1" runat="server"></telerik:RadComboBox>
</asp:Content>
