using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{


[Serializable()]
public class GRUPO
{
#region Atributos
private Int32 _ID_GRUPO = Int32.MinValue;
private String _NM_TEMA = String.Empty;
private DateTime _DT_APRESENTACAO = DateTime.MinValue;
private String _DS_STATUS = String.Empty;
#endregion

#region Propriedades
public int ID_GRUPO {get => _ID_GRUPO; set => _ID_GRUPO = value; }
public string NM_TEMA {get => _NM_TEMA; set => _NM_TEMA = value; }
public DateTime DT_APRESENTACAO {get => _DT_APRESENTACAO; set => _DT_APRESENTACAO = value; }
public string DS_STATUS {get => _DS_STATUS; set => _DS_STATUS = value; }
#endregion

#region override
public override string ToString()
{
StringBuilder sb = new StringBuilder();
if (this._ID_GRUPO != Int32.MinValue) { sb.Append("[ID_GRUPO: "); sb.Append(this.ID_GRUPO); sb.Append("]"); }
if (this._NM_TEMA != String.Empty) { sb.Append("[NM_TEMA: "); sb.Append(this.NM_TEMA); sb.Append("]"); }
if (this._DT_APRESENTACAO != DateTime.MinValue) { sb.Append("[DT_APRESENTACAO: "); sb.Append(this.DT_APRESENTACAO); sb.Append("]"); }
if (this._DS_STATUS != String.Empty) { sb.Append("[DS_STATUS: "); sb.Append(this.DS_STATUS); sb.Append("]"); }
return sb.ToString();
}
#endregion
}
}
