using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChuDe3
{
    public partial class frmJSon : Form
    {
        public frmJSon()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void WriteReadText(string filename, string[] text)
        {
            File.WriteAllLines(filename, text);
            foreach (string s in File.ReadAllLines(filename))
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }

        private void btnReadJSON_Click(object sender, EventArgs e)
        {
            string Str = "";
            string path = "../../students.json";
            List<StudentInfo> list = LoadJSON(path);
            for (int i = 0; i < list.Count; i++)
            {
                StudentInfo info = list[i];
                Str += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2}," + " điểm TB: {3}\r\n", (i + 1), info.MSSV, info.HoTen, info.Diem);
            }
            MessageBox.Show(Str);
        }
        private List<StudentInfo> LoadJSON(string path)
        {
            List<StudentInfo> List = new List<StudentInfo>();
            StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();
            var array = (JObject)JsonConvert.DeserializeObject(json);
            var students = array["sinhvien"].Children();
            foreach (var item in students)
            {
                string mssv = item["MSSV"].Value<string>();
                string hoTen = item["hoten"].Value<string>();
                int tuoi = item["tuoi"].Value<int>();
                double diem = item["diem"].Value<double>();
                bool tonGiao = item["tongiao"].Value<bool>();

                StudentInfo info =new StudentInfo(mssv, hoTen, tuoi, diem, tonGiao);
                List.Add(info);
            }
            return List;
        }
        //public static void Main(string[] args)
        //{
        //    var xmlDoc = new XmlDocument();
        //    xmlDoc.Load("..\\..\\books.xml");
        //    var nodeList = xmlDoc.DocumentElement.SelectNodes("\catalog\book");
        //    foreach(XmlNode node in nodeList)
        //    {
        //        var isbn = node.Attributes["ISBN"].Value;
        //        var title = node.SelectSingleNode("title").InnerText;
        //        var price = node.SelectSingleNode("price").InnerText;

        //        var firstName = node.SelectSingleNode("author/first-name").InnerText;
        //        var lastName = node.SelectSingleNode("author/last-name").InnerText;
        //        Console.WriteLine("{0,-15},{1,-50},{2,-15},{3,-15},{4,6}",isbn,title,firstName,lastName,price);
        //    }
        //}

        //public static void Main(string[] args)
        //{
        //    using (XmlWriter writer = XmlWriter.Create("books.xml"))
        //    {
        //        // Write processing Instruction
        //        string pi = "type=\"text/xsl\"href="\book.xsl\"";
        //        writer.WriteProcessingInstruction("xml-stylesheet", pi);
        //        // Write document type
        //        writer.WriteDocType("catalog", null, null, "<!entity h \"hardcover\">");
        //        // Write a comment
        //        writer.WriteComment("This is a book sample XML");
        //        //Root element - start tag
        //        writer.WriteStartElement("book");
        //        // Write isbn attribute
        //        writer.WriteAttributeString("ISBN", "9831123212");
        //        // Write year attribute
        //        writer.WriteAttributeString("yearpublished", "2002");
        //        // Write author
        //        writer.WriteElementString("author", "Mahesh Chand");
        //        // Write title
        //        writer.WriteElementString("title", "Visual C# Programming");
        //        // Write price
        //        writer.WriteElementString("price", "44.95");
        //        // Root element - end tag
        //        writer.WriteEndElement();
        //        // Write document
        //        writer.WriteEndDocument();
        //        //Flush it
        //        writer.Flush();
        //    }
        //}
    }
}
