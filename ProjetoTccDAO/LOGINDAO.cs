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
    public class LoginDAO
    {
        public LoginDAO()
        {

        }

        private static Conexao Conn()
        {
            return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
        }

        public static List<LOGIN> listaLogin(LOGIN filtro = null)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<LOGIN> lista = new List<LOGIN>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from LOGIN ";
                if (filtro != null)
                {
                    if (filtro.ID_LOGIN != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_LOGIN = @ID_LOGIN ";
                        cmd.Parameters.AddWithValue("ID_LOGIN", filtro.ID_LOGIN);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_USER != String.Empty)
                    {
                        cmd.CommandText += where + "NM_USER like @NM_USER ";
                        cmd.Parameters.AddWithValue("NM_USER", filtro.NM_USER.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_PASS != String.Empty)
                    {
                        cmd.CommandText += where + "NM_PASS = @NM_PASS ";
                        cmd.Parameters.AddWithValue("NM_PASS", filtro.NM_PASS);
                        if (where == " where ") where = " and ";
                    }
                }
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        LOGIN obj = new LOGIN();
                        obj.ID_LOGIN = (dr["ID_LOGIN"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_LOGIN"]);
                        obj.NM_USER = (dr["NM_USER"] == DBNull.Value) ? String.Empty : dr["NM_USER"].ToString();
                        obj.NM_PASS = (dr["NM_PASS"] == DBNull.Value) ? String.Empty : dr["NM_PASS"].ToString();
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
        public static bool inserirLogin(LOGIN obj)
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
                #region insert tabela MortesDAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = "insert into LOGIN";
                cols = "(";
                vals = "(";

                if (obj.ID_LOGIN != Int32.MinValue)
                {
                    cols += "ID_LOGIN,";
                    vals += "@ID_LOGIN,";
                    cmd.Parameters.AddWithValue("ID_LOGIN", obj.ID_LOGIN);
                }
                if (obj.NM_USER != String.Empty)
                {
                    cols += "NM_USER,";
                    vals += "@NM_USER,";
                    cmd.Parameters.AddWithValue("NM_USER", obj.NM_USER.ToUpper());
                }
                if (obj.NM_PASS != String.Empty)
                {
                    cols += "NM_PASS,";
                    vals += "@NM_PASS,";
                    cmd.Parameters.AddWithValue("NM_PASS", obj.NM_PASS);
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
        public static bool alteraLogin(LOGIN obj)
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
                #region update tabela ASSINADORES
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " update LOGIN set ";
                sets = "";

                if (obj.NM_USER != String.Empty)
                {
                    sets += " NM_USER = @NM_USER,";
                    cmd.Parameters.AddWithValue("NM_USER", obj.NM_USER.ToUpper());
                }
                if (obj.NM_PASS != String.Empty)
                {
                    sets += " NM_PASS = @NM_PASS,";
                    cmd.Parameters.AddWithValue("NM_PASS", obj.NM_PASS);
                }
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_LOGIN = @ID_LOGIN";
                cmd.Parameters.AddWithValue("ID_LOGIN", obj.ID_LOGIN);
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
        public static bool deletaLogin(LOGIN obj)
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
                #region update tabela ASSINADORES
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " DELETE FROM LOGIN";
                sets = "";

                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_LOGIN = @ID_LOGIN";
                cmd.Parameters.AddWithValue("ID_LOGIN", obj.ID_LOGIN);
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
            //OracleCommand cmd = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            Int32 resultado = 0;
            try
            {
                conn = Conn();

                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandText = "select MAX(ID_LOGIN) as ID_LOGIN from LOGIN";
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
