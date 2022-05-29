using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ProjetoTccConnect
{
    public class Conexao : IDisposable
    {
        private string connstring;

        public Conexao(string connstring)
        {
            conn = null;
            trans = null;
            this.connstring = connstring;
        }

        #region " Conexão "

        private IDbConnection conn;

        private void abreConnexao()
        {
            if (conn == null)
                conn = novoConn();

            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public void fechaConnexao()
        {
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Dispose();
            }
        }

        private IDbConnection novoConn()
        {
            return new SQLiteConnection(this.connstring);
        }

        private IDbDataAdapter novoDa()
        {
            return new SQLiteDataAdapter();
        }

        public IDbCommand novoCmd()
        {
            if (conn == null)
                conn = novoConn();

            IDbCommand tmp = conn.CreateCommand();
            
            return (SQLiteCommand)tmp;
        }

        #endregion

        #region " Transaction "

        private IDbTransaction trans;

        public void beginTransaction()
        {
            abreConnexao();
            if (trans == null)
                trans = conn.BeginTransaction();
        }

        public void commit()
        {
            if (trans != null)
                trans.Commit();
        }

        public void rollback()
        {
            if (trans != null)
                trans.Rollback();
        }

        public void endTransaction()
        {
            if (trans != null)
            {
                trans.Dispose();
                trans = null;
            }
        }

        #endregion      

        public DataTable buscaTabela(IDbCommand cmd)
        {
            DataSet ds = null;
            try
            {
                trataParameternull(cmd);
                ds = buscaDataSet(cmd);
                return ds.Tables[0];
            }
            finally
            {
                if (ds != null)
                    ds.Dispose();
            }
        }

        public DataSet buscaDataSet(IDbCommand cmd)
        {

            IDbDataAdapter da = null;
            DataSet ds = null;
            trataParameternull(cmd);
            ds = new DataSet();
            abreConnexao();
            da = novoDa();
            cmd.Connection = conn;
            cmd.Transaction = trans;            
            da.SelectCommand = cmd;
            da.Fill(ds);

            return ds;
        }

        public IDataReader buscaDataReader(IDbCommand cmd)
        {
            IDataReader dr;
            trataParameternull(cmd);
            abreConnexao();
            cmd.Connection = conn;
            cmd.Transaction = trans;

            dr = cmd.ExecuteReader();
            return dr;
        }

        public int executaNonQuery(IDbCommand cmd)
        {
            trataParameternull(cmd);
            abreConnexao();
            cmd.Connection = conn;
            cmd.Transaction = trans;

            return cmd.ExecuteNonQuery();
        }

        public bool existeRegistro(IDbCommand cmd)
        {
            IDataReader dr = null;
            try
            {
                trataParameternull(cmd);
                abreConnexao();
                cmd.Connection = conn;
                cmd.Transaction = trans;

                dr = cmd.ExecuteReader();
                return dr.Read();
            }
            finally
            {
                if (dr != null)
                {
                    if (!dr.IsClosed) dr.Close();
                }
            }
        }

        public object pegaScalar(IDbCommand cmd)
        {
            abreConnexao();
            trataParameternull(cmd);
            cmd.Connection = conn;
            cmd.Transaction = trans;

            object dado = cmd.ExecuteScalar();
            return dado;
        }

        private void trataParameternull(IDbCommand cmd)
        {
            foreach (IDbDataParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (Parameter.Value is DateTime && (DateTime)Parameter.Value == DateTime.MinValue)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (Parameter.Value is Int32 && (Int32)Parameter.Value == Int32.MinValue)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (Parameter.Value is Int64 && (Int64)Parameter.Value == Int64.MinValue)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (Parameter.Value is Int16 && (Int16)Parameter.Value == Int16.MinValue)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (Parameter.Value is Double && (Double)Parameter.Value == Double.MinValue)
                {
                    Parameter.Value = DBNull.Value;
                }
                else if (Parameter.Value is string && (string)Parameter.Value == string.Empty)
                {
                    //Adicionei essa verificação pq senão nunca teríamos NULL no banco onde fosse "string"
                    //pelo fato de poder salvar como string vazia, senão teríamos que fazer na mão campo-a-campo 
                    Parameter.Value = DBNull.Value;
                }
                else if (Parameter.Value is string)
                {
                    Parameter.Value = Parameter.Value.ToString().ToUpper();
                }
            }

        }

        ~Conexao()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            fechaConnexao();
            endTransaction();
            GC.SuppressFinalize(this);
        }
    }

    public static class Utilidade
    {
        public static string GetStringConfiguracao(string chave, bool acceptNull = false)
        {
            var config = ConfigurationManager.AppSettings[chave];
            if (string.IsNullOrWhiteSpace(config) && !acceptNull)
                throw new ConfigurationErrorsException($"Não foi encontrada a chave de configuração {chave}");

            return config;
        }
    }
}
