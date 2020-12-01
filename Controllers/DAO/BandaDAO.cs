using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class BandaDAO
    {

        public List<Banda> List() {
            List<Banda> lista = new List<Banda>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca
                string strSQL = "select Id, Nome from tblBanda";
                objDataTable = DAO.AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count <= 0)

                {
                    return lista;
                }

                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Banda objNovaBanda = new Banda();
                    objNovaBanda.Id = objLinha["Id"] != DBNull.Value ? Convert.ToInt32(objLinha["Id"]) : 0;
                    objNovaBanda.Nome = objLinha["Nome"] != DBNull.Value ? Convert.ToString(objLinha["Nome"]) : "";

                    lista.Add(objNovaBanda);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }  
        }

        public bool Create(Banda banda) {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (banda != null)
                {
                    //DAO.AcessoDadosMySQL.AdicionarParametros("@intId", banda.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@vchNome", banda.Nome);

                    string strSQL = "insert into tblBanda (Nome) values ( @vchNome); SELECT LAST_INSERT_ID();";
                    objRetorno = DAO.AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }

                int intResultado = 0;
                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                        return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Banda banda)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (banda != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@intId", banda.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@vchNome", banda.Nome);

                    string strSQL = "update tblBanda set Nome = @vchNome where Id = @intId; select @intId;";
                    objRetorno = DAO.AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }

                int intResultado = 0;
                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                        return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Banda banda)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (banda != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@intId", banda.Id);

                    string strSQL = "delete from tblBanda where Id = @intId; select @intId;";
                    objRetorno = DAO.AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }

                int intResultado = 0;
                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                        return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}