using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{
    [Serializable()]
    public class TIPO_USUARIO
    {
        #region Atributos
        private Int32 _ID_TIPO = Int32.MinValue;
        private String _NM_TIPO = String.Empty;
        #endregion

        #region Propriedades
        public int ID_TIPO { get => _ID_TIPO; set => _ID_TIPO = value; }
        public string NM_TIPO { get => _NM_TIPO; set => _NM_TIPO = value; }
        #endregion

        #region override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this._ID_TIPO != Int32.MinValue) { sb.Append("[ID_TIPO: "); sb.Append(this.ID_TIPO); sb.Append("]"); }
            if (this._NM_TIPO != String.Empty) { sb.Append("[NM_TIPO: "); sb.Append(this.NM_TIPO); sb.Append("]"); }
            return sb.ToString();
        }
        #endregion
    }
}
