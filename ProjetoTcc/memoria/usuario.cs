using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoTccModel;

namespace ProjetoTcc.memoria
{
    public class Usuario
    {
        private USUARIO logado;

        private void UsuarioSession(USUARIO usu)
        {
            if (ProjetoTccBusiness.Utilidades.TaSetada(HttpContext.Current.Session, "usuario"))
            {
                logado = (USUARIO)HttpContext.Current.Session["usuario"];
            }
            else
            {
                logado = new USUARIO();
            }
        }
        public USUARIO Logado
        {
            get
            {
                UsuarioSession(logado);
                return logado;
            }
            set => logado = value;
        }
    }
}