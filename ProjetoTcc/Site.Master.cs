using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoTcc
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            memoria.Usuario usu = new memoria.Usuario();
            if (ProjetoTccBusiness.Utilidades.TaSetada(Session,"usuario"))
            {
                lbl_logado.Text = usu.Logado.NM_NOME;

                if (ProjetoTccBusiness.Usuario.pegaTipoUsuario(usu.Logado.ID_TIPO).NM_TIPO == "ALUNO")
                {
                    div_lateral.Visible = false;
                }
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            
        }

        protected void btn_sair_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }
    }
}