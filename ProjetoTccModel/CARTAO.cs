using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccModel
{


    [Serializable()]
    public class CARTAO
    {
        #region Atributos
        private Int32 _ID_CARTAO = Int32.MinValue;
        private Int32 _ID_COLUNA = Int32.MinValue;
        private Int32 _ID_GRUPO = Int32.MinValue;
        private String _NM_OBS_ALUNO = String.Empty;
        private String _NM_OBS_ORIENTADOR = String.Empty;
        private String _NM_TITULO = String.Empty;
        private String _IS_VALIDACAO = String.Empty;
        #endregion

        #region Propriedades
        public int ID_CARTAO { get => _ID_CARTAO; set => _ID_CARTAO = value; }
        public int ID_COLUNA { get => _ID_COLUNA; set => _ID_COLUNA = value; }
        public int ID_GRUPO { get => _ID_GRUPO; set => _ID_GRUPO = value; }
        public string NM_OBS_ALUNO { get => _NM_OBS_ALUNO; set => _NM_OBS_ALUNO = value; }
        public string NM_OBS_ORIENTADOR { get => _NM_OBS_ORIENTADOR; set => _NM_OBS_ORIENTADOR = value; }
        public string NM_TITULO { get => _NM_TITULO; set => _NM_TITULO = value; }
        public string IS_VALIDACAO { get => _IS_VALIDACAO; set => _IS_VALIDACAO = value; }
        #endregion

        #region override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this._ID_CARTAO != Int32.MinValue) { sb.Append("[ID_CARTAO: "); sb.Append(this.ID_CARTAO); sb.Append("]"); }
            if (this._ID_COLUNA != Int32.MinValue) { sb.Append("[ID_COLUNA: "); sb.Append(this.ID_COLUNA); sb.Append("]"); }
            if (this._ID_GRUPO != Int32.MinValue) { sb.Append("[ID_GRUPO: "); sb.Append(this.ID_GRUPO); sb.Append("]"); }
            if (this._NM_OBS_ALUNO != String.Empty) { sb.Append("[NM_OBS_ALUNO: "); sb.Append(this.NM_OBS_ALUNO); sb.Append("]"); }
            if (this._NM_OBS_ORIENTADOR != String.Empty) { sb.Append("[NM_OBS_ORIENTADOR: "); sb.Append(this.NM_OBS_ORIENTADOR); sb.Append("]"); }
            if (this._NM_TITULO != String.Empty) { sb.Append("[NM_TITULO: "); sb.Append(this.NM_TITULO); sb.Append("]"); }
            if (this._IS_VALIDACAO != String.Empty) { sb.Append("[IS_VALIDACAO: "); sb.Append(this.IS_VALIDACAO); sb.Append("]"); }
            return sb.ToString();
        }
        #endregion
    }
}
