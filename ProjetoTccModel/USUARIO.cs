using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{


    [Serializable()]
    public class USUARIO
    {
        #region Atributos
        private Int32 _ID_USUARIO = Int32.MinValue;
        private Int32 _ID_LOGIN = Int32.MinValue;
        private Int32 _ID_TIPO = Int32.MinValue;
        private Int32 _ID_CURSO = Int32.MinValue;        
        private String _NM_NOME = String.Empty;
        private Int32 _NR_MATRICULA = Int32.MinValue;
        private String _NM_EMAIL = String.Empty;
        private String _NM_TELEFONE = String.Empty;
        #endregion

        #region Propriedades
        public int ID_USUARIO { get => _ID_USUARIO; set => _ID_USUARIO = value; }
        public int ID_LOGIN { get => _ID_LOGIN; set => _ID_LOGIN = value; }
        public int ID_TIPO { get => _ID_TIPO; set => _ID_TIPO = value; }
        public int ID_CURSO { get => _ID_CURSO; set => _ID_CURSO = value; }        
        public string NM_NOME { get => _NM_NOME; set => _NM_NOME = value; }
        public int NR_MATRICULA { get => _NR_MATRICULA; set => _NR_MATRICULA = value; }
        public string NM_EMAIL { get => _NM_EMAIL; set => _NM_EMAIL = value; }
        public string NM_TELEFONE { get => _NM_TELEFONE; set => _NM_TELEFONE = value; }
        #endregion

        #region override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this._ID_USUARIO != Int32.MinValue) { sb.Append("[ID_USUARIO: "); sb.Append(this.ID_USUARIO); sb.Append("]"); }
            if (this._ID_LOGIN != Int32.MinValue) { sb.Append("[ID_LOGIN: "); sb.Append(this.ID_LOGIN); sb.Append("]"); }
            if (this._ID_TIPO != Int32.MinValue) { sb.Append("[ID_TIPO: "); sb.Append(this.ID_TIPO); sb.Append("]"); }
            if (this._ID_CURSO != Int32.MinValue) { sb.Append("[ID_CURSO: "); sb.Append(this.ID_CURSO); sb.Append("]"); }            
            if (this._NM_NOME != String.Empty) { sb.Append("[NM_NOME: "); sb.Append(this.NM_NOME); sb.Append("]"); }
            if (this._NR_MATRICULA != Int32.MinValue) { sb.Append("[NR_MATRICULA: "); sb.Append(this.NR_MATRICULA); sb.Append("]"); }
            if (this._NM_EMAIL != String.Empty) { sb.Append("[NM_EMAIL: "); sb.Append(this.NM_EMAIL); sb.Append("]"); }
            if (this._NM_TELEFONE != String.Empty) { sb.Append("[NM_TELEFONE: "); sb.Append(this.NM_TELEFONE); sb.Append("]"); }
            return sb.ToString();
        }
        #endregion
    }
}
