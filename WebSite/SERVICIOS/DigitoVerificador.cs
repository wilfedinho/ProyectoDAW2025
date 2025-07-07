using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DAL.Negocio;
using DAL.Tecnica;

namespace SERVICIOS
{
    public class DigitoVerificador
    {
        public string CalcularDVH(object obj)
        {
            var sb = new StringBuilder();
            Encryptador cifrador = new Encryptador();
            if (obj is Usuario usu)
            {
                sb.Append(usu.Username);
                sb.Append(usu.Nombre);
                sb.Append(usu.Apellido);
                sb.Append(usu.DNI);
                sb.Append(usu.Contraseña);
                sb.Append(usu.Email);
                sb.Append(usu.Rol);
            }
            if (obj is Beneficio ben)
            {
                sb.Append(ben.CodigoBeneficio);
                sb.Append(ben.Nombre);
                sb.Append(ben.PrecioEstrella);
                sb.Append(ben.CantidadBeneficioReclamo);
                sb.Append(ben.DescuentoAplicar);
            }
            if (obj is Boleto bol)
            {
                if (bol is BoletoIDA)
                {
                    sb.Append(bol.IDBoleto);
                    sb.Append(bol.Origen);
                    sb.Append(bol.Destino);
                    sb.Append(bol.FechaPartida);
                    sb.Append(bol.FechaLlegada);
                    sb.Append(bol.IsVendido);
                    sb.Append(bol.EquipajePermitido);
                    sb.Append(bol.ClaseBoleto);
                    sb.Append(bol.Precio);
                    sb.Append(bol.Titular);
                    sb.Append(bol.NumeroAsiento);
                    sb.Append(bol.BeneficioAplicado);
                }
                if (bol is BoletoIDAVUELTA bolIV)
                {
                    sb.Append(bolIV.IDBoleto);
                    sb.Append(bolIV.Origen);
                    sb.Append(bolIV.Destino);
                    sb.Append(bolIV.FechaPartida);
                    sb.Append(bolIV.FechaLlegada);
                    sb.Append(bolIV.FechaPartidaVUELTA);
                    sb.Append(bolIV.FechaLlegadaVUELTA);
                    sb.Append(bolIV.IsVendido);
                    sb.Append(bolIV.EquipajePermitido);
                    sb.Append(bolIV.ClaseBoleto);
                    sb.Append(bolIV.Precio);
                    sb.Append(bolIV.Titular);
                    sb.Append(bolIV.NumeroAsiento);
                    sb.Append(bolIV.BeneficioAplicado);
                }
            }
            if (obj is Bitacora bit)
            {
                sb.Append(bit.IdBitacora);
                sb.Append(bit.Username);
                sb.Append(bit.Fecha.ToString(@"yyyy-MM-dd"));
                sb.Append(bit.Hora.ToString(@"hh\:mm\:ss"));
                sb.Append(bit.Modulo);
                sb.Append(bit.Descripcion);
                sb.Append(bit.Criticidad);
            }
            return cifrador.EncryptadorIrreversible(sb.ToString());
        }

        public string CalcularDVV(string nomTabla)
        {
            var sb = new StringBuilder();
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            Encryptador cifrador = new Encryptador();
            if (nomTabla == "Usuario")
            {
                foreach (string DVH in usuarioDAL.ObtenerListaDVH())
                {
                    sb.Append(DVH);
                }
            }
            if (nomTabla == "Beneficio")
            {
                BeneficioDAL beneficioDAL = new BeneficioDAL();
                foreach (string DVH in beneficioDAL.ObtenerListaDVH())
                {
                    sb.Append(DVH);
                }
            }

            if (nomTabla == "Boleto")
            {
                BoletoDAL boletoDAL = new BoletoDAL();
                foreach (string DVH in boletoDAL.ObtenerListaDVH())
                {
                    sb.Append(DVH);
                }
            }
            if (nomTabla == "Bitacora")
            {
                BitacoraDAL bitacoraDAL = new BitacoraDAL();
                foreach (string DVH in bitacoraDAL.ObtenerListaDVH())
                {
                    sb.Append(DVH);
                }
            }
            return cifrador.EncryptadorIrreversible(sb.ToString());
        }

