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
    public class GRUPODAO
    {
        public GRUPODAO()
        {

        }

        private static Conexao Conn()
        {
            return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
        }

        public static List<GRUPO> listaGRUPO(GRUPO filtro = null)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<GRUPO> lista = new List<GRUPO>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from GRUPO ";
                if (filtro != null)
                {
                    if (filtro.ID_GRUPO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_GRUPO = @ID_GRUPO ";
                        cmd.Parameters.AddWithValue("ID_GRUPO", filtro.ID_GRUPO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_TEMA != String.Empty)
                    {
                        cmd.CommandText += where + "NM_TEMA = @NM_TEMA ";
                        cmd.Parameters.AddWithValue("NM_TEMA", filtro.NM_TEMA.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.DT_APRESENTACAO != DateTime.MinValue)
                    {
                        cmd.CommandText += where + "DT_APRESENTACAO = @DT_APRESENTACAO ";
                        cmd.Parameters.AddWithValue("DT_APRESENTACAO", filtro.DT_APRESENTACAO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.DS_STATUS != String.Empty)
                    {
                        cmd.CommandText += where + "DS_STATUS = @DS_STATUS ";
                        cmd.Parameters.AddWithValue("DS_STATUS", filtro.DS_STATUS.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                }
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        GRUPO obj = new GRUPO();
                        obj.ID_GRUPO = (dr["ID_GRUPO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_GRUPO"]);
                        obj.NM_TEMA = (dr["NM_TEMA"] == DBNull.Value) ? String.Empty : dr["NM_TEMA"].ToString();
                        obj.DT_APRESENTACAO = (dr["DT_APRESENTACAO"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_APRESENTACAO"]);
                        obj.DS_STATUS = (dr["DS_STATUS"] == DBNull.Value) ? String.Empty : dr["DS_STATUS"].ToString();
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

        public static List<GRUPO> listaGRUPOUsuario(Int32 id_usuario)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<GRUPO> lista = new List<GRUPO>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select * from(select b.* from USUARIO_GRUPO a, GRUPO b where b.ID_GRUPO = a.ID_GRUPO and a.ID_USUARIO = {id_usuario}) a ";
                
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        GRUPO obj = new GRUPO();
                        obj.ID_GRUPO = (dr["ID_GRUPO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_GRUPO"]);
                        obj.NM_TEMA = (dr["NM_TEMA"] == DBNull.Value) ? String.Empty : dr["NM_TEMA"].ToString();
                        obj.DT_APRESENTACAO = (dr["DT_APRESENTACAO"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_APRESENTACAO"]);
                        obj.DS_STATUS = (dr["DS_STATUS"] == DBNull.Value) ? String.Empty : dr["DS_STATUS"].ToString();
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

        public static bool inserirGRUPO(GRUPO obj)
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
                #region insert tabela GRUPODAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = "insert into GRUPO";
                cols = "(";
                vals = "(";
                if (obj.ID_GRUPO != Int32.MinValue)
                {
                    cols += "ID_GRUPO,";
                    vals += "@ID_GRUPO,";
                    cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
                }
                if (obj.NM_TEMA != String.Empty)
                {
                    cols += "NM_TEMA,";
                    vals += "@NM_TEMA,";
                    cmd.Parameters.AddWithValue("NM_TEMA", obj.NM_TEMA.ToUpper());
                }
                if (obj.DT_APRESENTACAO != DateTime.MinValue)
                {
                    cols += "DT_APRESENTACAO,";
                    vals += "@DT_APRESENTACAO,";
                    cmd.Parameters.AddWithValue("DT_APRESENTACAO", obj.DT_APRESENTACAO);
                }
                if (obj.DS_STATUS != String.Empty)
                {
                    cols += "DS_STATUS,";
                    vals += "@DS_STATUS,";
                    cmd.Parameters.AddWithValue("DS_STATUS", obj.DS_STATUS.ToUpper());
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

        public static bool alteraGRUPO(GRUPO obj)
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
                #region update tabela GRUPO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " update GRUPO set ";
                sets = "";
                if (obj.ID_GRUPO != Int32.MinValue)
                {
                    sets += " ID_GRUPO = @ID_GRUPO,";
                    cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
                }
                if (obj.NM_TEMA != String.Empty)
                {
                    sets += " NM_TEMA = @NM_TEMA,";
                    cmd.Parameters.AddWithValue("NM_TEMA", obj.NM_TEMA.ToUpper());
                }
                if (obj.DT_APRESENTACAO != DateTime.MinValue)
                {
                    sets += " DT_APRESENTACAO = @DT_APRESENTACAO,";
                    cmd.Parameters.AddWithValue("DT_APRESENTACAO", obj.DT_APRESENTACAO);
                }
                if (obj.DS_STATUS != String.Empty)
                {
                    sets += " DS_STATUS = @DS_STATUS,";
                    cmd.Parameters.AddWithValue("DS_STATUS", obj.DS_STATUS.ToUpper());
                }
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_GRUPO = @ID_GRUPO";
                cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
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

        public static bool deletaGRUPO(GRUPO obj)
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
                #region update tabela GRUPO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " DELETE FROM GRUPO ";
                sets = "";
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_GRUPO = @ID_GRUPO";
                cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
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
                cmd.CommandText = "select MAX(ID_GRUPO) as ID_GRUPO from GRUPO";
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
