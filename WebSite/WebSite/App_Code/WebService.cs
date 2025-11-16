using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void Serializar(string ruta, List<Beneficio> beneficios)
    {
        using(FileStream fs = new FileStream(ruta, FileMode.Create))
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Beneficio>));
            serializador.Serialize(fs, beneficios);
        }
    }

    [WebMethod]
    public List<Beneficio> Deserializar(string ruta)
    {
        using (FileStream fs = new FileStream(ruta, FileMode.Create))
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Beneficio>));
            return (List<Beneficio>)serializador.Deserialize(fs);
        }
    }

}