        public void ActualizarDVH(Object obj, string nomTabla)
        {
            
                if (obj != null || !string.IsNullOrEmpty(nomTabla))
                {
                    string dvh = CalcularDVH(obj);
                    if (nomTabla == "Usuario" && obj is Usuario usuario)
                    {
                        UsuarioDAL usuarioDAL = new UsuarioDAL();
                        usuarioDAL.ActualizarDVH(usuario, dvh);
                        ActualizarDVV(nomTabla);
                    }
                    if (nomTabla == "Beneficio" && obj is Beneficio beneficio)
                    {
                        BeneficioDAL beneficioDAL = new BeneficioDAL();
                        beneficioDAL.ActualizarDVH(beneficio, dvh);
                        ActualizarDVV(nomTabla);
                    }

                    if (nomTabla == "Boleto" && obj is Boleto boleto)
                    {
                        BoletoDAL boletoDAL = new BoletoDAL();
                        boletoDAL.ActualizarDVH(boleto, dvh);
                        ActualizarDVV(nomTabla);
                    }
                    if (nomTabla == "Bitacora" && obj is Bitacora bitacora)
                    {
                        BitacoraDAL bitacoraDAL = new BitacoraDAL();
                        bitacoraDAL.ActualizarDVH(bitacora, dvh);
                        ActualizarDVV(nomTabla);
                    }
                }

            
        }
        public void ActulizarDHVSOLORECALCULAR(Object obj, string nomTabla)
        {
            if (obj != null || !string.IsNullOrEmpty(nomTabla))
            {
                string dvh = CalcularDVH(obj);
                if (nomTabla == "Usuario" && obj is Usuario usuario)
                {
                    UsuarioDAL usuarioDAL = new UsuarioDAL();
                    usuarioDAL.ActualizarDVH(usuario, dvh);
                    ActualizarDVV(nomTabla);
                }
                if (nomTabla == "Beneficio" && obj is Beneficio beneficio)
                {
                    BeneficioDAL beneficioDAL = new BeneficioDAL();
                    beneficioDAL.ActualizarDVH(beneficio, dvh);
                    ActualizarDVV(nomTabla);
                }

                if (nomTabla == "Boleto" && obj is Boleto boleto)
                {
                    BoletoDAL boletoDAL = new BoletoDAL();
                    boletoDAL.ActualizarDVH(boleto, dvh);
                    ActualizarDVV(nomTabla);
                }
                if (nomTabla == "Bitacora" && obj is Bitacora bitacora)
                {
                    BitacoraDAL bitacoraDAL = new BitacoraDAL();
                    bitacoraDAL.ActualizarDVH(bitacora, dvh);
                    ActualizarDVV(nomTabla);
                }
            }
        }
        public void ActualizarDVV(string nomTabla)
        {
            string dvv = CalcularDVV(nomTabla);
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();

            digitoVerificadorDAL.ActualizarDVV(nomTabla, dvv);

        }

        List<string> tablas = new List<string>()
        {
            "Usuario",
            "Beneficio",
            "Boleto",
            "Bitacora"
        };


        public bool VerificarIntegridadDVV(string nomTabla)
        {
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();
            string dvvMemoria = CalcularDVV(nomTabla);
            string dvvBD = digitoVerificadorDAL.ObtenerDVV(nomTabla);
            return dvvMemoria == dvvBD;
        }

        public bool VerificarIntegridadDVH(object obj)
        {
            if (obj is Usuario usu)
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();
                string dvhMemoria = CalcularDVH(usu);
                string dvhBD = usuarioDAL.ObtenerDVH(usu);
                return dvhMemoria == dvhBD;
            }
            if (obj is Beneficio ben)
            {
                BeneficioDAL beneficioDAL = new BeneficioDAL();
                string dvhMemoria = CalcularDVH(ben);
                string dvhBD = beneficioDAL.ObtenerDVH(ben);
                return dvhMemoria == dvhBD;
            }
            if (obj is Boleto bol)
            {
                BoletoDAL boletoDAL = new BoletoDAL();
                string dvhMemoria = CalcularDVH(bol);
                string dvhBD = boletoDAL.ObtenerDVH(bol);
                return dvhMemoria == dvhBD;
            }
            if (obj is Bitacora bit)
            {
                BitacoraDAL bitacoraDAL = new BitacoraDAL();
                string dvhMemoria = CalcularDVH(bit);
                string dvhBD = bitacoraDAL.ObtenerDVH(bit);
                return dvhMemoria == dvhBD;
            }
            return false;
        }


