using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoTcc
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_entrar_Click(object sender, EventArgs e)
        {            
            try
            {
                if (nm_user.Text != "" && nm_pass.Text != "")
                {                    
                    Tuple<ProjetoTccModel.LOGIN, bool> tup = ProjetoTccBusiness.Login.validaLogin(nm_user.Text, nm_pass.Text);
                    if (tup.Item2)
                    {
                        ProjetoTccModel.USUARIO user = ProjetoTccBusiness.Usuario.pegaUsuario(tup.Item1.ID_LOGIN);
                        switch (user.ID_TIPO)
                        {
                            case 1:
                                Session["usuario"] = user;
                                Response.Redirect("Dashboard_Orientador.aspx");
                                break;
                            case 2:
                                Session["usuario"] = user;
                                Response.Redirect("PainelScrum.aspx");
                                break;
                            default:
                                ProjetoTccBusiness.Utilidades.Alert("Tipo de usuário não registrado.");
                                break;
                        }
                    }
                    else
                    {
                        ProjetoTccBusiness.Utilidades.Alert("Por favor, inserir matrícula e senha válida.");
                    }
                }
                else
                {
                    ProjetoTccBusiness.Utilidades.Alert("Por favor, inserir matrícula e senha válida.");
                }
            }
            catch (Exception ex)
            {
                ProjetoTccBusiness.Logs.insere_erro(ex.Message);
                ProjetoTccBusiness.Utilidades.Alert("Falha na autenticação, tente novamente.");
            }
        }
    }
}