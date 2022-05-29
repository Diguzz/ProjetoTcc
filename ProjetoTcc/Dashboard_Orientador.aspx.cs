using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoTcc
{
    public partial class Dashboard_Orientador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        protected void CarregaGrid()
        {
            memoria.Usuario usu = new memoria.Usuario();
            List<ProjetoTccModel.GRUPO> lista = new List<ProjetoTccModel.GRUPO>();
            lista = ProjetoTccDAO.GRUPODAO.listaGRUPOUsuario(usu.Logado.ID_USUARIO);

            rptGrid_grupos.DataSource = lista;
            rptGrid_grupos.DataBind();
        }

        protected void rptGrid_grupos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "painel")
            {
                Session["grupo_orientador"] = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("PainelScrum.aspx");
            }
        }

        protected void rptGrid_grupos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ProjetoTccModel.GRUPO gp = (ProjetoTccModel.GRUPO)e.Item.DataItem;
                Label status = (Label)e.Item.FindControl("lblStatus");

                switch (gp.DS_STATUS)
                {
                    case "PENDENTE":
                        status.Text = "PENDENTE";
                        status.CssClass = "badge  bg-warning colorBadge2";
                        break;
                    case "APROVADO":
                        status.Text = "APROVADO";
                        status.CssClass = "badge  bg-success colorBadge";
                        break;
                    case "REPROVADO":
                        status.Text = "REPROVADO";
                        status.CssClass = "badge  bg-danger colorBadge";
                        break;
                    default:
                        status.Text = "-";
                        status.CssClass = "";
                        break;
                }
            }
        }
    }
}