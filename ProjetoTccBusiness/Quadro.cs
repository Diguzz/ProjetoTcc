using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccBusiness
{
    public static class Quadro
    {
        /// <summary>
        /// Atualiza os cartões conforme movimentados no quadro.
        /// </summary>
        /// <param name="id_coluna"></param>
        /// <param name="id_card"></param>
        public static void AtualizaTabela(Int32 id_coluna, Int32 id_card)
        {
            try
            {
                ProjetoTccModel.CARTAO card = new ProjetoTccModel.CARTAO();
                card.ID_CARTAO = id_card;
                card.ID_COLUNA = id_coluna;
                ProjetoTccDAO.CARTAODAO.alteraCARTAO(card);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ProjetoTccModel.CARTAO pegaCartao(Int32 id_card)
        {
            try
            {
                ProjetoTccModel.CARTAO filtro = new ProjetoTccModel.CARTAO { ID_CARTAO = id_card};
                List<ProjetoTccModel.CARTAO> filtros = ProjetoTccDAO.CARTAODAO.listaCARTAO(filtro);
                if (filtros.Count > 0)
                {
                    return filtros[0];
                }
                else
                {
                    return new ProjetoTccModel.CARTAO();
                }
            }
            catch
            {
                return new ProjetoTccModel.CARTAO();
            }
        }
    }
}
