<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoTcc.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--<meta http-equiv="refresh" content="3" />--%>
    <title>Login</title>

    <!-- Custom fonts for this template-->
    <link href="lib/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="lib/css/sb-admin-2.css" rel="stylesheet" />
</head>
<body class="bg-gradient-primary">
    <form id="form1" runat="server">

        <div class="container">
            <!-- Outer Row -->
            <div class="row justify-content-center">
                <div class="col-xl-10 col-lg-12 col-md-9">
                    <div class="card o-hidden border-0 shadow-lg my-5 rquadro">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Bem-vindos de volta!</h1>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="nm_user" CssClass="form-control form-control-user" placeholder="Matrícula" runat="server" />                                            
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="nm_pass" CssClass="form-control form-control-user" TextMode="Password" placeholder="Senha" runat="server" />                                            
                                        </div>
                                        <div>
                                            <asp:Button ID="btn_entrar" CssClass="btn btn-primary btn-user btn-block" Text="Entrar" runat="server" OnClick="btn_entrar_Click" />
                                        </div>
                                        <%--<div class="text-center">
                                            <a class="small" href="EsqueceuSenha.aspx">Esqueceu a senha?</a>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap core JavaScript-->
    <script src="lib/jquery/jquery.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="lib/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="lib/js/sb-admin-2.min.js"></script>
</body>
</html>