        public string VerificarIntegridadTodasLasTablas()
        {
            bool esValido = true;
            string mensaje = string.Empty;
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();
            foreach (var tabla in tablas)
            {
                if (tabla == "Usuario")
                {
                    UsuarioDAL usuarioDAL = new UsuarioDAL();
                    foreach (var usuario in usuarioDAL.DevolverTodosLosUsuarios())
                    {
                        if (!VerificarIntegridadDVH(usuario))
                        {
                            mensaje += $"El DVH del usuario {usuario.Username} es inconsistente.\n";
                            esValido = false;
                        }
                    }
                }
                if (tabla == "Beneficio")
                {
                    BeneficioDAL beneficioDAL = new BeneficioDAL();
                    foreach (var beneficio in beneficioDAL.ObtenerTodosLosBeneficios())
                    {
                        if (!VerificarIntegridadDVH(beneficio))
                        {
                            mensaje += $"El DVH del beneficio número {beneficio.CodigoBeneficio} es inconsistente.\n";
                            esValido = false;
                        }
                    }
                }
                if (tabla == "Boleto")
                {
                    BoletoDAL boletoDAL = new BoletoDAL();
                    foreach (var boleto in boletoDAL.ObtenerTodosLosBoletos())
                    {
                        if (!VerificarIntegridadDVH(boleto))
                        {
                            mensaje += $"El DVH del boleto número {boleto.IDBoleto} es inconsistente.\n";
                            esValido = false;
                        }
                    }
                }
                if (tabla == "Bitacora")
                {
                    BitacoraDAL bitacoraDAL = new BitacoraDAL();
                    foreach (var bitacora in bitacoraDAL.ObtenerEventosPorConsulta())
                    {
                        if (!VerificarIntegridadDVH(bitacora))
                        {
                            mensaje += $"El DVH del registro de la bitácora número {bitacora.IdBitacora} es inconsistente.\n";
                            esValido = false;
                        }
                    }
                }
                if (!VerificarIntegridadDVV(tabla))
                {
                    mensaje += $"La tabla {tabla} fue alterada.\n";
                    esValido = false;
                }
                if (digitoVerificadorDAL.CalcularCount(tabla) != digitoVerificadorDAL.ObtenerCR(tabla))
                {
                    mensaje += $"La tabla {tabla} tiene un conteo de registros inconsistente.\n";
                    esValido = false;
                }
            }
            return mensaje;
        }

        public bool VerificarIntegridadTodasLasTablasBool()
        {
            bool esValido = true;
            DigitoVerificadorDAL digitoVerificadorDAL = new DigitoVerificadorDAL();
            foreach (var tabla in tablas)
            {
                if (tabla == "Usuario")
                {
                    UsuarioDAL usuarioDAL = new UsuarioDAL();
                    foreach (var usuario in usuarioDAL.DevolverTodosLosUsuarios())
                    {
                        if (!VerificarIntegridadDVH(usuario))
                        {
                            esValido = false;
                        }
                    }
                }
                if (tabla == "Beneficio")
                {
                    BeneficioDAL beneficioDAL = new BeneficioDAL();
                    foreach (var beneficio in beneficioDAL.ObtenerTodosLosBeneficios())
                    {
                        if (!VerificarIntegridadDVH(beneficio))
                        {
                            esValido = false;
                        }
                    }
                }
                if (tabla == "Boleto")
                {
                    BoletoDAL boletoDAL = new BoletoDAL();
                    foreach (var boleto in boletoDAL.ObtenerTodosLosBoletos())
                    {
                        if (!VerificarIntegridadDVH(boleto))
                        {
                            esValido = false;
                        }
                    }
                }
                if (tabla == "Bitacora")
                {
                    BitacoraDAL bitacoraDAL = new BitacoraDAL();
                    foreach (var bitacora in bitacoraDAL.ObtenerEventosPorConsulta())
                    {
                        if (!VerificarIntegridadDVH(bitacora))
                        {
                            esValido = false;
                        }
                    }
                }
                if (!VerificarIntegridadDVV(tabla))
                {
                    esValido = false;
                }
                if (digitoVerificadorDAL.CalcularCount(tabla) != digitoVerificadorDAL.ObtenerCR(tabla))
                {
                    esValido = false;
                }
            }
            return esValido;
        }

        public void RecalcularDigitosVerificadores()
        {
            foreach (var tabla in tablas)
            {
                if (tabla == "Usuario")
                {
                    UsuarioDAL usuarioDAL = new UsuarioDAL();
                    foreach (var usuario in usuarioDAL.DevolverTodosLosUsuarios())
                    {
                        ActulizarDHVSOLORECALCULAR(usuario, tabla);
                    }
                }
                if (tabla == "Beneficio")
                {
                    BeneficioDAL beneficioDAL = new BeneficioDAL();
                    foreach (var beneficio in beneficioDAL.ObtenerTodosLosBeneficios())
                    {
                        ActulizarDHVSOLORECALCULAR(beneficio, tabla);
                    }
                }
                if (tabla == "Boleto")
                {
                    BoletoDAL boletoDAL = new BoletoDAL();
                    foreach (var boleto in boletoDAL.ObtenerTodosLosBoletos())
                    {
                        ActulizarDHVSOLORECALCULAR(boleto, tabla);
                    }
                }
                if (tabla == "Bitacora")
                {
                    BitacoraDAL bitacoraDAL = new BitacoraDAL();
                    if (bitacoraDAL.ObtenerEventosPorConsulta().Count == 0)
                    {
                        ActualizarDVV(tabla);
                    }
                    foreach (var bitacora in bitacoraDAL.ObtenerEventosPorConsulta())
                    {
                        ActulizarDHVSOLORECALCULAR(bitacora, tabla);
                    }
                }
            }
        }

    }
}
