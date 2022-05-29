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
    public class CARTAODAO
    {
        public CARTAODAO()
        {

        }

        private static Conexao Conn()
        {
            return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
        }

        public static List<CARTAO> listaCARTAO(CARTAO filtro = null)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<CARTAO> lista = new List<CARTAO>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from CARTAO ";
                if (filtro != null)
                {
                    if (filtro.ID_CARTAO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_CARTAO = @ID_CARTAO ";
                        cmd.Parameters.AddWithValue("ID_CARTAO", filtro.ID_CARTAO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.ID_COLUNA != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_COLUNA = @ID_COLUNA ";
                        cmd.Parameters.AddWithValue("ID_COLUNA", filtro.ID_COLUNA);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.ID_GRUPO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_GRUPO = @ID_GRUPO ";
                        cmd.Parameters.AddWithValue("ID_GRUPO", filtro.ID_GRUPO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_OBS_ALUNO != String.Empty)
                    {
                        cmd.CommandText += where + "NM_OBS_ALUNO = @NM_OBS_ALUNO ";
                        cmd.Parameters.AddWithValue("NM_OBS_ALUNO", filtro.NM_OBS_ALUNO.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_OBS_ORIENTADOR != String.Empty)
                    {
                        cmd.CommandText += where + "NM_OBS_ORIENTADOR = @NM_OBS_ORIENTADOR ";
                        cmd.Parameters.AddWithValue("NM_OBS_ORIENTADOR", filtro.NM_OBS_ORIENTADOR.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_TITULO != String.Empty)
                    {
                        cmd.CommandText += where + "NM_TITULO = @NM_TITULO ";
                        cmd.Parameters.AddWithValue("NM_TITULO", filtro.NM_TITULO.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.IS_VALIDACAO != String.Empty)
                    {
                        cmd.CommandText += where + "IS_VALIDACAO = @IS_VALIDACAO ";
                        cmd.Parameters.AddWithValue("IS_VALIDACAO", filtro.IS_VALIDACAO.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                }
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CARTAO obj = new CARTAO();
                        obj.ID_CARTAO = (dr["ID_CARTAO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_CARTAO"]);
                        obj.ID_COLUNA = (dr["ID_COLUNA"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_COLUNA"]);
                        obj.ID_GRUPO = (dr["ID_GRUPO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_GRUPO"]);
                        obj.NM_OBS_ALUNO = (dr["NM_OBS_ALUNO"] == DBNull.Value) ? String.Empty : dr["NM_OBS_ALUNO"].ToString();
                        obj.NM_OBS_ORIENTADOR = (dr["NM_OBS_ORIENTADOR"] == DBNull.Value) ? String.Empty : dr["NM_OBS_ORIENTADOR"].ToString();
                        obj.NM_TITULO = (dr["NM_TITULO"] == DBNull.Value) ? String.Empty : dr["NM_TITULO"].ToString();
                        obj.IS_VALIDACAO = (dr["IS_VALIDACAO"] == DBNull.Value) ? String.Empty : dr["IS_VALIDACAO"].ToString();
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

        public static bool inserirCARTAO(CARTAO obj)
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
                #region insert tabela CARTAODAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = "insert into CARTAO";
                cols = "(";
                vals = "(";
                if (obj.ID_CARTAO != Int32.MinValue)
                {
                    cols += "ID_CARTAO,";
                    vals += "@ID_CARTAO,";
                    cmd.Parameters.AddWithValue("ID_CARTAO", obj.ID_CARTAO);
                }
                if (obj.ID_COLUNA != Int32.MinValue)
                {
                    cols += "ID_COLUNA,";
                    vals += "@ID_COLUNA,";
                    cmd.Parameters.AddWithValue("ID_COLUNA", obj.ID_COLUNA);
                }
                if (obj.ID_GRUPO != Int32.MinValue)
                {
                    cols += "ID_GRUPO,";
                    vals += "@ID_GRUPO,";
                    cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
                }
                if (obj.NM_OBS_ALUNO != String.Empty)
                {
                    cols += "NM_OBS_ALUNO,";
                    vals += "@NM_OBS_ALUNO,";
                    cmd.Parameters.AddWithValue("NM_OBS_ALUNO", obj.NM_OBS_ALUNO.ToUpper());
                }
                if (obj.NM_OBS_ORIENTADOR != String.Empty)
                {
                    cols += "NM_OBS_ORIENTADOR,";
                    vals += "@NM_OBS_ORIENTADOR,";
                    cmd.Parameters.AddWithValue("NM_OBS_ORIENTADOR", obj.NM_OBS_ORIENTADOR.ToUpper());
                }
                if (obj.NM_TITULO != String.Empty)
                {
                    cols += "NM_TITULO,";
                    vals += "@NM_TITULO,";
                    cmd.Parameters.AddWithValue("NM_TITULO", obj.NM_TITULO.ToUpper());
                }
                if (obj.IS_VALIDACAO != String.Empty)
                {
                    cols += "IS_VALIDACAO,";
                    vals += "@IS_VALIDACAO,";
                    cmd.Parameters.AddWithValue("IS_VALIDACAO", obj.IS_VALIDACAO.ToUpper());
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

        public static bool alteraCARTAO(CARTAO obj)
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
                #region update tabela CARTAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " update CARTAO set ";
                sets = "";
                if (obj.ID_CARTAO != Int32.MinValue)
                {
                    sets += " ID_CARTAO = @ID_CARTAO,";
                    cmd.Parameters.AddWithValue("ID_CARTAO", obj.ID_CARTAO);
                }
                if (obj.ID_COLUNA != Int32.MinValue)
                {
                    sets += " ID_COLUNA = @ID_COLUNA,";
                    cmd.Parameters.AddWithValue("ID_COLUNA", obj.ID_COLUNA);
                }
                if (obj.ID_GRUPO != Int32.MinValue)
                {
                    sets += " ID_GRUPO = @ID_GRUPO,";
                    cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
                }
                if (obj.NM_OBS_ALUNO != String.Empty)
                {
                    sets += " NM_OBS_ALUNO = @NM_OBS_ALUNO,";
                    cmd.Parameters.AddWithValue("NM_OBS_ALUNO", obj.NM_OBS_ALUNO.ToUpper());
                }
                if (obj.NM_OBS_ORIENTADOR != String.Empty)
                {
                    sets += " NM_OBS_ORIENTADOR = @NM_OBS_ORIENTADOR,";
                    cmd.Parameters.AddWithValue("NM_OBS_ORIENTADOR", obj.NM_OBS_ORIENTADOR.ToUpper());
                }
                if (obj.NM_TITULO != String.Empty)
                {
                    sets += " NM_TITULO = @NM_TITULO,";
                    cmd.Parameters.AddWithValue("NM_TITULO", obj.NM_TITULO.ToUpper());
                }
                if (obj.IS_VALIDACAO != String.Empty)
                {
                    sets += " IS_VALIDACAO = @IS_VALIDACAO,";
                    cmd.Parameters.AddWithValue("IS_VALIDACAO", obj.IS_VALIDACAO.ToUpper());
                }
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_CARTAO = @ID_CARTAO";
                cmd.Parameters.AddWithValue("ID_CARTAO", obj.ID_CARTAO);
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

        public static bool deletaCARTAO(CARTAO obj)
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
                #region update tabela CARTAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " DELETE FROM CARTAO ";
                sets = "";
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_CARTAO = @ID_CARTAO";
                cmd.Parameters.AddWithValue("ID_CARTAO", obj.ID_CARTAO);
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
                cmd.CommandText = "select MAX(ID_CARTAO) as ID_CARTAO from CARTAO";
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
