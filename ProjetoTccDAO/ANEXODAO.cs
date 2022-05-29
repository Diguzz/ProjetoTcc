using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using ProjetoTccConnect;
using ProjetoTccModel;

namespace ProjetoTccDAO
{
    public class ANEXODAO
    {
        public ANEXODAO()
        {

        }

        private static Conexao Conn()
        {
            return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
        }

        public static List<ANEXO> listaANEXO(ANEXO filtro = null)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<ANEXO> lista = new List<ANEXO>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from ANEXO ";
                if (filtro != null)
                {
                    if (filtro.ID_ANEXO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_ANEXO = @ID_ANEXO ";
                        cmd.Parameters.AddWithValue("ID_ANEXO", filtro.ID_ANEXO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.ID_CARTAO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_CARTAO = @ID_CARTAO ";
                        cmd.Parameters.AddWithValue("ID_CARTAO", filtro.ID_CARTAO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.ID_GRUPO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_GRUPO = @ID_GRUPO ";
                        cmd.Parameters.AddWithValue("ID_GRUPO", filtro.ID_GRUPO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.ID_TIPO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_TIPO = @ID_TIPO ";
                        cmd.Parameters.AddWithValue("ID_TIPO", filtro.ID_TIPO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_ARQUIVO != String.Empty)
                    {
                        cmd.CommandText += where + "NM_ARQUIVO = @NM_ARQUIVO ";
                        cmd.Parameters.AddWithValue("NM_ARQUIVO", filtro.NM_ARQUIVO.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.DT_CRIACAO != DateTime.MinValue)
                    {
                        cmd.CommandText += where + "DT_CRIACAO = @DT_CRIACAO ";
                        cmd.Parameters.AddWithValue("DT_CRIACAO", filtro.DT_CRIACAO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.DS_CAMINHO != String.Empty)
                    {
                        cmd.CommandText += where + "DS_CAMINHO = @DS_CAMINHO ";
                        cmd.Parameters.AddWithValue("DS_CAMINHO", filtro.DS_CAMINHO.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                }
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ANEXO obj = new ANEXO();
                        obj.ID_ANEXO = (dr["ID_ANEXO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_ANEXO"]);
                        obj.ID_CARTAO = (dr["ID_CARTAO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_CARTAO"]);
                        obj.ID_GRUPO = (dr["ID_GRUPO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_GRUPO"]);
                        obj.ID_TIPO = (dr["ID_TIPO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_TIPO"]);
                        obj.NM_ARQUIVO = (dr["NM_ARQUIVO"] == DBNull.Value) ? String.Empty : dr["NM_ARQUIVO"].ToString();
                        obj.DT_CRIACAO = (dr["DT_CRIACAO"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_CRIACAO"]);
                        obj.DS_CAMINHO = (dr["DS_CAMINHO"] == DBNull.Value) ? String.Empty : dr["DS_CAMINHO"].ToString();
                        lista.Add(obj);
                    }
                }
            }
            finally
            {
                if (dt != null) dt.Dispose();
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Dispose();
            }
            return lista;
        }

        public static bool inserirANEXO(ANEXO obj)
        {
            SQLiteCommand cmd = null;
            Conexao conn = null;
            try
            {
                conn = Conn();
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                bool sucesso = false;
                string cols;
                string vals;
                #region insert tabela ANEXODAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = "insert into ANEXO";
                cols = "(";
                vals = "(";
                if (obj.ID_ANEXO != Int32.MinValue)
                {
                    cols += "ID_ANEXO,";
                    vals += "@ID_ANEXO,";
                    cmd.Parameters.AddWithValue("ID_ANEXO", obj.ID_ANEXO);
                }
                if (obj.ID_CARTAO != Int32.MinValue)
                {
                    cols += "ID_CARTAO,";
                    vals += "@ID_CARTAO,";
                    cmd.Parameters.AddWithValue("ID_CARTAO", obj.ID_CARTAO);
                }
                if (obj.ID_GRUPO != Int32.MinValue)
                {
                    cols += "ID_GRUPO,";
                    vals += "@ID_GRUPO,";
                    cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
                }
                if (obj.ID_TIPO != Int32.MinValue)
                {
                    cols += "ID_TIPO,";
                    vals += "@ID_TIPO,";
                    cmd.Parameters.AddWithValue("ID_TIPO", obj.ID_TIPO);
                }
                if (obj.NM_ARQUIVO != String.Empty)
                {
                    cols += "NM_ARQUIVO,";
                    vals += "@NM_ARQUIVO,";
                    cmd.Parameters.AddWithValue("NM_ARQUIVO", obj.NM_ARQUIVO.ToUpper());
                }
                if (obj.DT_CRIACAO != DateTime.MinValue)
                {
                    cols += "DT_CRIACAO,";
                    vals += "@DT_CRIACAO,";
                    cmd.Parameters.AddWithValue("DT_CRIACAO", obj.DT_CRIACAO);
                }
                if (obj.DS_CAMINHO != String.Empty)
                {
                    cols += "DS_CAMINHO,";
                    vals += "@DS_CAMINHO,";
                    cmd.Parameters.AddWithValue("DS_CAMINHO", obj.DS_CAMINHO.ToUpper());
                }
                if (cols.EndsWith(","))
                    cols = cols.Remove(cols.Length - 1, 1);
                if (vals.EndsWith(","))
                    vals = vals.Remove(vals.Length - 1, 1);
                cmd.CommandText += cols + ") values " + vals + ")";
                sucesso = conn.executaNonQuery(cmd) > 0;
                #endregion
                return sucesso;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Dispose();
            }
        }

        public static bool alteraANEXO(ANEXO obj)
        {
            SQLiteCommand cmd = null;
            Conexao conn = null;
            try
            {
                conn = Conn();
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                bool sucesso = false;
                string sets;
                #region update tabela ANEXO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " update ANEXO set ";
                sets = "";
                if (obj.ID_ANEXO != Int32.MinValue)
                {
                    sets += " ID_ANEXO = @ID_ANEXO,";
                    cmd.Parameters.AddWithValue("ID_ANEXO", obj.ID_ANEXO);
                }
                if (obj.ID_CARTAO != Int32.MinValue)
                {
                    sets += " ID_CARTAO = @ID_CARTAO,";
                    cmd.Parameters.AddWithValue("ID_CARTAO", obj.ID_CARTAO);
                }
                if (obj.ID_GRUPO != Int32.MinValue)
                {
                    sets += " ID_GRUPO = @ID_GRUPO,";
                    cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
                }
                if (obj.ID_TIPO != Int32.MinValue)
                {
                    sets += " ID_TIPO = @ID_TIPO,";
                    cmd.Parameters.AddWithValue("ID_TIPO", obj.ID_TIPO);
                }
                if (obj.NM_ARQUIVO != String.Empty)
                {
                    sets += " NM_ARQUIVO = @NM_ARQUIVO,";
                    cmd.Parameters.AddWithValue("NM_ARQUIVO", obj.NM_ARQUIVO.ToUpper());
                }
                if (obj.DT_CRIACAO != DateTime.MinValue)
                {
                    sets += " DT_CRIACAO = @DT_CRIACAO,";
                    cmd.Parameters.AddWithValue("DT_CRIACAO", obj.DT_CRIACAO);
                }
                if (obj.DS_CAMINHO != String.Empty)
                {
                    sets += " DS_CAMINHO = @DS_CAMINHO,";
                    cmd.Parameters.AddWithValue("DS_CAMINHO", obj.DS_CAMINHO.ToUpper());
                }
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_ANEXO = @ID_ANEXO";
                cmd.Parameters.AddWithValue("ID_ANEXO", obj.ID_ANEXO);
                sucesso = conn.executaNonQuery(cmd) > 0;
                #endregion
                return sucesso;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Dispose();
            }
        }

        public static bool deletaANEXO(ANEXO obj)
        {
            SQLiteCommand cmd = null;
            Conexao conn = null;
            try
            {
                conn = Conn();
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                bool sucesso = false;
                string sets;
                #region update tabela ANEXO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " DELETE FROM ANEXO ";
                sets = "";

                if (obj.ID_ANEXO != Int32.MinValue)
                {
                    if (sets.EndsWith(","))
                        sets = sets.Remove(sets.Length - 1, 1);
                    cmd.CommandText += sets + " where ID_ANEXO = @ID_ANEXO";
                    cmd.Parameters.AddWithValue("ID_ANEXO", obj.ID_ANEXO);
                }
                else if(obj.ID_CARTAO != Int32.MinValue)
                {
                    if (sets.EndsWith(","))
                        sets = sets.Remove(sets.Length - 1, 1);
                    cmd.CommandText += sets + " where ID_CARTAO = @ID_CARTAO";
                    cmd.Parameters.AddWithValue("ID_CARTAO", obj.ID_CARTAO);
                }
                else
                {
                    return sucesso;
                }

                sucesso = conn.executaNonQuery(cmd) > 0;
                #endregion
                return sucesso;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Dispose();
            }
        }

        public static Int32 pegasequence()
        {
            SQLiteCommand cmd = null;
            Conexao conn = null;
            Int32 resultado = 0;
            try
            {
                conn = Conn();
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandText = "select MAX(ID_ANEXO) as ID_ANEXO from ANEXO";
                String valor = conn.pegaScalar(cmd).ToString();
                resultado = (valor != "") ? (Int32)Convert.ToInt32(conn.pegaScalar(cmd).ToString()) : 0;
                return resultado + 1;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Dispose();
            }
        }
    }
}
