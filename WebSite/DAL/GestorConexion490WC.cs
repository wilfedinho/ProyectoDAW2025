using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GestorConexion490WC
    {
        public static SqlConnection DevolverConexion()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=BD_PROYECTODAW;Integrated Security=True");
        }
    }
}
