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
    public class USUARIODAO
    {
        public USUARIODAO()
        {

        }

        private static Conexao Conn()
        {
            return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
        }

        public static List<USUARIO> listaUSUARIO(USUARIO filtro = null)
        {
            DataTable dt = null;
            SQLiteCommand cmd = null;
            Conexao conn = null;
            List<USUARIO> lista = new List<USUARIO>();
            try
            {
                conn = Conn();
                dt = new DataTable();
                string where = " where ";
                cmd = (SQLiteCommand)conn.novoCmd();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from USUARIO ";
                if (filtro != null)
                {
                    if (filtro.ID_USUARIO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_USUARIO = @ID_USUARIO ";
                        cmd.Parameters.AddWithValue("ID_USUARIO", filtro.ID_USUARIO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.ID_LOGIN != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_LOGIN = @ID_LOGIN ";
                        cmd.Parameters.AddWithValue("ID_LOGIN", filtro.ID_LOGIN);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.ID_TIPO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_TIPO = @ID_TIPO ";
                        cmd.Parameters.AddWithValue("ID_TIPO", filtro.ID_TIPO);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.ID_CURSO != Int32.MinValue)
                    {
                        cmd.CommandText += where + "ID_CURSO = @ID_CURSO ";
                        cmd.Parameters.AddWithValue("ID_CURSO", filtro.ID_CURSO);
                        if (where == " where ") where = " and ";
                    }                    
                    if (filtro.NM_NOME != String.Empty)
                    {
                        cmd.CommandText += where + "NM_NOME = @NM_NOME ";
                        cmd.Parameters.AddWithValue("NM_NOME", filtro.NM_NOME.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NR_MATRICULA != Int32.MinValue)
                    {
                        cmd.CommandText += where + "NR_MATRICULA = @NR_MATRICULA ";
                        cmd.Parameters.AddWithValue("NR_MATRICULA", filtro.NR_MATRICULA);
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_EMAIL != String.Empty)
                    {
                        cmd.CommandText += where + "NM_EMAIL = @NM_EMAIL ";
                        cmd.Parameters.AddWithValue("NM_EMAIL", filtro.NM_EMAIL.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                    if (filtro.NM_TELEFONE != String.Empty)
                    {
                        cmd.CommandText += where + "NM_TELEFONE = @NM_TELEFONE ";
                        cmd.Parameters.AddWithValue("NM_TELEFONE", filtro.NM_TELEFONE.ToUpper());
                        if (where == " where ") where = " and ";
                    }
                }
                dt = conn.buscaTabela(cmd);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        USUARIO obj = new USUARIO();
                        obj.ID_USUARIO = (dr["ID_USUARIO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_USUARIO"]);
                        obj.ID_LOGIN = (dr["ID_LOGIN"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_LOGIN"]);
                        obj.ID_TIPO = (dr["ID_TIPO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_TIPO"]);
                        obj.ID_CURSO = (dr["ID_CURSO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_CURSO"]);                        
                        obj.NM_NOME = (dr["NM_NOME"] == DBNull.Value) ? String.Empty : dr["NM_NOME"].ToString();
                        obj.NR_MATRICULA = (dr["NR_MATRICULA"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["NR_MATRICULA"]);
                        obj.NM_EMAIL = (dr["NM_EMAIL"] == DBNull.Value) ? String.Empty : dr["NM_EMAIL"].ToString();
                        obj.NM_TELEFONE = (dr["NM_TELEFONE"] == DBNull.Value) ? String.Empty : dr["NM_TELEFONE"].ToString();
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

        public static bool inserirUSUARIO(USUARIO obj)
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
                #region insert tabela USUARIODAO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = "insert into USUARIO";
                cols = "(";
                vals = "(";
                if (obj.ID_USUARIO != Int32.MinValue)
                {
                    cols += "ID_USUARIO,";
                    vals += "@ID_USUARIO,";
                    cmd.Parameters.AddWithValue("ID_USUARIO", obj.ID_USUARIO);
                }
                if (obj.ID_LOGIN != Int32.MinValue)
                {
                    cols += "ID_LOGIN,";
                    vals += "@ID_LOGIN,";
                    cmd.Parameters.AddWithValue("ID_LOGIN", obj.ID_LOGIN);
                }
                if (obj.ID_TIPO != Int32.MinValue)
                {
                    cols += "ID_TIPO,";
                    vals += "@ID_TIPO,";
                    cmd.Parameters.AddWithValue("ID_TIPO", obj.ID_TIPO);
                }
                if (obj.ID_CURSO != Int32.MinValue)
                {
                    cols += "ID_CURSO,";
                    vals += "@ID_CURSO,";
                    cmd.Parameters.AddWithValue("ID_CURSO", obj.ID_CURSO);
                }                
                if (obj.NM_NOME != String.Empty)
                {
                    cols += "NM_NOME,";
                    vals += "@NM_NOME,";
                    cmd.Parameters.AddWithValue("NM_NOME", obj.NM_NOME.ToUpper());
                }
                if (obj.NR_MATRICULA != Int32.MinValue)
                {
                    cols += "NR_MATRICULA,";
                    vals += "@NR_MATRICULA,";
                    cmd.Parameters.AddWithValue("NR_MATRICULA", obj.NR_MATRICULA);
                }
                if (obj.NM_EMAIL != String.Empty)
                {
                    cols += "NM_EMAIL,";
                    vals += "@NM_EMAIL,";
                    cmd.Parameters.AddWithValue("NM_EMAIL", obj.NM_EMAIL.ToUpper());
                }
                if (obj.NM_TELEFONE != String.Empty)
                {
                    cols += "NM_TELEFONE,";
                    vals += "@NM_TELEFONE,";
                    cmd.Parameters.AddWithValue("NM_TELEFONE", obj.NM_TELEFONE.ToUpper());
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

        public static bool alteraUSUARIO(USUARIO obj)
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
                #region update tabela USUARIO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " update USUARIO set ";
                sets = "";
                if (obj.ID_USUARIO != Int32.MinValue)
                {
                    sets += " ID_USUARIO = @ID_USUARIO,";
                    cmd.Parameters.AddWithValue("ID_USUARIO", obj.ID_USUARIO);
                }
                if (obj.ID_LOGIN != Int32.MinValue)
                {
                    sets += " ID_LOGIN = @ID_LOGIN,";
                    cmd.Parameters.AddWithValue("ID_LOGIN", obj.ID_LOGIN);
                }
                if (obj.ID_TIPO != Int32.MinValue)
                {
                    sets += " ID_TIPO = @ID_TIPO,";
                    cmd.Parameters.AddWithValue("ID_TIPO", obj.ID_TIPO);
                }
                if (obj.ID_CURSO != Int32.MinValue)
                {
                    sets += " ID_CURSO = @ID_CURSO,";
                    cmd.Parameters.AddWithValue("ID_CURSO", obj.ID_CURSO);
                }                
                if (obj.NM_NOME != String.Empty)
                {
                    sets += " NM_NOME = @NM_NOME,";
                    cmd.Parameters.AddWithValue("NM_NOME", obj.NM_NOME.ToUpper());
                }
                if (obj.NR_MATRICULA != Int32.MinValue)
                {
                    sets += " NR_MATRICULA = @NR_MATRICULA,";
                    cmd.Parameters.AddWithValue("NR_MATRICULA", obj.NR_MATRICULA);
                }
                if (obj.NM_EMAIL != String.Empty)
                {
                    sets += " NM_EMAIL = @NM_EMAIL,";
                    cmd.Parameters.AddWithValue("NM_EMAIL", obj.NM_EMAIL.ToUpper());
                }
                if (obj.NM_TELEFONE != String.Empty)
                {
                    sets += " NM_TELEFONE = @NM_TELEFONE,";
                    cmd.Parameters.AddWithValue("NM_TELEFONE", obj.NM_TELEFONE.ToUpper());
                }
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_USUARIO = @ID_USUARIO";
                cmd.Parameters.AddWithValue("ID_USUARIO", obj.ID_USUARIO);
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

        public static bool deletaUSUARIO(USUARIO obj)
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
                #region update tabela USUARIO
                cmd.Parameters.Clear();
                cmd.CommandText = "";
                cmd.CommandText = " DELETE FROM USUARIO ";
                sets = "";
                if (sets.EndsWith(","))
                    sets = sets.Remove(sets.Length - 1, 1);
                cmd.CommandText += sets + " where ID_USUARIO = @ID_USUARIO";
                cmd.Parameters.AddWithValue("ID_USUARIO", obj.ID_USUARIO);
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
                cmd.CommandText = "select MAX(ID_USUARIO) as ID_USUARIO from USUARIO";
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
