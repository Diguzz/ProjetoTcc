using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccBusiness
{
    public static class Login
    {
        public static Tuple<ProjetoTccModel.LOGIN, bool> validaLogin(String user, String pass)
        {
            try
            {
                List<ProjetoTccModel.LOGIN> lista = ProjetoTccDAO.LoginDAO.listaLogin(new ProjetoTccModel.LOGIN { NM_USER = user, NM_PASS = pass });
                if (lista.Count > 0)
                {
                    if (lista.Count < 2)
                    {
                        return new Tuple<ProjetoTccModel.LOGIN, bool>(lista[0], true);
                    }
                    else
                    {
                        return new Tuple<ProjetoTccModel.LOGIN, bool>(new ProjetoTccModel.LOGIN(), false);
                    }
                }
                else
                {
                    return new Tuple<ProjetoTccModel.LOGIN, bool>(new ProjetoTccModel.LOGIN(), false);
                }
            }
            catch (Exception ex)
            {
                String ms = ex.Message;
                return new Tuple<ProjetoTccModel.LOGIN, bool>(new ProjetoTccModel.LOGIN(),false);
            }

        }

        
    }
}
