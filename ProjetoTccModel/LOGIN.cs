using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{
    [Serializable()]
    public class LOGIN
    {
        private Int32 _ID_LOGIN = Int32.MinValue;
        private String _NM_USER = String.Empty;
        private String _NM_PASS = String.Empty;        

        public int ID_LOGIN { get => _ID_LOGIN; set => _ID_LOGIN = value; }
        public string NM_USER { get => _NM_USER; set => _NM_USER = value; }
        public string NM_PASS { get => _NM_PASS; set => _NM_PASS = value; }        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this._ID_LOGIN != Int32.MinValue) { sb.Append("[ID_LOGIN :"); sb.Append(this.ID_LOGIN); sb.Append("]"); }
            if (this._NM_USER != String.Empty) { sb.Append("[NM_USER :"); sb.Append(this.NM_USER); sb.Append("]"); }
            if (this._NM_PASS != String.Empty) { sb.Append("[NM_PASS :"); sb.Append(this.NM_PASS); sb.Append("]"); }            
            return sb.ToString();
        }
    }
}
