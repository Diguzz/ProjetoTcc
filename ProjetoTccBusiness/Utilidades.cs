using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;

namespace ProjetoTccBusiness
{
    public static class Utilidades
    {
        public static bool TaSetada(System.Web.SessionState.HttpSessionState p_session, string nome_session)
        {
            try
            {
                if (p_session[nome_session] != null)
                {
                    if (!string.IsNullOrEmpty(p_session[nome_session].ToString()))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Alert(string message)
        {
            Page p = (Page)HttpContext.Current.CurrentHandler;
            string text = $"<script>alert('" + message + "')</script>";
            ScriptManager.RegisterStartupScript(p, p.GetType(), "temp", text, false);
        }

        public static void AlertRedirect(ClientScriptManager clientScript, string msg, string pag)
        {
            //string s = string.Format("NewAlertRedirect('" + msg + "','" + pag + "');");
            //string s = string.Format("alert(" + msg + ");window.location ='" + pag + "';");
            string s = "alert('" + msg + "');var vers = navigator.appVersion;if(vers.indexOf('MSIE 7.0') != -1) { window.location.href='" + pag + "';} else{ window.location.href='" + pag + "';}";
            clientScript.RegisterStartupScript(typeof(Page), "Information", s, true);
            //clientScript.RegisterStartupScript(typeof(Page), "Msg",s, true);
        }

        public static void UpdatePanelAlertRedirect(Control controle, string msg, string pag)
        {
            string s = string.Format("NewAlertRedirect('" + msg + "','" + pag + "');");
            //string s = string.Format("alert(" + msg + ");window.location ='" + pag + "';");
            //original//string s = "alert('" + msg + "');var vers = navigator.appVersion;if(vers.indexOf('MSIE 7.0') != -1) { window.location.href='" + pag + "';} else{ window.location.href='" + pag + "';}";
            ScriptManager.RegisterStartupScript(controle, typeof(Page), "Information", s, true);
            //clientScript.RegisterStartupScript(typeof(Page), "Msg",s, true);
        }
    }
}
