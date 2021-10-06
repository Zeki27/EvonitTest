using EvonitTest.Classok;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.XPath;

namespace EvonitTest
{
    class Program
    {
        public static int index = 0;
        public static XmlNodeList oList;
        public static int[,] oNM;
        public static int oCount = 0;
        public static XmlDocument doc;

        public static int examinegoal = 0;


        public static List<Objects> objList = new List<Objects>();
        public static List<Relations> relList = new List<Relations>();

        static void Main(string[] args)
        {
            ReadXML();
            Console.WriteLine("Adja meg, hogy HOVA(0-19):");
            examinegoal = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg, hogy HONNAN(0-19):");
            GetPath(int.Parse(Console.ReadLine()));
            Console.ReadKey();
        }

        public static void ReadXML()
        {
            try
            {
                string xmlpath = File.ReadAllText("test2.xml");
                doc = new XmlDocument();
                doc.LoadXml(xmlpath);

                //Fill up object lists
                XmlNodeList objectlist = doc.GetElementsByTagName("parcel");
                XmlNodeList relationList = doc.GetElementsByTagName("illeszkedik");
                for (int i = 0; i < objectlist.Count; i++)
                {
                    Objects objs = new Objects(
                        objectlist[i].ChildNodes[1].InnerText,
                        objectlist[i].ChildNodes[0].InnerText
                        );
                    objList.Add(objs);
                }

                for (int i = 0; i < relationList.Count; i++)
                {
                    Relations rels = new Relations(
                        relationList[i].ChildNodes[0].InnerText,
                        relationList[i].ChildNodes[1].InnerText,
                        relationList[i].Name
                        );
                    relList.Add(rels);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void GetPath(int a, List<int> pl = null)
        {
            List<int> plist = new List<int>();
            if (pl == null)
            {
                plist.Add(a);
            }
            else
            {
                plist = pl;
                plist.Add(a);
            }

            var childs = relList.Where(x => int.Parse(x.Honnan) == a).Select(x => x.Hova).ToList();
            foreach (var item in childs)
            {
                if (int.Parse(item) == examinegoal)
                {
                    plist.Add(int.Parse(item));
                    plist.ForEach(x => Console.WriteLine($"{++index}. lépés {x}"));
                }
                else
                {
                    GetPath(int.Parse(item), plist);
                }
            }
        }



        [Obsolete]//nem használt
        public static void CreateAdjecencyMatrix()//szomszédsági mátrix
        {
            try
            {
                //size
                oList = doc.GetElementsByTagName("név");
                oNM = new int[oList.Count, oList.Count];

                //relations
                XmlNodeList rList = doc.GetElementsByTagName("illeszkedik");
                for (int i = 0; i < rList.Count; i++)
                {
                    Console.WriteLine("honnan " + rList[i].ChildNodes.Item(0).InnerText + "   hova " + rList[i].ChildNodes.Item(1).InnerText);
                    oNM[int.Parse(rList[i].ChildNodes.Item(0).InnerText), int.Parse(rList[i].ChildNodes.Item(1).InnerText)] = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
