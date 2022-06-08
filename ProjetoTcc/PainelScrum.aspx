<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PainelScrum.aspx.cs" Inherits="ProjetoTcc.PainelScrum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="srcKanban" EnablePageMethods="true" runat="server" EnableCdn="true" />

    <div id="tudo" runat="server">
        <div class="row text-right">
            <div class="col pb-3 pr-5">
                <asp:UpdatePanel ID="upNegociacao" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnNovoCartao" CssClass="btn btn-sm btn-primary shadow-sm" Text="Novo Cartão +" runat="server" OnClick="btnNovoCartao_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="testimonial-group">
            <div class="row row-sm mg-t-20">
                <asp:Repeater ID="rptGridColuna" OnItemDataBound="rptGridColuna_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <div class="col-3">
                            <div class="card card-dashboard-events dropzone">
                                <div id="<%# Eval("ID_COLUNA") %>" class="card-header">
                                    <h5 class="card-subtitle text-center"><%# Eval("NM_COLUNA") %></h5>
                                </div>
                                <asp:Repeater ID="rptGridCard" OnItemDataBound="rptGridCard_ItemDataBound" OnItemCommand="rptGridCard_ItemCommand" runat="server">
                                    <ItemTemplate>
                                        <div id="div_card" class="card_drag" style="padding: 5px 0px 5px 0px; text-align: center" draggable="true" runat="server">
                                            <%--<asp:Literal ID="ltrGrid" runat="server" />--%>
                                            <div id='<%# Eval("ID_CARTAO") %>' class='card-body'>
                                                <div class='list-group'>
                                                    <div class='list-group-item text-center'>
                                                        <span class='event-indicator bg-blue tooltips' data-placement='top'></span>
                                                        <div class="row border-bottom pb-2">
                                                            <div class="col">
                                                                <!-- Aqui 1 -->
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                        <asp:LinkButton ID="lkbaprova" CommandArgument='<%# Eval("ID_CARTAO") %>' CommandName="aprovar" CssClass="btn btn-outline-success btn-sm fa-solid fa-thumbs-up" runat="server" Visible="false" />
                                                                    </div>
                                                                    <div class="col-1">
                                                                        <asp:LinkButton ID="lkbreprova" CommandArgument='<%# Eval("ID_CARTAO") %>' CommandName="reprovar" CssClass="btn btn-outline-danger btn-sm fa-solid fa-thumbs-down" runat="server" Visible="false" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col" style="text-align: right">
                                                                <!-- Aqui 2 -->
                                                                <asp:Label ID="lblStatus" CssClass="badge rounded-pill bg-secondary colorBadge" Visible="false" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="row pt-2">
                                                            <div class="col">
                                                                <asp:Label ID="lblTitulo" Text="Aqui entra o titulo" runat="server" />
                                                            </div>
                                                        </div>
                                                        <%--<h6 class='text-center d-block'><%# Eval("ID_CARTAO") %></h6>--%>
                                                        <asp:UpdatePanel ID="up2" UpdateMode="Always" runat="server">
                                                            <ContentTemplate>
                                                                <div class="row pt-3">
                                                                    <div class="col">
                                                                        <asp:Button CssClass="btn btn-primary" ID="btndetalhe" Text="Detalhe" runat="server" CommandArgument='<%# Eval("ID_CARTAO") %>' CommandName="detalhe" />
                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="upModal" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="modal" id="modal" aria-hidden="true" style="display: none;" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
                    <div class="modal-content modal-content-demo">
                        <div class="modal-header modalcorrecao">
                            <div class="row">
                                <div class="col-6">
                                    <div class="row">
                                        <div class="col">
                                            <span class="modal-title">
                                                <h3>Cartão</h3>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-6" id="div_header_orientador" runat="server" visible="false">
                                    <div class="row">
                                        <div class="col">
                                            <span class="modal-title">
                                                <h3>Orientador</h3>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <%--aluno--%>
                                <div class="col">
                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox ID="nm_titulo" MaxLength="50" CssClass="form-control form-control-user" placeholder="Título do cartão" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox ID="nm_descricao_aluno" TextMode="MultiLine" Rows="4" CssClass="form-control form-control-user" placeholder="Observações" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div runat="server" id="div_anexoAluno" visible="false">
                                        <div class="row">
                                            <div class="col">
                                                <asp:Repeater ID="rptGridAnexoAluno" OnItemCommand="rptGridAnexoOrientador_ItemCommand" runat="server">
                                                    <HeaderTemplate>
                                                        <div class="card shadow mb-4">
                                                            <div class="card-header py-3">
                                                                <h6 class="m-0 font-weight-bold text-primary">Anexos</h6>
                                                            </div>
                                                            <div class="card-body">
                                                                <div class="table-responsive">
                                                                    <table class="table table-bordered" width="100%" cellspacing="0">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>Arquivo</th>
                                                                                <th>Data</th>
                                                                                <th></th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <%--<asp:Label ID="lblArquivo" Text="text" runat="server" />--%>
                                                                <asp:LinkButton ID="lkbArquivo" CommandName="baixar" CommandArgument='<%# Eval("ID_ANEXO") %>' Text='<%# Eval("NM_ARQUIVO") %>' runat="server" /></td>

                                                            <td>
                                                                <asp:Label ID="lblData" Text='<%# Eval("DT_CRIACAO", "{0:dd/MM/yyyy}") %>' runat="server" /></td>
                                                            <td style="text-align: center">
                                                                <asp:LinkButton ID="lkbLiexeira" CommandName="apagar" CommandArgument='<%# Eval("ID_ANEXO") %>' CssClass="fa-solid fa-trash-can" runat="server" OnClientClick="return confirm('Tem certeza que deseja excluir o anexo?');" />
                                                            </td>

                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--Orientador--%>
                                <div class="col-6" id="div_body_orientador" runat="server" visible="false">

                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox ID="nm_descricao_orientador" TextMode="MultiLine" Rows="6" CssClass="form-control form-control-user" placeholder="Observações" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div runat="server" id="div_anexoOrientador" visible="false">
                                        <div class="row pt-2">
                                            <div class="col">
                                                <asp:Repeater ID="rptGridAnexoOrientador" OnItemCommand="rptGridAnexoOrientador_ItemCommand" runat="server">
                                                    <HeaderTemplate>
                                                        <div class="card shadow mb-4">
                                                            <div class="card-header py-3">
                                                                <h6 class="m-0 font-weight-bold text-primary">Anexos</h6>
                                                            </div>
                                                            <div class="card-body">
                                                                <div class="table-responsive">
                                                                    <table class="table table-bordered" width="100%" cellspacing="0">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>Arquivo</th>
                                                                                <th>Data</th>
                                                                                <th></th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <%--<asp:Label ID="lblArquivo" Text="text" runat="server" />--%>
                                                                <asp:LinkButton ID="lkbArquivo" CommandName="baixar" CommandArgument='<%# Eval("ID_ANEXO") %>' Text='<%# Eval("NM_ARQUIVO") %>' runat="server" /></td>

                                                            <td>
                                                                <asp:Label ID="lblData" Text='<%# Eval("DT_CRIACAO", "{0:dd/MM/yyyy}") %>' runat="server" /></td>
                                                            <td style="text-align: center">
                                                                <asp:LinkButton ID="lkbLiexeira" CommandName="apagar" CommandArgument='<%# Eval("ID_ANEXO") %>' CssClass="fa-solid fa-trash-can" OnClientClick="return confirm('Tem certeza que deseja excluir o anexo?');" runat="server" /></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </div>

                                        <%--<div class="row">
                                            <div class="col">
                                                <input type="file" id="arquivo" onchange="return validarArquivo()" />
                                            </div>
                                            <div class="col">
                                                <input class="btn btn-primary btn-user" type="button" value="Enviar arquivo" onclick="return EnviarArquivo()" />
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="div_anexo" runat="server">
                                <div class="col-2"></div>
                                <div class="col-6">
                                    <div class="input-group mb-3">
                                        <asp:FileUpload AllowMultiple="false" CssClass="form-control" ID="fu_anexo" runat="server" onchange="Javascript: VerificaTamanhoArquivo();" />
                                    </div>
                                </div>
                                <div class="col-2">
                                    <asp:Button class="btn btn-primary btn-user" runat="server" ID="btnAnexar" Text="Anexar" OnClick="btnAnexar_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer modalF mg-t-20">
                            <div class="row">
                                <div class="col-9">
                                    <div id="div_exclui_cartao" runat="server" visible="false">
                                        <asp:Button Width="20%" class="btn btn-danger btn-user" runat="server" ID="btnExcluir" OnClientClick="return confirm('Tem certeza que deseja excluir o cartão?');" Text="Excluir Cartão" OnClick="btnExcluir_Click"></asp:Button>
                                    </div>
                                    <label id="lblCard" runat="server" style="color: white"></label>
                                </div>
                                <div class="col-1">
                                    <asp:Button class="btn btn-secondary" runat="server" ID="btnClose" Text="Cancelar" OnClick="btnClose_Click"></asp:Button>
                                </div>
                                <div class="col-2">
                                    <asp:Button class="btn btn-primary btn-user btnSave" runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click"></asp:Button>
                                </div>
                            </div>



                        </div>
                    </div>
                    <!-- modal-dialog -->
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="rptGridAnexoAluno" />
            <asp:PostBackTrigger ControlID="rptGridAnexoOrientador" />
            <asp:PostBackTrigger ControlID="btnAnexar" />
        </Triggers>
    </asp:UpdatePanel>
    <style>
        .btnSave {
            width: 100%;
        }

        .colorBadge {
            color: white !important;
            font-weight: bold;
        }

        .colorBadge2 {
            color: black !important;
            font-weight: bold;
        }

        .modalF {
            display: block !important;
        }

        .fileUpload {
            position: relative;
            overflow: hidden;
            margin: 10px;
        }

            .fileUpload input.upload {
                position: absolute;
                top: 0;
                right: 0;
                margin: 0;
                padding: 0;
                font-size: 20px;
                cursor: pointer;
                opacity: 0;
                filter: alpha(opacity=0);
            }


        /* The heart of the matter */
        .testimonial-group > .row {
            /*display: inline-block;*/
            overflow-x: auto;
            white-space: nowrap;
            /*width: 75%;*/
        }

            .testimonial-group > .row > .col-4 {
                display: inline-block;
            }

        .remove_borda_button {
            /*border: none;*/
            outline: thin dotted !important;
            outline: 0px auto -webkit-focus-ring-color !important;
            outline-offset: 0px !important;
        }

        .highlight {
            background-color: #f7f7f7;
        }

        .card_drag, .dropzone {
            transition: 400ms;
        }

        .is-dragging {
            cursor: move !important;
            opacity: 0.3;
        }

        .over {
            background-color: #4cd13711;
        }

        .btnNovo {
            border-radius: 100% !important;
        }

        .divBtn {
            text-align: right;
            margin-top: -25px;
        }

        .modalcorrecao {
            display: block !important;
        }
    </style>
    <script type="text/javascript">

        function abreModal() {
            $("#modal").modal({
                show: true
            });
        }

        function VerificaTamanhoArquivo() {

            var fi = document.getElementById('<%= fu_anexo.ClientID %>');
            var maxFileSize = 26214400; // 25MB -> 25 * 1024 * 1024
            var extensoesPermitidas = /(.docx|.pdf|.doc|.txt)$/i;

            if (fi.files.length > 0) {

                for (var i = 0; i <= fi.files.length - 1; i++) {

                    var fsize = fi.files.item(i).size;
                    var fname = fi.files.item(i).name;

                    if (extensoesPermitidas.exec(fname)) {

                        if (fsize < maxFileSize) {

                        }
                        else {
                            alert("O arquivo não pode ultrapassar o tamanho máximo de 25MB.");
                            fi.value = null;
                        }
                    } else {
                        alert("Por favor envie um arquivo que tenha as extensões.docx/.doc/.txt/.pdf .");
                        fi.value = null;
                    }
                }
            }
        }

        <%--$(document).ready(function () {
            $('#<%= fu_anexo.ClientID %>').change(function () {

                 //because this is single file upload I use only first index
                 var f = this.files[0]

                 //here I CHECK if the FILE SIZE is bigger than 8 MB (numbers below are in bytes)
                 if (f.size > 26214400 || f.fileSize > 26214400) {
                     //show an alert to the user
                     alert("O arquivo não pode ultrapassar o tamanho máximo de 25MB.")

                     //reset file upload control
                     this.value = null;
                 }
             })
         });--%>

        //function validarArquivo() {
        //    var arquivoInput = document.getElementById('arquivo');
        //    var caminhoArquivo = arquivoInput.value;
        //    var extensoesPermitidas = /(.docx|.ini|.pdf|.doc|.txt)$/i;
        //    if (!extensoesPermitidas.exec(caminhoArquivo)) {
        //        alert('Por favor envie um arquivo que tenha as extensões.docx/.doc/.txt/.pdf .');
        //        arquivoInput.value = '';
        //        return false;
        //    } else {
        //        if (arquivoInput.files && arquivoInput.files[0]) {
        //            if (arquivoInput.files[0].size > 26214400) {
        //                alert("Tamanho do arquivo deve ter até 25 MB!");
        //                return false;
        //            } else {

        //            }
        //        }
        //    }
        //}



        //function EnviarArquivo() {
        //    var arquivoInput = document.getElementById('arquivo');
        //    var caminhoArquivo = arquivoInput.value;
        //    $.ajax({
        //        type: "POST",
        //        url: "/PainelScrum.aspx/AnexaArquivo",
        //        processData: false,
        //        data: caminhoArquivo,
        //        //contentType: "application/json; charset=utf-8",
        //        contentType: "text/xml",
        //        dataType: "json",
        //        success: function (data) {
        //            var time = data.d;
        //        },
        //        error: function (jqXHR, textStatus, errorThrown) {
        //            //alert('Failure: ' + textStatus + ". Error thrown: " + errorThrown);
        //        }
        //    });
        //}


        function EnviarArquivo() {
            var id_card = document.getElementById('MainContent_lblCard');
            /*var caminhoArquivo = arquivoInput.value;*/
            //var obj = new Object();
            //obj.lastModified = arquivo.files[0].lastModified;
            //obj.lastModifiedDate = arquivo.files[0].lastModifiedDate;
            //obj.name = arquivo.files[0].name;
            //obj.size = arquivo.files[0].size;
            //obj.type = arquivo.files[0].type;
            //obj.webkitRelativePath = arquivo.files[0].webkitRelativePath;
            //PageMethods.AnexaArquivo(caminhoArquivo, OnSuccess, OnError)
            PageMethods.AnexaArquivo(arquivo.files[0].name, id_card.innerText)
            alert("Anexo realizado com sucesso!");
            //$('body').removeClass('modal-open');
            //$('.modal-backdrop').remove();
            //$('#modal').hide();

            //$('#MainContent_rptGridColuna_rptGridCard_0_btndetalhe_0').trigger('click');


        }







        const cards = document.querySelectorAll('.card_drag')
        const dropzones = document.querySelectorAll('.dropzone')

        cards.forEach(card_drag => {

            card_drag.addEventListener('dragstart', dragstart)
            card_drag.addEventListener('drag', drag)
            card_drag.addEventListener('dragend', dragend)
        })

        function dragstart() {
            //console.log('> CARD: Start Dragging')
            dropzones.forEach(dropzone => dropzone.classList.add('highlight'))

            this.classList.add('is-dragging')
        }

        function drag() {

        }

        function dragend() {
            //console.log('> CARD: End Dragging')
            dropzones.forEach(dropzone => dropzone.classList.remove('highlight'))
            this.classList.remove('is-dragging')

        }

        dropzones.forEach(dropzone => {

            dropzone.addEventListener('dragenter', dragenter)
            dropzone.addEventListener('dragover', dragover)
            dropzone.addEventListener('dragleave', dragleave)
            dropzone.addEventListener('drop', drop)
        })

        function dragenter(ev) {
            ev.preventDefault();
        }

        function dragover(ev) {
            ev.preventDefault();
            this.classList.add('over')
            const cardBeinDragged = document.querySelector('.is-dragging')
            this.appendChild(cardBeinDragged)
        }

        function dragleave(ev) {
            ev.preventDefault();
            this.classList.remove('over')
        }

        function drop(ev) {

            ev.preventDefault();
            const cardBeinDragged = document.querySelector('.is-dragging')
            this.classList.remove('over')
            getMessage(this)
            //this.appendChild(this)
        }

        function getMessage(info) {
            var cd = info.innerHTML
            PageMethods.AtualizaTabela(cd, OnSuccess, OnError)
        }
        function OnSuccess(response) {
            //console.log("deu tudo certo.");
            window.location.href = "PainelScrum.aspx";
        }
        function OnError(error) {
            console.log("deu merda.");
        }



    </script>

    <%-- <div class="col-3">
                    <div class="card card-dashboard-events dropzone">
                        <div class="card-header">
                            <h5 class="card-subtitle text-center">Tarefas</h5>
                        </div>
                        <div id="div_card" class="card_drag" style="padding: 5px 0px 5px 0px; text-align: center" draggable="true" runat="server">
                            <div class='card-body'>
                                <div class='list-group'>
                                    <div class='list-group-item text-center'>
                                        <span class='event-indicator bg-blue tooltips' data-placement='top'></span>
                                        <h6 class='text-center d-block'>CARD 0</h6>
                                        <a class='btn btn-primary' target='_blank' href='{url_ticket}'>Detalhe</a>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="div1" class="card_drag" style="padding: 5px 0px 5px 0px; text-align: center" draggable="true" runat="server">
                            <div class='card-body'>
                                <div class='list-group'>
                                    <div class='list-group-item text-center'>
                                        <span class='event-indicator bg-blue tooltips' data-placement='top'></span>
                                        <h6 class='text-center d-block'>CARD 1</h6>
                                        <a class='btn btn-primary' target='_blank' href='{url_ticket}'>Detalhe</a>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-3">
                    <div class="card card-dashboard-events dropzone">
                        <div class="card-header">
                            <h5 class="card-subtitle text-center">Em Progresso</h5>
                        </div>
                        <div class="card-body">
                            <div class="list-group">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-3">
                    <div class="card card-dashboard-events dropzone">
                        <div class="card-header">
                            <h5 class="card-subtitle text-center">Revisão</h5>
                        </div>
                        <div class="card-body">
                            <div class="list-group">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-3">
                    <div class="card card-dashboard-events dropzone">
                        <div class="card-header">
                            <h5 class="card-subtitle text-center">Concluído</h5>
                        </div>
                        <div class="card-body">
                            <div class="list-group">
                            </div>
                        </div>
                    </div>
                </div>--%>
</asp:Content>
