<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard_Orientador.aspx.cs" Inherits="ProjetoTcc.Dashboard_Orientador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Begin Page Content -->
    <div class="container-fluid">
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Grupos</h6>
            </div>
            <asp:Repeater ID="rptGrid_grupos" OnItemDataBound="rptGrid_grupos_ItemDataBound" OnItemCommand="rptGrid_grupos_ItemCommand" runat="server">
                <HeaderTemplate>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Tema</th>
                                        <th>Data Apresentação</th>
                                        <th>Status</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblTema" Text='<%# Eval("NM_TEMA") %>' runat="server" /></td>
                        <td>
                            <asp:Label ID="lblData" Text='<%# Eval("DT_APRESENTACAO", "{0:dd/MM/yyyy}") %>' runat="server" /></td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server" /></td>
                        <td>
                            <asp:LinkButton ID="lkbPainel" Text="Painel" CommandName="painel" CommandArgument='<%# Eval("ID_GRUPO") %>' runat="server" /></td>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </div>
            </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!-- /.container-fluid -->
    <style>
        .colorBadge {
            color: white !important;
            font-weight: bold;
        }

        .colorBadge2 {
            color: black !important;
            font-weight: bold;
        }
    </style>
</asp:Content>
