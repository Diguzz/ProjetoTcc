using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccBusiness
{
    public static class Logs
    {
        /// <summary>
        /// Atualiza os cartões conforme movimentados no quadro.
        /// </summary>
        /// <param name="id_coluna"></param>
        /// <param name="id_card"></param>
        public static void insere_erro(String msg)
        {
            try
            {
                ProjetoTccModel.LOGS log = new ProjetoTccModel.LOGS();                
                log.ID = ProjetoTccDAO.LOGSDAO.pegasequence();
                log.DS_LOG = msg;
                log.DT_MOVIMENTO = DateTime.Now;
                ProjetoTccDAO.LOGSDAO.inserirLOGS(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
