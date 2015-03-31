using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace serializer
{
   // [Serializable]
   // [DataContract]
   // public class Work1
   // {
   //     [DataMember]
   //     public string position { get; set; }
   //     [DataMember]
   //     public string addres { get; set; }
   // }
    //[Serializable]
    //[DataContract]
    //public class Person
    //{
    //    [DataMember]
    //    public string Fname { get; set; }
    //     [DataMember]
    //    public string Lname { get; set; }
    //     [DataMember]
    //    public int age { get; set; }
    //     [DataMember]
    //    public Work work { get; set; }
    //
    //    
    //}

    [Serializable]
    [XmlInclude(typeof(Person))]
    public class Human
    {
        [DataMember]
        public int weight { get; set; }
        [DataMember]
        public int height { get; set; }
    }
    [Serializable]
    [DataContract]
    public class Person : Human
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int age { get; set; }
    }
    [Serializable]
    [DataContract]
    public class Work
    {
        [DataMember]
        public Human p;
    }
    interface ISerialization<T>
    {
        string Serializer(T obj);
    }
    class XmlSerialization<T> : ISerialization<T>
    {
        public string Serializer(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringWriter sw = new StringWriter();

            serializer.Serialize(sw, obj);
            return sw.ToString();
        }
    }
    class JsonSerialization<T> : ISerialization<T>
    {
        public string Serializer(T obj)
        {

            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            //MemoryStream ms = new MemoryStream();
            //serializer.WriteObject(ms, obj);
            //StreamWriter sw = new StreamWriter(ms);
            //sw.Flush();
            //ms.Position = 0;
            //StreamReader sr = new StreamReader(ms);
            //string str = sr.ReadToEnd();
            //
            //return str;
            return JsonConvert.SerializeObject(obj);
        }
    }
    public enum serialization { Json, Xml };
    class SerializationFactory<T>
    {
        public static ISerialization<T> GetSerialization(serialization s)
        {
            switch (s)
            {
                case serialization.Json:
                    return new JsonSerialization<T>();
                case serialization.Xml:
                    return new XmlSerialization<T>();
                default:
                    return new XmlSerialization<T>();
            }
        }
    }
    class Program
    {
        public static void Run()
        {
            // Person p = new Person();
            //p.Fname = "Vasya";
            //p.Lname = "Kozlov";
            //p.age = 50;
            //p.work = new Work();
            //p.work.addres = "a";
            //p.work.position = "b";
            // p.Fname = "AAAAAA";
            // p.Lname = "BBBBBB";
            // p.age = 1;
            // w.p.age = 10;
            // w.p.name = "Ivan";
            // w.p.height = 170;
            // w.p.weight = 80;
            Work w = new Work();
            w.p = new Person() { age = 18, height = 170, name = "Vasya", weight = 80 };
            ISerialization<Work> s = SerializationFactory<Work>.GetSerialization(serialization.Json);
            string str = s.Serializer(w);
            Console.WriteLine(str);

        }
        static void Main(string[] args)
        {
            Run();
        }
    }
}
