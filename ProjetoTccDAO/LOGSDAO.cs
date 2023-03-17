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
    public class LOGSDAO
    {
        public LOGSDAO()
        {

        }

        private static Conexao Conn()
        {
            return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
        }

        public static List<LOGS> listaLOGS(LOGS filtro = null)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<LOGS> lista = new List<LOGS>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from LOGS ";
                if (filtro != null)
                {
                    if (filtro.ID != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID = @ID ";
                        cmd.Parameters.AddWithValue("ID", filtro.ID);
                        if (where == " where ") where = " and ";
                    }                    
                    if (filtro.DS_LOG != String.Empty)
                    {
                        cmd.CommandText += where + "DS_LOG = @DS_LOG ";
                        cmd.Parameters.AddWithValue("DS_LOG", filtro.DS_LOG.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.DT_MOVIMENTO != DateTime.MinValue)
                    {
                        cmd.CommandText += where + "DT_MOVIMENTO = @DT_MOVIMENTO ";
                        cmd.Parameters.AddWithValue("DT_MOVIMENTO", filtro.DT_MOVIMENTO);
                        if (where == " where ") where = " and ";
                    }                    
                }
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        LOGS obj = new LOGS();
                        obj.ID = (dr["ID"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID"]);                        
                        obj.DS_LOG = (dr["DS_LOG"] == DBNull.Value) ? String.Empty : dr["DS_LOG"].ToString();
                        obj.DT_MOVIMENTO = (dr["DT_MOVIMENTO"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["DT_MOVIMENTO"]);
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

        public static bool inserirLOGS(LOGS obj)
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
                #region insert tabela LOGSDAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = "insert into LOGS";
                cols = "(";
                vals = "(";
                if (obj.ID != Int32.MinValue)
                {
                    cols += "ID,";
                    vals += "@ID,";
                    cmd.Parameters.AddWithValue("ID", obj.ID);
                }                
                if (obj.DS_LOG != String.Empty)
                {
                    cols += "DS_LOG,";
                    vals += "@DS_LOG,";
                    cmd.Parameters.AddWithValue("DS_LOG", obj.DS_LOG.ToUpper());
                }
                if (obj.DT_MOVIMENTO != DateTime.MinValue)
                {
                    cols += "DT_MOVIMENTO,";
                    vals += "@DT_MOVIMENTO,";
                    cmd.Parameters.AddWithValue("DT_MOVIMENTO", obj.DT_MOVIMENTO);
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

        public static bool alteraLOGS(LOGS obj)
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
                #region update tabela LOGS
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " update LOGS set ";
                sets = "";
                if (obj.ID != Int32.MinValue)
                {
                    sets += " ID = @ID,";
                    cmd.Parameters.AddWithValue("ID", obj.ID);
                }                
                if (obj.DS_LOG != String.Empty)
                {
                    sets += " DS_LOG = @DS_LOG,";
                    cmd.Parameters.AddWithValue("DS_LOG", obj.DS_LOG.ToUpper());
                }
                if (obj.DT_MOVIMENTO != DateTime.MinValue)
                {
                    sets += " DT_MOVIMENTO = @DT_MOVIMENTO,";
                    cmd.Parameters.AddWithValue("DT_MOVIMENTO", obj.DT_MOVIMENTO);
                }                
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID = @ID";
                cmd.Parameters.AddWithValue("ID", obj.ID);
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

        public static bool deletaLOGS(LOGS obj)
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
                #region update tabela LOGS
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " DELETE FROM LOGS ";
                sets = "";

                if (obj.ID != Int32.MinValue)
                {
                    if (sets.EndsWith(","))
                        sets = sets.Remove(sets.Length - 1, 1);
                    cmd.CommandText += sets + " where ID = @ID";
                    cmd.Parameters.AddWithValue("ID", obj.ID);
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
                cmd.CommandText = "select MAX(ID) as ID from LOGS";
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
