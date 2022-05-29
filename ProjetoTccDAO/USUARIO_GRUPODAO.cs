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
public class USUARIO_GRUPODAO
{
public USUARIO_GRUPODAO()
{

}

private static Conexao Conn()
{
return new Conexao(ProjetoTccConnect.Utilidade.GetStringConfiguracao("Diretorio.Banco"));
}

public static List<USUARIO_GRUPO> listaUSUARIO_GRUPO(USUARIO_GRUPO filtro = null)
{
DataTable dt = null;
SQLiteCommand cmd = null;
Conexao conn = null;
List<USUARIO_GRUPO> lista = new List<USUARIO_GRUPO>();
try
{
conn = Conn();
dt = new DataTable();
string where = " where ";
cmd = (SQLiteCommand)conn.novoCmd();
cmd.CommandType = CommandType.Text;
cmd.CommandText = "select * from USUARIO_GRUPO ";
if (filtro != null)
{
if (filtro.ID_USU_GRUP != Int32.MinValue)
{
cmd.CommandText += where + "ID_USU_GRUP = @ID_USU_GRUP ";
cmd.Parameters.AddWithValue("ID_USU_GRUP", filtro.ID_USU_GRUP);
if (where == " where ") where = " and ";
}
if (filtro.ID_GRUPO != Int32.MinValue)
{
cmd.CommandText += where + "ID_GRUPO = @ID_GRUPO ";
cmd.Parameters.AddWithValue("ID_GRUPO", filtro.ID_GRUPO);
if (where == " where ") where = " and ";
}
if (filtro.ID_USUARIO != Int32.MinValue)
{
cmd.CommandText += where + "ID_USUARIO = @ID_USUARIO ";
cmd.Parameters.AddWithValue("ID_USUARIO", filtro.ID_USUARIO);
if (where == " where ") where = " and ";
}
}
dt = conn.buscaTabela(cmd);

if (dt.Rows.Count > 0)
{
foreach (DataRow dr in dt.Rows)
{
USUARIO_GRUPO obj = new USUARIO_GRUPO();
obj.ID_USU_GRUP = (dr["ID_USU_GRUP"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_USU_GRUP"]);
obj.ID_GRUPO = (dr["ID_GRUPO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_GRUPO"]);
obj.ID_USUARIO = (dr["ID_USUARIO"] == DBNull.Value) ? Int32.MinValue : Convert.ToInt32(dr["ID_USUARIO"]);
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

public static bool inserirUSUARIO_GRUPO(USUARIO_GRUPO obj)
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
#region insert tabela USUARIO_GRUPODAO
cmd.Parameters.Clear();
cmd.CommandText = "";
cmd.CommandText = "insert into USUARIO_GRUPO";
cols = "(";
vals = "(";
if (obj.ID_USU_GRUP != Int32.MinValue)
{
cols += "ID_USU_GRUP,";
vals += "@ID_USU_GRUP,";
cmd.Parameters.AddWithValue("ID_USU_GRUP", obj.ID_USU_GRUP);
}
if (obj.ID_GRUPO != Int32.MinValue)
{
cols += "ID_GRUPO,";
vals += "@ID_GRUPO,";
cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
}
if (obj.ID_USUARIO != Int32.MinValue)
{
cols += "ID_USUARIO,";
vals += "@ID_USUARIO,";
cmd.Parameters.AddWithValue("ID_USUARIO", obj.ID_USUARIO);
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

public static bool alteraUSUARIO_GRUPO(USUARIO_GRUPO obj)
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
#region update tabela USUARIO_GRUPO
cmd.Parameters.Clear();
cmd.CommandText = "";
cmd.CommandText = " update USUARIO_GRUPO set ";
sets = "";
if (obj.ID_USU_GRUP != Int32.MinValue)
{
sets += " ID_USU_GRUP = @ID_USU_GRUP,";
cmd.Parameters.AddWithValue("ID_USU_GRUP", obj.ID_USU_GRUP);
}
if (obj.ID_GRUPO != Int32.MinValue)
{
sets += " ID_GRUPO = @ID_GRUPO,";
cmd.Parameters.AddWithValue("ID_GRUPO", obj.ID_GRUPO);
}
if (obj.ID_USUARIO != Int32.MinValue)
{
sets += " ID_USUARIO = @ID_USUARIO,";
cmd.Parameters.AddWithValue("ID_USUARIO", obj.ID_USUARIO);
}
if (sets.EndsWith(","))
sets = sets.Remove(sets.Length - 1, 1);
cmd.CommandText += sets + " where ID_USU_GRUP = @ID_USU_GRUP";
cmd.Parameters.AddWithValue("ID_USU_GRUP", obj.ID_USU_GRUP);
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

public static bool deletaUSUARIO_GRUPO(USUARIO_GRUPO obj)
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
#region update tabela USUARIO_GRUPO
cmd.Parameters.Clear();
cmd.CommandText = "";
cmd.CommandText = " DELETE FROM USUARIO_GRUPO ";
sets = "";
if (sets.EndsWith(","))
sets = sets.Remove(sets.Length - 1, 1);
cmd.CommandText += sets + " where ID_USU_GRUP = @ID_USU_GRUP";
cmd.Parameters.AddWithValue("ID_USU_GRUP", obj.ID_USU_GRUP);
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
cmd.CommandText = "select MAX(ID_USU_GRUP) as ID_USU_GRUP from USUARIO_GRUPO";
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
