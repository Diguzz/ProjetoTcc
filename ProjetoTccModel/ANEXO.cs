using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{


[Serializable()]
public class ANEXO
{
#region Atributos
private Int32 _ID_ANEXO = Int32.MinValue;
private Int32 _ID_CARTAO = Int32.MinValue;
private Int32 _ID_GRUPO = Int32.MinValue;
private Int32 _ID_TIPO = Int32.MinValue;
private String _NM_ARQUIVO = String.Empty;
private DateTime _DT_CRIACAO = DateTime.MinValue;
private String _DS_CAMINHO = String.Empty;
#endregion

#region Propriedades
public int ID_ANEXO {get => _ID_ANEXO; set => _ID_ANEXO = value; }
public int ID_CARTAO {get => _ID_CARTAO; set => _ID_CARTAO = value; }
public int ID_GRUPO {get => _ID_GRUPO; set => _ID_GRUPO = value; }
public int ID_TIPO {get => _ID_TIPO; set => _ID_TIPO = value; }
public string NM_ARQUIVO {get => _NM_ARQUIVO; set => _NM_ARQUIVO = value; }
public DateTime DT_CRIACAO {get => _DT_CRIACAO; set => _DT_CRIACAO = value; }
public string DS_CAMINHO {get => _DS_CAMINHO; set => _DS_CAMINHO = value; }
#endregion

#region override
public override string ToString()
{
StringBuilder sb = new StringBuilder();
if (this._ID_ANEXO != Int32.MinValue) { sb.Append("[ID_ANEXO: "); sb.Append(this.ID_ANEXO); sb.Append("]"); }
if (this._ID_CARTAO != Int32.MinValue) { sb.Append("[ID_CARTAO: "); sb.Append(this.ID_CARTAO); sb.Append("]"); }
if (this._ID_GRUPO != Int32.MinValue) { sb.Append("[ID_GRUPO: "); sb.Append(this.ID_GRUPO); sb.Append("]"); }
if (this._ID_TIPO != Int32.MinValue) { sb.Append("[ID_TIPO: "); sb.Append(this.ID_TIPO); sb.Append("]"); }
if (this._NM_ARQUIVO != String.Empty) { sb.Append("[NM_ARQUIVO: "); sb.Append(this.NM_ARQUIVO); sb.Append("]"); }
if (this._DT_CRIACAO != DateTime.MinValue) { sb.Append("[DT_CRIACAO: "); sb.Append(this.DT_CRIACAO); sb.Append("]"); }
if (this._DS_CAMINHO != String.Empty) { sb.Append("[DS_CAMINHO: "); sb.Append(this.DS_CAMINHO); sb.Append("]"); }
return sb.ToString();
}
#endregion
}
}
