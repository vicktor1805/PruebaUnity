using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Classes
{
    public class XmlHelper
    {
        public T LoadXml<T>(String fileName)
        {
            using (var streamReader = new StreamReader(Application.dataPath + "/" + fileName))
            {
                Debug.Log(Application.persistentDataPath + "/" + fileName);
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(streamReader);
            }

        }

        public void CreateXml<T>(T content, String fileName)
        {
            using (var streamWriter = new StreamWriter(Application.dataPath + "/" + fileName))
            {
                
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, content);
            }
        }
    }
}
