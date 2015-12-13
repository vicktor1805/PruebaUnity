using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Classes
{
    public class PersistenceHelper
    {

        private string NombreSistema;
        private string NombreComplemento1;

        private GameObject[] ArregloSistemasSnapshot;
        private GameObject[] ArregloObjetosSnapshot;

        public void CrearUnidadesPruebaXML()
        {
            NombreSistema = "CirculatorioFemenino";
            csVariablesGlobales.NombreUltimoPrefabSeleccionado = "PrefabSistema" + NombreSistema;

            var unidadAprendizajeA = new UnidadAprendizaje()
            {
                Nombre = "Unidad 1: Corazón y Arterias",
                Codigo = "SistemaMarco",
                ModoVista = ModoVista.PantallaCompleta,
                LstVistaSistema = {
                    new VistaSistema(){ Sistema = NombreSistema, ElementosEliminados = { "Female_Blood_Vessels_grp/Female_Circulatory_Veins_Geo", "Female_Blood_Vessels_grp/Female_Circulatory_Arteries_Geo"} }, 
                },
                VistaCamara = new VistaCamara { Posicion = new Vector3(0.01682995f, 9.241152f, -9.4f), MirandoHacia = new Vector3(0.01682995f, 9.241152f, -10.4f), Size = 2.603965f }
            };

            var lstUnidadesAprendizaje = new List<UnidadAprendizaje>();
            lstUnidadesAprendizaje.Add(unidadAprendizajeA);

            var xmlHelper = new XmlHelper();
            xmlHelper.CreateXml<List<UnidadAprendizaje>>(lstUnidadesAprendizaje, "Unidades.xml");
        }

        public void CrearUnidadesPruebaXML1()
        {

            NombreComplemento1 = "PrefabComplementoEquipoQuirurgico";

            var unidadAprendizajeA = new UnidadAprendizaje()
            {
                Nombre = "Unidad 1: Etc y etc",
                Codigo = "SistemaPancho",
                ModoVista = ModoVista.PantallaCompleta,
                LstVistaSistema = {
                    
                    new VistaSistema(){ Sistema = NombreComplemento1, ElementosEliminados = {} },
                },
                VistaCamara = new VistaCamara { Posicion = new Vector3(0.01682995f, 9.241152f, -9.4f), MirandoHacia = new Vector3(0.01682995f, 9.241152f, -10.4f), Size = 2.603965f }
            };

            var lstUnidadesAprendizaje = new List<UnidadAprendizaje>();
            lstUnidadesAprendizaje.Add(unidadAprendizajeA);

            var xmlHelper = new XmlHelper();
            xmlHelper.CreateXml<List<UnidadAprendizaje>>(lstUnidadesAprendizaje, "Unidades.xml");
        }

        public void CrearUnidadesPruebaXML2()
        {
            NombreSistema = "IntegumentarioFemenino";
            csVariablesGlobales.NombreUltimoPrefabSeleccionado = "PrefabSistema" + NombreSistema;
            NombreComplemento1 = "PrefabComplementoPlanosAnatomicos";

            var unidadAprendizajeA = new UnidadAprendizaje()
            {
                Nombre = "Unidad 1: Etc y etc",
                Codigo = "SistemaPancho",
                ModoVista = ModoVista.PantallaCompleta,
                LstVistaSistema = {
                    new VistaSistema(){ Sistema = NombreSistema, ElementosEliminados = {} },
                    new VistaSistema(){ Sistema = NombreComplemento1, ElementosEliminados = {} },
                },
                VistaCamara = new VistaCamara { Posicion = new Vector3(0.01682995f, 9.241152f, -9.4f), MirandoHacia = new Vector3(0.01682995f, 9.241152f, -10.4f), Size = 2.603965f }
            };

            var lstUnidadesAprendizaje = new List<UnidadAprendizaje>();
            lstUnidadesAprendizaje.Add(unidadAprendizajeA);

            var xmlHelper = new XmlHelper();
            xmlHelper.CreateXml<List<UnidadAprendizaje>>(lstUnidadesAprendizaje, "Unidades.xml");
        }

        public void CrearUnidadesPruebaXML3()
        {
            NombreSistema = "IntegumentarioFemenino";
            csVariablesGlobales.NombreUltimoPrefabSeleccionado = "PrefabSistema" + NombreSistema;
            NombreComplemento1 = "PrefabComplementoVertebraToracica09";

            var unidadAprendizajeA = new UnidadAprendizaje()
            {
                Nombre = "Unidad 1: Etc y etc",
                Codigo = "SistemaPancho",
                ModoVista = ModoVista.PantallaCompleta,
                LstVistaSistema = {
                    //new VistaSistema(){ Sistema = NombreSistema, ElementosEliminados = {} },
                    new VistaSistema(){ Sistema = NombreComplemento1, ElementosEliminados = {} },
                },
                VistaCamara = new VistaCamara { Posicion = new Vector3(0.01682995f, 9.241152f, -9.4f), MirandoHacia = new Vector3(0.01682995f, 9.241152f, -10.4f), Size = 2.603965f }
            };

            var lstUnidadesAprendizaje = new List<UnidadAprendizaje>();
            lstUnidadesAprendizaje.Add(unidadAprendizajeA);

            var xmlHelper = new XmlHelper();
            xmlHelper.CreateXml<List<UnidadAprendizaje>>(lstUnidadesAprendizaje, "Unidades.xml");
        }

        public void CrearUnidadesPruebaXML4()
        {
            NombreSistema = "MuscularFemenino";
            string NombreSistema2 = "OseoFemenino";
            string NombreSistema3 = "NerviosoFemenino";
            csVariablesGlobales.NombreUltimoPrefabSeleccionado = "PrefabSistema" + NombreSistema;
            NombreComplemento1 = "PrefabComplementoVertebraToracica09";

            var unidadAprendizajeA = new UnidadAprendizaje()
            {
                Nombre = "Unidad 1: Etc y etc",
                Codigo = "SistemaPancho",
                ModoVista = ModoVista.PantallaCompleta,
                LstVistaSistema = {
                    new VistaSistema(){ Sistema = NombreSistema, ElementosEliminados = {} },
                    new VistaSistema(){ Sistema = NombreSistema2, ElementosEliminados = {} },
                    new VistaSistema(){ Sistema = NombreSistema3, ElementosEliminados = {} },
                },
                VistaCamara = new VistaCamara { Posicion = new Vector3(0.01682995f, 9.241152f, -9.4f), MirandoHacia = new Vector3(0.01682995f, 9.241152f, -10.4f), Size = 2.603965f }
            };

            var lstUnidadesAprendizaje = new List<UnidadAprendizaje>();
            lstUnidadesAprendizaje.Add(unidadAprendizajeA);

            var xmlHelper = new XmlHelper();
            xmlHelper.CreateXml<List<UnidadAprendizaje>>(lstUnidadesAprendizaje, "Unidades.xml");
        }

        public void SnapshotXML()
        {
            ArregloSistemasSnapshot = GameObject.FindGameObjectsWithTag("Sistema");

            ArregloObjetosSnapshot = GameObject.FindGameObjectsWithTag("Untagged");

            //NombreSistema = "MuscularFemenino";
            //string NombreSistema2 = "OseoFemenino";
            //string NombreSistema3 = "NerviosoFemenino";


            csVariablesGlobales.NombreUltimoPrefabSeleccionado = "PrefabSistema" + NombreSistema;
            NombreComplemento1 = "PrefabComplementoVertebraToracica09";

            var unidadAprendizajeA = new UnidadAprendizaje()
            {
                Nombre = "Unidad 1: Etc y etc",
                Codigo = "SistemaPancho",
                ModoVista = ModoVista.PantallaCompleta,
                //VistaCamara = new VistaCamara { Posicion = new Vector3(0.01682995f, 9.241152f, -9.4f), MirandoHacia = new Vector3(0.01682995f, 9.241152f, -10.4f), Size = 2.603965f }
            };

            foreach (GameObject obj in ArregloSistemasSnapshot)
            {

                unidadAprendizajeA.LstVistaSistema.Add(new VistaSistema() { Sistema = obj.name, ElementosEliminados = { } });
            }

            var lstUnidadesAprendizaje = new List<UnidadAprendizaje>();
            lstUnidadesAprendizaje.Add(unidadAprendizajeA);

            var xmlHelper = new XmlHelper();
            xmlHelper.CreateXml<List<UnidadAprendizaje>>(lstUnidadesAprendizaje, "Nigga.xml");

        }

        public void GuardarNivelXML(string nameXML)
        {

            GameObject modeloPadre = GameObject.Find("Humano");

            var allChildrens = modeloPadre.GetComponentsInChildren(typeof(Transform), false);

            List<ModeloOrgano> aux2 = new List<ModeloOrgano>();

            foreach (Component comp in allChildrens)
            {
                //aux.Add(comp.name);
                var Modelo = new ModeloOrgano()
                {
                    ModeloOrganoId = comp.name,
                    pos = comp.transform.position,
                    rot = comp.transform.rotation,
                };
                aux2.Add(Modelo);
            }

            var ModeloPadre = new ModeloPadre()
            {
                ModeloPadreId = modeloPadre.name,

                //ListNombresOrganos = aux,
                ListOrganos = aux2,
                Camara = new Camara()
                {
                    CamaraId = "0",
                    ZoomCamara = Camera.main.orthographicSize,
                    pos = Camera.main.transform.position,
                    rot = Camera.main.transform.rotation,
                },

                pos = modeloPadre.transform.position,
                rot = modeloPadre.transform.rotation.eulerAngles,

            };

            var lstModelosPadre = new List<ModeloPadre>();
            lstModelosPadre.Add(ModeloPadre);


            var xmlHelper = new XmlHelper();
            xmlHelper.CreateXml<List<ModeloPadre>>(lstModelosPadre, nameXML + ".xml");
        }

        public List<ModeloOrgano> CargarNivelXML(string xmlFile)
        {
            //List<String> listaActivos = new List<String>();

            List<ModeloOrgano> listaActivos2 = new List<ModeloOrgano>();

            ActividadController controller = new ActividadController();

            foreach (ModeloPadre padre in controller.ListarModelosPadre(xmlFile))
            {
                foreach (ModeloOrgano organo in padre.ListOrganos)
                {
                    listaActivos2.Add(organo);
                }
            }
            //UnidadSession.UnidadActual = lstUnidadAprendizaje.FirstOrDefault(x => x.Codigo == "SistemaPancho");

            return listaActivos2;
        }

        public Camara getCamaraScene(string xmlFile)
        {
            ActividadController controller = new ActividadController();

            var camera = controller.ObtenerCamara(xmlFile);

            return camera;
        }

        public List<ModeloDescripcion> CargarDescripciones()
        {
            List<ModeloDescripcion> data = new List<ModeloDescripcion>();

            //TODO crear el xml;
            XmlHelper xmlHelper = new XmlHelper();
            data = xmlHelper.LoadXml<List<ModeloDescripcion>>("Descripciones.xml");

            return data;
        }
    }
    public enum ModoVista
    {
        PantallaCompleta,
        DosPantallasHorizontales,
        DosPantallasVerticales,
        Etc
    }

    public class Semana
    {
        public String SemanaId { get; set; }
        public String Descripcion { get; set; }
        public List<Tema> ListTemas { get; set; }

    }

    public class Lamina
    {
        public String LaminaId { get; set; }
        public String orden { get; set; }
    }

    public class LaminaTexto
    {
        public String LaminaTextoId { get; set; }
        public String orden { get; set; }
    }

    public class Tema
    {
        public String TemaId { get; set; }
        public String Descripcion { get; set; }
        public List<Actividad> ListActividad { get; set; }
    }

    public class Actividad
    {
        public String ActividadId { get; set; }
        public String orden { get; set; }
        public List<Lamina> ListLaminas { get; set; }
        public List<LaminaTexto> ListLaminasTexto { get; set; }
    }

    public class ModeloOrgano
    {
        public String ModeloOrganoId { get; set; }

        public Vector3 pos { get; set; }
        public Quaternion rot { get; set; }
        public List<ModeloOrgano> ListaHijos { get; set; }
    }

    public class ModeloSistema
    {
        public List<ModeloOrgano> ListOrganos { get; set; }

        public String ModeloSistemaId { get; set; }

        public Vector3 pos { get; set; }
        public Vector3 rot { get; set; }
    }

    public class Camara
    {
        public String CamaraId { get; set; }

        public float ZoomCamara { get; set; }

        public Vector3 pos { get; set; }
        public Quaternion rot { get; set; }
    }

    public class ModeloPadre
    {
        //public List<ModeloSistema> ListModeloSistema { get; set; }
        //public List<String> ListNombresSistema { get; set; }
        public List<ModeloOrgano> ListOrganos { get; set; }

        public List<String> ListNombresOrganos { get; set; }

        public String ModeloPadreId { get; set; }

        public Vector3 pos { get; set; }
        public Vector3 rot { get; set; }

        public Camara Camara { get; set; }
    }

    public class UnidadAprendizaje
    {
        public String Nombre { get; set; }
        public String Codigo { get; set; }
        public ModoVista ModoVista { get; set; }
        public List<VistaSistema> LstVistaSistema { get; set; }
        //public Collider CampoVision { get; set; }
        public VistaCamara VistaCamara { get; set; }

        public UnidadAprendizaje()
        {
            LstVistaSistema = new List<VistaSistema>();
        }
    }

    public class VistaSistema
    {
        public String Sistema { get; set; }
        public List<String> ElementosEliminados { get; set; }

        public VistaSistema()
        {
            ElementosEliminados = new List<String>();
        }
    }

    public class VistaCamara
    {
        public Vector3 Posicion { get; set; }
        public Vector3 MirandoHacia { get; set; }
        public float Size { get; set; }
    }

    public static class UnidadSession
    {
        public static UnidadAprendizaje UnidadActual;
        public static Camera CamaraActual;
    }

    public class ModeloDescripcion
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

}

