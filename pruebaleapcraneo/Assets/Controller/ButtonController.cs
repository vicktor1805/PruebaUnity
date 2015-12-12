using Assets.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//using UnityEngine;


namespace Assets.Controller
{
    public class ButtonController
    {

        private String XML_ESQUEMA = "Resources/Esquema.xml";
        private String XML_LAMINAS = "Recursos//Laminas.xml";

        public List<Semana> ListarSemanas()
        {
            try
            {
                XmlHelper xmlHelper = new XmlHelper();
                return xmlHelper.LoadXml<List<Semana>>(XML_ESQUEMA);
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        public Semana ObtenerSemana(String name)
        {
            try
            {
                XmlHelper xmlHelper = new XmlHelper();
                List<Semana> ListSemanas = xmlHelper.LoadXml<List<Semana>>(XML_ESQUEMA);
                return ListSemanas.Where(x => x.ListTemas.Exists(t => t.TemaId.Equals(name))).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public Tema ObtenerTema(String name)
        {
            try
            {
                XmlHelper xmlHelper = new XmlHelper();
                List<Semana> ListSemanas = xmlHelper.LoadXml<List<Semana>>(XML_ESQUEMA);
                Semana semana = ListSemanas.Where(x => x.ListTemas.Exists(t => t.TemaId.Equals(name))).FirstOrDefault();
                return semana.ListTemas.Where(x => x.TemaId.Equals(name)).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return null;
        }


        public List<Actividad> listaordenada(List<Actividad> lista)
        {
            return lista.OrderBy(x => x.orden).ToList();
        }


        public Actividad ObtenerActividad(String nameTema, String nameActividad)
        {
            try
            {
                //Semana semana = ObtenerSemana(name);
                //Tema tema = semana.ListTemas.Where(x => x.TemaId.Equals(name)).FirstOrDefault();
                Tema tema = ObtenerTema(nameTema);
                return tema.ListActividad.Where(a => a.ActividadId.Equals(nameActividad)).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public List<Lamina> ObtenerLaminas(String nameTema, String nameActividad)
        {
            try
            {
                Actividad actividad = ObtenerActividad(nameTema, nameActividad);
                return actividad.ListLaminas;

            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public List<LaminaTexto> ObtenerLaminasTexto(String nameTema, String nameActividad)
        {
            try
            {
                XmlHelper xmlHelper = new XmlHelper();
                //Semana semana = ObtenerSemana(name);
                Tema tema = ObtenerTema(nameTema);
                Actividad actividad = ObtenerActividad(nameTema, nameActividad);
                return actividad.ListLaminasTexto;

            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public Lamina ObtenerLamina(String nameTema, String nameActividad, String nameLamina)
        {
            //
            try
            {
                XmlHelper xmlHelper = new XmlHelper();
                //Semana semana = ObtenerSemana(name);
                Tema tema = ObtenerTema(nameTema);
                Actividad actividad = ObtenerActividad(nameTema, nameActividad);
                return actividad.ListLaminas.Where(l => l.LaminaId.Equals(nameLamina)).FirstOrDefault();

            }
            catch (Exception ex)
            {
            }
            return null;
        }

    }
}
