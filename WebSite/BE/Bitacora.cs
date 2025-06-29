using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public string Username { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        public int Criticidad { get; set; }
        public Bitacora(string nUsername, DateTime nFecha, TimeSpan nHora, string nModulo, string nDescripcion, int nCriticidad, int nIdBitacora = 0)
        {
            IdBitacora = nIdBitacora;
            Username = nUsername;
            Fecha = nFecha;
            Hora = nHora;
            Modulo = nModulo;
            Descripcion = nDescripcion;
            Criticidad = nCriticidad;
        }
    }
}
