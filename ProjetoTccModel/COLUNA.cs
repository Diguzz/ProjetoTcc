using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{


    [Serializable()]
    public class COLUNA
    {
        #region Atributos
        private Int32 _ID_COLUNA = Int32.MinValue;
        private String _NM_COLUNA = String.Empty;
        #endregion

        #region Propriedades
        public int ID_COLUNA { get => _ID_COLUNA; set => _ID_COLUNA = value; }
        public string NM_COLUNA { get => _NM_COLUNA; set => _NM_COLUNA = value; }
        #endregion

        #region override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this._ID_COLUNA != Int32.MinValue) { sb.Append("[ID_COLUNA: "); sb.Append(this.ID_COLUNA); sb.Append("]"); }
            if (this._NM_COLUNA != String.Empty) { sb.Append("[NM_COLUNA: "); sb.Append(this.NM_COLUNA); sb.Append("]"); }
            return sb.ToString();
        }
        #endregion
    }
}
