using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTccBusiness
{
    public static class Usuario
    {
        public static ProjetoTccModel.USUARIO pega(Int32 id_usuario)
        {
            try
            {
                ProjetoTccModel.USUARIO filtro = new ProjetoTccModel.USUARIO { ID_USUARIO = id_usuario };
                List<ProjetoTccModel.USUARIO> filtros = ProjetoTccDAO.USUARIODAO.listaUSUARIO(filtro);
                if (filtros.Count > 0)
                {
                    return filtros[0];
                }
                else
                {
                    return new ProjetoTccModel.USUARIO();
                }
            }
            catch
            {
                return new ProjetoTccModel.USUARIO();
            }
        }
        public static ProjetoTccModel.USUARIO pegaUsuario(Int32 id_login)
        {
            try
            {
                ProjetoTccModel.USUARIO filtro = new ProjetoTccModel.USUARIO { ID_LOGIN = id_login };
                List<ProjetoTccModel.USUARIO> filtros = ProjetoTccDAO.USUARIODAO.listaUSUARIO(filtro);
                if (filtros.Count > 0)
                {
                    return filtros[0];
                }
                else
                {
                    return new ProjetoTccModel.USUARIO();
                }
            }
            catch
            {
                return new ProjetoTccModel.USUARIO();
            }
        }
        public static ProjetoTccModel.TIPO_USUARIO pegaTipoUsuario(Int32 id_tipo)
        {
            try
            {
                ProjetoTccModel.TIPO_USUARIO filtro = new ProjetoTccModel.TIPO_USUARIO { ID_TIPO = id_tipo };
                List<ProjetoTccModel.TIPO_USUARIO> filtros = ProjetoTccDAO.TIPO_USUARIODAO.listaTIPO_USUARIO(filtro);
                if (filtros.Count > 0)
                {
                    return filtros[0];
                }
                else
                {
                    return new ProjetoTccModel.TIPO_USUARIO();
                }
            }
            catch
            {
                return new ProjetoTccModel.TIPO_USUARIO();
            }
        }

        public static ProjetoTccModel.GRUPO pegaGrupo(Int32 id_grupo)
        {
            try
            {
                ProjetoTccModel.GRUPO filtro = new ProjetoTccModel.GRUPO { ID_GRUPO = id_grupo };
                List<ProjetoTccModel.GRUPO> filtros = ProjetoTccDAO.GRUPODAO.listaGRUPO(filtro);
                if (filtros.Count > 0)
                {
                    return filtros[0];
                }
                else
                {
                    return new ProjetoTccModel.GRUPO();
                }
            }
            catch
            {
                return new ProjetoTccModel.GRUPO();
            }
        }

        public static ProjetoTccModel.GRUPO pegaGrupoAluno(Int32 id_usuario)
        {
            try
            {
                ProjetoTccModel.USUARIO_GRUPO filtro = new ProjetoTccModel.USUARIO_GRUPO { ID_USUARIO = id_usuario };
                List<ProjetoTccModel.USUARIO_GRUPO> filtros = ProjetoTccDAO.USUARIO_GRUPODAO.listaUSUARIO_GRUPO(filtro);
                if (filtros.Count > 0)
                {
                    return pegaGrupo(filtros[0].ID_GRUPO);
                }
                else
                {
                    return new ProjetoTccModel.GRUPO();
                }
            }
            catch
            {
                return new ProjetoTccModel.GRUPO();
            }
        }

        public static List<ProjetoTccModel.GRUPO> pegaGrupoOrientador(Int32 id_usuario)
        {
            try
            {                
                ProjetoTccModel.USUARIO_GRUPO filtro = new ProjetoTccModel.USUARIO_GRUPO { ID_USUARIO = id_usuario };
                List<ProjetoTccModel.USUARIO_GRUPO> filtros = ProjetoTccDAO.USUARIO_GRUPODAO.listaUSUARIO_GRUPO(filtro);
                if (filtros.Count > 0)
                {
                    List<ProjetoTccModel.GRUPO> grupos = new List<ProjetoTccModel.GRUPO>();
                    foreach (ProjetoTccModel.USUARIO_GRUPO item in filtros)
                    {
                        grupos.Add(pegaGrupo(item.ID_GRUPO));
                    }

                    return grupos;
                }
                else
                {
                    return new List<ProjetoTccModel.GRUPO>();
                }
            }
            catch
            {
                return new List<ProjetoTccModel.GRUPO>();
            }
        }
    }
}
