using EvonitTest.Classok;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace EvonitTest
{
    class Program
    {
        public static XmlNodeList oList;
        public static int[,] oNM;
        public static int oCount = 0;
        public static XmlDocument doc;

        static void Main(string[] args)
        {
            ReadXML();
            CreateAdjecencyMatrix();
            GetPath();
            Console.ReadKey();
        }

        public static void ReadXML()
        {
            try
            {
                string xmlpath = File.ReadAllText("test2.xml");
                doc = new XmlDocument();
                doc.LoadXml(xmlpath);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void CreateAdjecencyMatrix()
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

        public static void GetPath(int x = 0, int y = 6)// fix numbers for test
        {
            //path finding algorithm
            for (int i = 0; i < oList.Count; i++)
            {
                for (int j = 0; j < oList.Count; j++)
                {

                }
            }
        }
    }
}

//   0 1 2 3 4 5 6 7 8 9
//
//0  0 0 0 0 0 0 0 0 0 0
//1  1 0 0 0 0 0 0 0 0 0
//2  0 1 0 0 0 0 0 0 0 0
//3  0 1 0 0 0 0 0 0 0 0 
//4  0 0 0 0 0 0 1 0 0 0
//5  0 0 0 0 1 0 0 0 0 0
//6  0 0 0 1 0 0 0 0 0 0
//7  0 0 0 0 0 0 0 0 0 1
//8  0 0 0 0 0 1 0 0 0 0
//9  0 0 0 0 1 0 0 0 0 0
