<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUD.Pages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">CodigoPeriodoLectivo</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbCodigoPeriodoLectivo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">DescripcionPeriodoLectivo</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbDescripcionPeriodoLectivo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Sucursal</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbsucursal"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Estado</label>
                <asp:TextBox runat="server"  CssClass="form-control" ID="tbestado"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Update" Visible="false" onclick="BtnUpdate_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="True" OnClick="BtnVolver_Click" />
        </div>
    </form>
</asp:Content>
