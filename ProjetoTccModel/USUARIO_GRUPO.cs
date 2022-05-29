using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{


[Serializable()]
public class USUARIO_GRUPO
{
#region Atributos
private Int32 _ID_USU_GRUP = Int32.MinValue;
private Int32 _ID_GRUPO = Int32.MinValue;
private Int32 _ID_USUARIO = Int32.MinValue;
#endregion

#region Propriedades
public int ID_USU_GRUP {get => _ID_USU_GRUP; set => _ID_USU_GRUP = value; }
public int ID_GRUPO {get => _ID_GRUPO; set => _ID_GRUPO = value; }
public int ID_USUARIO {get => _ID_USUARIO; set => _ID_USUARIO = value; }
#endregion

#region override
public override string ToString()
{
StringBuilder sb = new StringBuilder();
if (this._ID_USU_GRUP != Int32.MinValue) { sb.Append("[ID_USU_GRUP: "); sb.Append(this.ID_USU_GRUP); sb.Append("]"); }
if (this._ID_GRUPO != Int32.MinValue) { sb.Append("[ID_GRUPO: "); sb.Append(this.ID_GRUPO); sb.Append("]"); }
if (this._ID_USUARIO != Int32.MinValue) { sb.Append("[ID_USUARIO: "); sb.Append(this.ID_USUARIO); sb.Append("]"); }
return sb.ToString();
}
#endregion
}
}
