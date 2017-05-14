using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 风动测试
{
    class XML
    {
        //判断根目录下是否有对应的MyXml.xml，没有则建立
        #region
        public void Create_Xml()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "MyXml.xml";//根目录下的xml文件

            if (!File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();

                //创建头文件声明
                XmlDeclaration xmldecl;
                xmldecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);

                //Add the new node to the document.
                doc.InsertBefore(xmldecl, doc.DocumentElement);

                XmlElement Node = doc.CreateElement("configuration");//创建一个节点          
                doc.AppendChild(Node);

                XmlElement[] setting = new XmlElement[50];      //setting
                XmlElement[] value = new XmlElement[50];    //值 
                for (int j = 0; j < 1; j++)
                {
                    setting[j] = doc.CreateElement("setting" + j.ToString());
                    Node.AppendChild(setting[j]);
                    for (int i = 0; i < 32; i++)
                    {

                        //setting[i].SetAttribute("name", "Para" + j.ToString() + "_" + i.ToString());   //设置该节点属性
                        //setting[i].SetAttribute("serializeAs", "String");                              //设置该节点属性
                        value[i] = doc.CreateElement("value" + i.ToString());
                        value[i].InnerText = "0000";
                        setting[j].AppendChild(value[i]);
                    }
                }

                doc.Save(path);
            }
        }
        #endregion

        //设置xml值并保持
        #region
        public void Set_Xml()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "MyXml.xml";//根目录下的xml文件
            int i = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("configuration").ChildNodes;//获取bookstore节点的所有子节点          

            foreach (XmlNode xn in nodeList)//遍历所有子节点
            {
                XmlElement xe = (XmlElement)xn;       //转换类型
                if (xe.Name == "setting0")
                {                    
                    i = 0;
                    foreach (XmlNode xn1 in xe.ChildNodes)
                    {
                        xn1.InnerText = Form1.set_value[0, i];
                        i++;
                    }
                }
                else if (xn.Name == "setting1")
                {
                    i = 0;
                    foreach (XmlNode xn1 in xn.ChildNodes)
                    {
                        xn1.InnerText = Form1.set_value[1, i];
                        i++;
                    }
                }
            }//foreach遍历完成
            xmlDoc.Save(path);
        }
        #endregion

        //读取xml参数文件
        #region
        public void Read_Xml()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "MyXml.xml";//根目录下的xml文件
            int i = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("configuration").ChildNodes;//获取bookstore节点的所有子节点          

            foreach (XmlNode xn in nodeList)//遍历所有子节点
            {
                if (xn.Name == "setting0")
                {
                    i = 0;
                    foreach (XmlNode xn1 in xn.ChildNodes)
                    {
                        Form1.set_value[0, i] = xn1.InnerText;
                        i++;
                    }
                }
                else if (xn.Name == "setting1")
                {
                    i = 0;
                    foreach (XmlNode xn1 in xn.ChildNodes)
                    {
                        Form1.set_value[1, i] = xn1.InnerText;
                        i++;
                    }
                }               
            }//foreach遍历完成
        }
        #endregion
    }
}
