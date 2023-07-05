using Cl3AndreeChiquis.Models;
using System.Data.SqlClient;

namespace Cl3AndreeChiquis.Dao
{
    public class ArticulosDAO
    {
        private readonly string cad_cn;

        public ArticulosDAO( IConfiguration config)
        {
            cad_cn = config.GetConnectionString("cn1");
        }

        public List<Articulos> ListarArticulos()
        {
            var list = new List<Articulos>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cad_cn, "ListarProductosDeBajaNo");
            while (dr.Read())
            {
                list.Add(new Articulos()
                {
                    cod_art = dr.GetString(0),
                    nom_art = dr.GetString(1),
                    uni_med = dr.GetString(2),
                    pre_art = dr.GetDecimal(3),
                    stk_art = dr.GetInt32(4),
                    de_baja = dr.GetString(5)
                });
            }
            dr.Close();

            return list;
        }

        public List<Articulos> ListArticulosfiltro(string filtro)
        {
            var lista = new List<Articulos>();
            //
            SqlDataReader dr = SqlHelper.ExecuteReader(
                   cad_cn, "ListarArticulosPorNombreOCod", filtro);
            //
            while (dr.Read())
            {
                lista.Add(new Articulos()
                {
                    cod_art = dr.GetString(0),
                    nom_art = dr.GetString(1),
                    uni_med = dr.GetString(2),
                    pre_art = dr.GetDecimal(3),
                    stk_art = dr.GetInt32(4),
                    de_baja = dr.GetString(5)
                });
            }
            dr.Close();
            //
            return lista;
        }

        public string DardeBaja(string cod_art)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cad_cn, "DAR_BAJA", cod_art);
                mensaje = $"El Articulo con codigo: {cod_art} " + "Fue dado de baja";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }
    }
}
