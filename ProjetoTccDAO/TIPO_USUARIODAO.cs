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
    public class TIPO_USUARIODAO
    {
        public TIPO_USUARIODAO()
        {

        }

        private static Conexao Conn()
        {
            return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
        }

        public static List<TIPO_USUARIO> listaTIPO_USUARIO(TIPO_USUARIO filtro = null)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<TIPO_USUARIO> lista = new List<TIPO_USUARIO>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from TIPO_USUARIO ";
                if (filtro != null)
                {
                    if (filtro.ID_TIPO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_TIPO = @ID_TIPO ";
                        cmd.Parameters.AddWithValue("ID_TIPO", filtro.ID_TIPO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_TIPO != String.Empty)
                    {
                        cmd.CommandText += where + "NM_TIPO = @NM_TIPO ";
                        cmd.Parameters.AddWithValue("NM_TIPO", filtro.NM_TIPO.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                }
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        TIPO_USUARIO obj = new TIPO_USUARIO();
                        obj.ID_TIPO = (dr["ID_TIPO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_TIPO"]);
                        obj.NM_TIPO = (dr["NM_TIPO"] == DBNull.Value) ? String.Empty : dr["NM_TIPO"].ToString();
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

        public static bool inserirTIPO_USUARIO(TIPO_USUARIO obj)
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
                #region insert tabela TIPO_USUARIODAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = "insert into TIPO_USUARIO";
                cols = "(";
                vals = "(";
                if (obj.ID_TIPO != Int32.MinValue)
                {
                    cols += "ID_TIPO,";
                    vals += "@ID_TIPO,";
                    cmd.Parameters.AddWithValue("ID_TIPO", obj.ID_TIPO);
                }
                if (obj.NM_TIPO != String.Empty)
                {
                    cols += "NM_TIPO,";
                    vals += "@NM_TIPO,";
                    cmd.Parameters.AddWithValue("NM_TIPO", obj.NM_TIPO.ToUpper());
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

        public static bool alteraTIPO_USUARIO(TIPO_USUARIO obj)
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
                #region update tabela TIPO_USUARIO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " update TIPO_USUARIO set ";
                sets = "";
                if (obj.ID_TIPO != Int32.MinValue)
                {
                    sets += " ID_TIPO = @ID_TIPO,";
                    cmd.Parameters.AddWithValue("ID_TIPO", obj.ID_TIPO);
                }
                if (obj.NM_TIPO != String.Empty)
                {
                    sets += " NM_TIPO = @NM_TIPO,";
                    cmd.Parameters.AddWithValue("NM_TIPO", obj.NM_TIPO.ToUpper());
                }
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_TIPO = @ID_TIPO";
                cmd.Parameters.AddWithValue("ID_TIPO", obj.ID_TIPO);
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

        public static bool deletaTIPO_USUARIO(TIPO_USUARIO obj)
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
                #region update tabela TIPO_USUARIO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " DELETE FROM TIPO_USUARIO ";
                sets = "";
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_TIPO = @ID_TIPO";
                cmd.Parameters.AddWithValue("ID_TIPO", obj.ID_TIPO);
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
                cmd.CommandText = "select MAX(ID_TIPO) as ID_TIPO from TIPO_USUARIO";
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
