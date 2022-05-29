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
    public class COLUNADAO
    {
        public COLUNADAO()
        {

        }

        private static Conexao Conn()
        {
            return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
        }

        public static List<COLUNA> listaCOLUNA(COLUNA filtro = null)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<COLUNA> lista = new List<COLUNA>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from COLUNA ";
                if (filtro != null)
                {
                    if (filtro.ID_COLUNA != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_COLUNA = @ID_COLUNA ";
                        cmd.Parameters.AddWithValue("ID_COLUNA", filtro.ID_COLUNA);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_COLUNA != String.Empty)
                    {
                        cmd.CommandText += where + "NM_COLUNA = @NM_COLUNA ";
                        cmd.Parameters.AddWithValue("NM_COLUNA", filtro.NM_COLUNA.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                }
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        COLUNA obj = new COLUNA();
                        obj.ID_COLUNA = (dr["ID_COLUNA"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_COLUNA"]);
                        obj.NM_COLUNA = (dr["NM_COLUNA"] == DBNull.Value) ? String.Empty : dr["NM_COLUNA"].ToString();
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

        public static bool inserirCOLUNA(COLUNA obj)
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
                #region insert tabela COLUNADAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = "insert into COLUNA";
                cols = "(";
                vals = "(";
                if (obj.ID_COLUNA != Int32.MinValue)
                {
                    cols += "ID_COLUNA,";
                    vals += "@ID_COLUNA,";
                    cmd.Parameters.AddWithValue("ID_COLUNA", obj.ID_COLUNA);
                }
                if (obj.NM_COLUNA != String.Empty)
                {
                    cols += "NM_COLUNA,";
                    vals += "@NM_COLUNA,";
                    cmd.Parameters.AddWithValue("NM_COLUNA", obj.NM_COLUNA.ToUpper());
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

        public static bool alteraCOLUNA(COLUNA obj)
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
                #region update tabela COLUNA
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " update COLUNA set ";
                sets = "";
                if (obj.ID_COLUNA != Int32.MinValue)
                {
                    sets += " ID_COLUNA = @ID_COLUNA,";
                    cmd.Parameters.AddWithValue("ID_COLUNA", obj.ID_COLUNA);
                }
                if (obj.NM_COLUNA != String.Empty)
                {
                    sets += " NM_COLUNA = @NM_COLUNA,";
                    cmd.Parameters.AddWithValue("NM_COLUNA", obj.NM_COLUNA.ToUpper());
                }
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_COLUNA = @ID_COLUNA";
                cmd.Parameters.AddWithValue("ID_COLUNA", obj.ID_COLUNA);
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

        public static bool deletaCOLUNA(COLUNA obj)
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
                #region update tabela COLUNA
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " DELETE FROM COLUNA ";
                sets = "";
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_COLUNA = @ID_COLUNA";
                cmd.Parameters.AddWithValue("ID_COLUNA", obj.ID_COLUNA);
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
                cmd.CommandText = "select MAX(ID_COLUNA) as ID_COLUNA from COLUNA";
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
