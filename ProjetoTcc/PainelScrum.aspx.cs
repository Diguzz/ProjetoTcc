using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;

namespace ProjetoTcc
{
    public partial class PainelScrum : System.Web.UI.Page
    {
        public Int32 id_grupo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            memoria.Usuario usu = new memoria.Usuario();

            if (usu.Logado.ID_TIPO == 1)
            {
                id_grupo = (Int32)Session["grupo_orientador"];
            }
            else if (usu.Logado.ID_TIPO == 2)
            {
                id_grupo = ProjetoTccBusiness.Usuario.pegaGrupoAluno(usu.Logado.ID_USUARIO).ID_GRUPO;
            }

            if (!IsPostBack)
            {
                CarregaGridColuna();
                LoadPage();
            }
        }

        [WebMethod]
        public static void AtualizaTabela(String info)
        {
            try
            {
                //VETAR ORIENTADOR DE MOVIMENTAR O CARD?!

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(info);
                var coluna = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class,'card-header')]");
                var cards = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class,'card-body')]");

                foreach (var item in cards)
                {
                    ProjetoTccBusiness.Quadro.AtualizaTabela(Convert.ToInt32(coluna[0].Id), Convert.ToInt32(item.Id));
                }
            }
            catch
            {

            }
        }

        public void Limpar()
        {
            nm_titulo.Text = "";
            nm_descricao_aluno.Text = "";

            rptGridAnexoAluno.Dispose();
            rptGridAnexoAluno.DataBind();

            nm_descricao_orientador.Text = "";

            rptGridAnexoOrientador.Dispose();
            rptGridAnexoOrientador.DataBind();


            upModal.Update();
        }

        protected void LoadPage()
        {
            memoria.Usuario usu = new memoria.Usuario();

            if (usu.Logado.ID_TIPO == 1)
            {
                btnNovoCartao.Visible = false;
                div_body_orientador.Visible = true;
                div_header_orientador.Visible = true;

                nm_titulo.ReadOnly = true;
                nm_descricao_aluno.ReadOnly = true;
                //botao de anexar arquivo do aluno deixar desabilitado


            }
            else if (usu.Logado.ID_TIPO == 2)
            {
                nm_descricao_orientador.ReadOnly = true;
                //botao de anexar arquivo do aluno deixar desabilitado
            }
        }

        protected void CarregaGridColuna()
        {
            List<ProjetoTccModel.COLUNA> colunas = new List<ProjetoTccModel.COLUNA>();
            colunas = ProjetoTccDAO.COLUNADAO.listaCOLUNA();

            rptGridColuna.DataSource = colunas;
            rptGridColuna.DataBind();
        }
        public void btnNovoCartao_Click(object sender, EventArgs e)
        {
            div_anexoAluno.Visible = false;
            div_anexoOrientador.Visible = false;
            div_anexo.Visible = false;

            Limpar();
            div_body_orientador.Visible = false;
            div_header_orientador.Visible = false;
            Application["card"] = "novo";
            


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal", "abreModal();", true);

            upModal.Update();
        }
        protected void rptGridColuna_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ProjetoTccModel.COLUNA coluna = (ProjetoTccModel.COLUNA)e.Item.DataItem;

                Repeater card = (Repeater)e.Item.FindControl("rptGridCard");
                Button btn = (Button)e.Item.FindControl("btn_novo_card");

                List<ProjetoTccModel.CARTAO> lista = new List<ProjetoTccModel.CARTAO>();
                lista = ProjetoTccDAO.CARTAODAO.listaCARTAO(new ProjetoTccModel.CARTAO { ID_COLUNA = coluna.ID_COLUNA, ID_GRUPO = id_grupo });
                if (lista.Count > 0)
                {
                    card.DataSource = lista;
                    card.DataBind();
                }



            }
        }

        protected void rptGridCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ProjetoTccModel.CARTAO card = (ProjetoTccModel.CARTAO)e.Item.DataItem;
                Label titulo = (Label)e.Item.FindControl("lblTitulo");
                Label status = (Label)e.Item.FindControl("lblStatus");
                LinkButton aprova = (LinkButton)e.Item.FindControl("lkbaprova");
                LinkButton reprova = (LinkButton)e.Item.FindControl("lkbreprova");

                memoria.Usuario usu = new memoria.Usuario();
                    

                titulo.Text = card.NM_TITULO;


                if (card.ID_COLUNA == 3)
                {
                    if (usu.Logado.ID_TIPO == 1)
                    {
                        aprova.Visible = true;
                        reprova.Visible = true;
                    }
                    
                    status.Visible = true;
                }
                if (card.ID_COLUNA == 4)
                {
                    aprova.Visible = false;
                    reprova.Visible = false;
                    status.Visible = true;
                }


                switch (card.IS_VALIDACAO)
                {
                    case "S":
                        status.Text = "Aprovado";
                        status.CssClass = "badge rounded-pill bg-success colorBadge";
                        break;
                    case "N":
                        status.Text = "Corrigir";
                        status.CssClass = "badge rounded-pill bg-warning colorBadge2";
                        break;
                    default:
                        status.Text = "Aguardando";
                        status.CssClass = "badge rounded-pill bg-secondary colorBadge";
                        break;
                }

                
            }
        }

        public void rptGridCard_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "detalhe")
            {
                Limpar();
                div_anexo.Visible = true;
                div_exclui_cartao.Visible = true;

                Int32 id_card = Convert.ToInt32(e.CommandArgument);

                Application["card"] = id_card.ToString();
                lblCard.InnerText = id_card.ToString();

                List<ProjetoTccModel.ANEXO> anexos_alunos = new List<ProjetoTccModel.ANEXO>();
                List<ProjetoTccModel.ANEXO> anexos_orientador = new List<ProjetoTccModel.ANEXO>();

                anexos_alunos = ProjetoTccDAO.ANEXODAO.listaANEXO(new ProjetoTccModel.ANEXO { ID_CARTAO = id_card, ID_TIPO = 2 });
                anexos_orientador = ProjetoTccDAO.ANEXODAO.listaANEXO(new ProjetoTccModel.ANEXO { ID_CARTAO = id_card, ID_TIPO = 1 });

                ProjetoTccModel.CARTAO card = ProjetoTccBusiness.Quadro.pegaCartao(id_card);

                nm_titulo.Text = card.NM_TITULO;
                nm_descricao_aluno.Text = card.NM_OBS_ALUNO;

                if (anexos_alunos.Count > 0)
                {
                    rptGridAnexoAluno.DataSource = anexos_alunos;
                    rptGridAnexoAluno.DataBind();
                }

                if (anexos_orientador.Count > 0)
                {
                    rptGridAnexoOrientador.DataSource = anexos_orientador;
                    rptGridAnexoOrientador.DataBind();
                }


                nm_descricao_orientador.Text = card.NM_OBS_ORIENTADOR;

                memoria.Usuario usu = new memoria.Usuario();
                if (usu.Logado.ID_TIPO == 2)
                {
                    if (anexos_alunos.Count > 0)
                    {
                        div_anexoAluno.Visible = true;
                    }
                    else
                    {
                        div_anexoAluno.Visible = false;
                    }

                    if (card.NM_OBS_ORIENTADOR != "")
                    {
                        div_body_orientador.Visible = true;
                        div_header_orientador.Visible = true;

                        if (anexos_orientador.Count > 0)
                        {
                            div_anexoOrientador.Visible = true;
                            foreach (RepeaterItem item in rptGridAnexoOrientador.Items)
                            {
                                LinkButton lixeira = (LinkButton)item.FindControl("lkbLiexeira");
                                lixeira.Visible = false;
                            }
                        }
                        else
                        {
                            div_anexoOrientador.Visible = false;
                        }

                    }
                }
                else if (usu.Logado.ID_TIPO == 1)
                {
                    btnExcluir.Visible = false;

                    if (anexos_orientador.Count > 0)
                    {
                        div_anexoOrientador.Visible = true;
                    }
                    else
                    {
                        div_anexoOrientador.Visible = false;
                    }

                    if (anexos_alunos.Count > 0)
                    {
                        div_anexoAluno.Visible = true;
                        foreach (RepeaterItem item in rptGridAnexoAluno.Items)
                        {
                            LinkButton lixeira = (LinkButton)item.FindControl("lkbLiexeira");
                            lixeira.Visible = false;
                        }
                    }
                    else
                    {
                        div_anexoAluno.Visible = false;
                    }
                }


                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal", "abreModal();", true);
                upModal.Update();
                CarregaGridColuna();

            }
            else if (e.CommandName == "aprovar")
            {
                Int32 id_card = Convert.ToInt32(e.CommandArgument);
                ProjetoTccDAO.CARTAODAO.alteraCARTAO(new ProjetoTccModel.CARTAO { ID_CARTAO = id_card, IS_VALIDACAO = "S" });
                CarregaGridColuna();
            }
            else if (e.CommandName == "reprovar")
            {
                Int32 id_card = Convert.ToInt32(e.CommandArgument);
                ProjetoTccDAO.CARTAODAO.alteraCARTAO(new ProjetoTccModel.CARTAO { ID_CARTAO = id_card, IS_VALIDACAO = "N" });
                CarregaGridColuna();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modal", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#modal').hide();", true);
            Limpar();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modal", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#modal').hide();", true);
                
                
                if (nm_titulo.Text != "")
                {
                    String value = (String)Application["card"];
                    if (value != "")
                    {
                        if (Int32.TryParse(value, out Int32 id_card))
                        {
                            ProjetoTccModel.CARTAO card = new ProjetoTccModel.CARTAO();
                            card.ID_CARTAO = id_card;
                            card.NM_OBS_ALUNO = nm_descricao_aluno.Text;
                            card.NM_OBS_ORIENTADOR = nm_descricao_orientador.Text;
                            card.NM_TITULO = nm_titulo.Text;
                            card.IS_VALIDACAO = "A";

                            if (ProjetoTccDAO.CARTAODAO.alteraCARTAO(card))
                            {
                                ProjetoTccBusiness.Utilidades.Alert("Cartão atualizado com sucesso.");
                                Response.Redirect("PainelScrum.aspx");
                            }
                        }
                        else
                        {
                            ProjetoTccModel.CARTAO card = new ProjetoTccModel.CARTAO();
                            memoria.Usuario usu = new memoria.Usuario();

                            card.ID_CARTAO = ProjetoTccDAO.CARTAODAO.pegasequence();
                            card.NM_OBS_ALUNO = nm_descricao_aluno.Text;
                            card.NM_OBS_ORIENTADOR = nm_descricao_orientador.Text;
                            card.NM_TITULO = nm_titulo.Text;
                            card.ID_GRUPO = id_grupo;
                            card.ID_COLUNA = 1;
                            card.IS_VALIDACAO = "A";

                            if (ProjetoTccDAO.CARTAODAO.inserirCARTAO(card))
                            {
                                ProjetoTccBusiness.Utilidades.Alert("Cartão criado com sucesso.");
                                Response.Redirect("PainelScrum.aspx");
                            }

                        }
                    }
                }
                else
                {
                    ProjetoTccBusiness.Utilidades.Alert("Por favor, preencha o título para a criação do card.");
                }
                



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAnexar_Click(object sender, EventArgs e)
        {
            try
            {
                String nomeArquivo = "";
                Int32 pos = 0;
                String arquivo = "";
                String cartao = (String)Application["card"];
                Int32 id_card = Convert.ToInt32(cartao);

                memoria.Usuario usu = new memoria.Usuario();
                ProjetoTccModel.ANEXO anexo = new ProjetoTccModel.ANEXO();

                if (fu_anexo.HasFiles)
                {
                    foreach (HttpPostedFile up in fu_anexo.PostedFiles)
                    {

                        nomeArquivo = up.FileName;
                        pos = nomeArquivo.LastIndexOf(@"\") + 1;
                        arquivo = $"card_{id_card}_{DateTime.Now.ToString("yyyyMMddhh24missms")}_{nomeArquivo.Substring(pos)}";
                        up.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("/anexos/") + arquivo);

                        anexo = new ProjetoTccModel.ANEXO();
                        anexo.ID_ANEXO = ProjetoTccDAO.ANEXODAO.pegasequence();
                        anexo.DS_CAMINHO = System.Web.Hosting.HostingEnvironment.MapPath("/anexos/") + arquivo;
                        anexo.DT_CRIACAO = DateTime.Now;
                        anexo.ID_CARTAO = id_card;
                        anexo.ID_TIPO = usu.Logado.ID_TIPO;
                        anexo.ID_GRUPO = id_grupo;
                        anexo.NM_ARQUIVO = nomeArquivo;

                        if (ProjetoTccDAO.ANEXODAO.inserirANEXO(anexo))
                        {
                            ProjetoTccDAO.CARTAODAO.alteraCARTAO(new ProjetoTccModel.CARTAO { ID_CARTAO = id_card, IS_VALIDACAO = "A" });
                        }
                    }
                    
                    ProjetoTccBusiness.Utilidades.Alert("Anexo realizado com sucesso.");
                }
                else
                {
                    ProjetoTccBusiness.Utilidades.Alert("Escolha um arquivo antes de anexar.");
                }

                CarregaGridColuna();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rptGridAnexoOrientador_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "apagar")
            {
                Int32 id_anexo = Convert.ToInt32(e.CommandArgument);
                String cartao = (String)Application["card"];
                Int32 id_card = Convert.ToInt32(cartao);

                ProjetoTccDAO.ANEXODAO.deletaANEXO(new ProjetoTccModel.ANEXO { ID_ANEXO = id_anexo });

                List<ProjetoTccModel.ANEXO> anexos_alunos = new List<ProjetoTccModel.ANEXO>();
                List<ProjetoTccModel.ANEXO> anexos_orientador = new List<ProjetoTccModel.ANEXO>();

                anexos_alunos = ProjetoTccDAO.ANEXODAO.listaANEXO(new ProjetoTccModel.ANEXO { ID_CARTAO = id_card, ID_TIPO = 2 });
                anexos_orientador = ProjetoTccDAO.ANEXODAO.listaANEXO(new ProjetoTccModel.ANEXO { ID_CARTAO = id_card, ID_TIPO = 1 });

                ProjetoTccModel.CARTAO card = ProjetoTccBusiness.Quadro.pegaCartao(id_card);

                if (anexos_alunos.Count > 0)
                {
                    rptGridAnexoAluno.DataSource = anexos_alunos;
                    rptGridAnexoAluno.DataBind();
                }

                if (anexos_orientador.Count > 0)
                {
                    rptGridAnexoOrientador.DataSource = anexos_orientador;
                    rptGridAnexoOrientador.DataBind();
                }

                memoria.Usuario usu = new memoria.Usuario();
                if (usu.Logado.ID_TIPO == 2)
                {
                    if (card.NM_OBS_ORIENTADOR != "")
                    {
                        div_body_orientador.Visible = true;
                        div_header_orientador.Visible = true;

                        if (anexos_alunos.Count > 0)
                        {
                            div_anexoAluno.Visible = true;
                        }
                        else
                        {
                            div_anexoAluno.Visible = false;
                        }


                        if (anexos_orientador.Count > 0)
                        {
                            div_anexoOrientador.Visible = true;
                            foreach (RepeaterItem item in rptGridAnexoOrientador.Items)
                            {
                                LinkButton lixeira = (LinkButton)item.FindControl("lkbLiexeira");
                                lixeira.Visible = false;
                            }
                        }
                        else
                        {
                            div_anexoOrientador.Visible = false;
                        }

                    }
                }
                else if (usu.Logado.ID_TIPO == 1)
                {
                    if (anexos_orientador.Count > 0)
                    {
                        div_anexoOrientador.Visible = true;
                    }
                    else
                    {
                        div_anexoOrientador.Visible = false;
                    }

                    if (anexos_alunos.Count > 0)
                    {
                        div_anexoAluno.Visible = true;
                        foreach (RepeaterItem item in rptGridAnexoAluno.Items)
                        {
                            LinkButton lixeira = (LinkButton)item.FindControl("lkbLiexeira");
                            lixeira.Visible = false;
                        }
                    }
                    else
                    {
                        div_anexoAluno.Visible = false;
                    }


                }

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#modal", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();$('#modal').hide();", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal", "abreModal();", true);

                ProjetoTccBusiness.Utilidades.Alert("Anexo excluido com sucesso.");
            }
            else if (e.CommandName == "baixar")
            {
                ProjetoTccModel.ANEXO classe = new ProjetoTccModel.ANEXO();
                classe = ProjetoTccDAO.ANEXODAO.listaANEXO(new ProjetoTccModel.ANEXO { ID_ANEXO = Convert.ToInt32(e.CommandArgument) })[0];

                string arquivo = classe.NM_ARQUIVO;
                string caminho = classe.DS_CAMINHO;
                //System.Web.HttpResponse response = HttpContext.Current.Response;
                //response.ClearContent();
                //response.ContentType = "application/octet-stream";
                //byte[] bytes = System.IO.File.ReadAllBytes(caminho);
                //response.AddHeader("Content-Disposition", "attachment; filename=" + arquivo);
                //response.OutputStream.Write(bytes, 0, bytes.Length);
                //response.End();

                byte[] bts = System.IO.File.ReadAllBytes(caminho);
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Type", "Application/octet-stream");
                Response.AddHeader("Content-Length", bts.Length.ToString());
                Response.AddHeader("Content-Disposition", "attachment; filename=" +
                arquivo);
                Response.BinaryWrite(bts);
                Response.Flush();
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                memoria.Usuario usu = new memoria.Usuario();
                if (usu.Logado.ID_TIPO == 2)
                {
                    String value = (String)Application["card"];

                    ProjetoTccModel.CARTAO card = ProjetoTccBusiness.Quadro.pegaCartao(Convert.ToInt32(value));

                    if (card.ID_COLUNA != 3)
                    {
                        ProjetoTccDAO.ANEXODAO.deletaANEXO(new ProjetoTccModel.ANEXO { ID_CARTAO = Convert.ToInt32(value) });
                        ProjetoTccDAO.CARTAODAO.deletaCARTAO(new ProjetoTccModel.CARTAO { ID_CARTAO = Convert.ToInt32(value) });
                    }
                    else
                    {
                        ProjetoTccBusiness.Utilidades.Alert("Este card está sendo avaliado pelo orientador, não pode ser excluído até liberação do mesmo.");
                    }

                    
                }
                else
                {
                    ProjetoTccBusiness.Utilidades.Alert("Você não tem permissão para excluir card.");
                }

                Response.Redirect("PainelScrum.aspx");
            }
            catch
            {
                
            }
           
        }
    }
}