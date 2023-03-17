using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{

    [Serializable()]
    public class LOGS
    {
        #region Atributos
        private Int32 _ID = Int32.MinValue;        
        private String _DS_LOG = String.Empty;        
        private DateTime _DT_MOVIMENTO = DateTime.MinValue;
        
        #endregion

        #region Propriedades        
        public int ID { get => _ID; set => _ID = value; }
        public string DS_LOG { get => _DS_LOG; set => _DS_LOG = value; }
        public DateTime DT_MOVIMENTO { get => _DT_MOVIMENTO; set => _DT_MOVIMENTO = value; }
        #endregion

        #region override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this._ID != Int32.MinValue) { sb.Append("[ID: "); sb.Append(this.ID); sb.Append("]"); }
            if (this._DS_LOG != String.Empty) { sb.Append("[DS_LOG: "); sb.Append(this.DS_LOG); sb.Append("]"); }            
            if (this._DT_MOVIMENTO != DateTime.MinValue) { sb.Append("[DT_MOVIMENTO: "); sb.Append(this.DT_MOVIMENTO); sb.Append("]"); }
            return sb.ToString();
        }
        #endregion
    }
}
