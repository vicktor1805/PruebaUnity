using Assets.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


public class ActividadController
{
    private String XML_ACTIVIDADES = "testrotpos.xml";

    public List<ModeloPadre> ListarModelosPadre(string xmlFile)
    {
        try
            {
                XmlHelper xmlHelper = new XmlHelper();
                return xmlHelper.LoadXml<List<ModeloPadre>>(xmlFile);
            }
        catch (Exception ex)
        {
        }
        return null;

    }

    public ModeloPadre ObtenerModeloPadre(String nameActividad)
    {
        try
        {
            XmlHelper xmlHelper = new XmlHelper();
            List<ModeloPadre> ListModelosPadre = xmlHelper.LoadXml<List<ModeloPadre>>(XML_ACTIVIDADES);
            //return ListModelosPadre.Where(x => x.ListOrganos.Exists(t => t.TemaId.Equals(name))).FirstOrDefault();
            return ListModelosPadre.Where(x => x.ModeloPadreId.Equals(nameActividad)).FirstOrDefault();
        }
        catch (Exception ex)
        {
        }
        return null;
    }

    public Camara ObtenerCamara(string xmlFile)
    {
        try
        {
            XmlHelper xml = new XmlHelper();
            List<ModeloPadre> ListModelosPadre = xml.LoadXml<List<ModeloPadre>>(xmlFile);
            var padre = ListModelosPadre[0];
            return padre.Camara;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public List<ModeloOrgano> ObtenerModelosOrganos(String nameActividad, String nameTema)
    {
        try
        {
            XmlHelper xmlHelper = new XmlHelper();
            //Semana semana = ObtenerSemana(name);
            ModeloPadre tema = ObtenerModeloPadre(nameActividad);
            //Actividad actividad = ObtenerActividad(nameTema, nameActividad);
            return tema.ListOrganos;

        }
        catch (Exception ex)
        {
        }
        return null;
    }

	
}
