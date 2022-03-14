<!--
/*
 * Author               : Quaint Park
 * Copyright            : © 2018 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Description          : Quaint Daycare Management System (QDMS)
*/
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuaintDMS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <meta name="author" content="Quaint Park" />
    <meta name="description" content="Quaint DMS is a web based daycare management system. It includes childs, members data bank, keep tracking of donars, parants and administrator separate panel, all billing, programs with multi services, full office and staffs salary management system. Full accounting (debit/credit) included." />
    <meta name="keywords" content="quaintdms, web, daycare, management software, c#, asp.net, quaint park" />

    <title>
        <asp:Literal ID="defaultTitle" runat="server" Text="Q Care | Login"></asp:Literal>
    </title>

    <!-- Favicon and Touch Icons -->
    <link rel="icon" type="image/png" href="Theme/img/header/favicon.png" />
    <link rel="apple-touch-icon" href="Theme/img/header/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="Theme/img/header/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="Theme/img/header/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="Theme/img/header/apple-touch-icon-144x144.png" />

    <%-- CSS --%>
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="../Assets/lib/bootstrap/dist/css/bootstrap.min.css" />
    <!-- Font Awesome 4.7.0 -->
    <link rel="stylesheet" href="../Assets/lib/font-awesome-4.7.0/css/font-awesome.min.css" />
    <!-- Animate CSS 1.0 -->
    <link rel="stylesheet" href="../Assets/lib/animate/animate.min.css" />
    <!-- Ionicons 2.0.0 -->
    <link rel="stylesheet" href="../Assets/lib/Ionicons/css/ionicons.min.css" />
    <!-- iCheck 1.0.1 -->
    <link rel="stylesheet" href="../Assets/lib/iCheck/all.css" />
    <!-- AdminLTE 2.4.2 -->
    <link rel="stylesheet" href="../Assets/lib/AdminLTE-2.4.2/css/AdminLTE.min.css" />
    <!-- Select2 4.0.4 -->
    <link rel="stylesheet" href="../Assets/lib/select2/dist/css/select2.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins 
        folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../Assets/lib/AdminLTE-2.4.2/css/skins/_all-skins.min.css" />
    <!-- Custom CSS -->
    <link rel="stylesheet" href="../Assets/css/replace.css" />
    <link rel="stylesheet" href="../Assets/css/style.css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />

</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="login-box">
                    <div class="login-logo">
                        <a runat="server" href="~/Default.aspx"><b>Q</b>Care</a>
                    </div>

                    <div class="login-box-body">
                        <p class="login-box-msg">Sign in to start your session</p>

                        <div>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" required="required"></asp:TextBox>
                                <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" required="required"></asp:TextBox>
                                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                            </div>
                            <div class="row">
                                <div class="col-xs-8">
                                    <%--<div class="checkbox icheck">
                                <label>
                                    <input type="checkbox" />
                                    Remember Me
                                </label>
                            </div>--%>
                                </div>
                                <div class="col-xs-4">
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-block btn-flat" OnClick="btnLogin_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="alertMessage" runat="server"></div>
                                </div>
                            </div>
                        </div>

                        <%--<div class="social-auth-links text-center">
                    <p>- OR -</p>
                    <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i>Sign in using Facebook</a>
                    <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i>Sign in using Google+</a>
                </div>

                <a href="#">I forgot my password</a><br>
                <a href="register.html" class="text-center">Register a new membership</a>--%>
                    </div>
                    <!-- /.login-box-body -->
                </div>
                <!-- /.login-box -->

                <asp:Timer ID="tmrAlertMessage" runat="server" Enabled="False" OnTick="tmrAlertMessage_Tick"></asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>



    <%-- JS --%>
    <!-- jQuery 3.2.1 -->
    <script src="../Assets/lib/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="../Assets/lib/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- Select2 4.0.4 -->
    <script src="../Assets/lib/select2/dist/js/select2.full.min.js"></script>
    <!-- iCheck 1.0.1 -->
    <script src="../Assets/lib/iCheck/icheck.min.js"></script>
    <!-- AdminLTE 2.4.2 -->
    <%--<script src="../Assets/lib/AdminLTE-2.4.2/js/adminlte.min.js"></script>
    <script src="../Assets/lib/AdminLTE-2.4.2/js/pages/dashboard.js"></script>
    <script src="../Assets/lib/AdminLTE-2.4.2/js/demo.js"></script>--%>
    <script type="text/javascript">
        $(function () {

            //Initialize Select2 Elements
            $('.select2').select2();

            //iCheck for checkbox and radio inputs
            $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_minimal-blue',
                increaseArea: '20%'
            });
            //Red color scheme for iCheck
            $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red',
                increaseArea: '20%'
            });
            //Flat red color scheme for iCheck
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green',
                increaseArea: '20%'
            });

        });
    </script>
</body>
</html>
