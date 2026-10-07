using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DocVaGhiXML
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Ghi XML bang XmlWriter ---");
            WriteXmlWithWriter();

            Console.WriteLine("\n--- Ghi XML bang XmlSerializer ---");
            List<Book> books = new List<Book>
            {
                new Book { ISBN = "9831123212", Title = "A Programmer's Guide to ADO .Net", Author = "Mahesh Chand", Price = 44.99m, YearPublished = 2002 },
                new Book { ISBN = "9781484234", Title = "Pro Entity Framework Core 2", Author = "Adam Freeman", Price = 45.09m, YearPublished = 2019 }
            };

            SaveToXmlFile(books);

            Console.WriteLine("Da luu danh sach sach vao file books.xml thanh cong!");
            Console.ReadKey();
        }

        private static void WriteXmlWithWriter()
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true 
            };

            using (XmlWriter writer = XmlWriter.Create("books_writer.xml", settings))
            {
                string pi = "type=\"text/xsl\" href=\"books.xml\"";
                writer.WriteProcessingInstruction("xml-stylesheet", pi);
                writer.WriteDocType("catalog", null, null, "");
                writer.WriteComment("This is a book sample XML");

                writer.WriteStartElement("book");
                writer.WriteAttributeString("ISBN", "9831123212");
                writer.WriteAttributeString("yearpublished", "2002");
                writer.WriteElementString("author", "Mahesh Chand");
                writer.WriteElementString("title", "Visual C# Programming");
                writer.WriteElementString("price", "44.95");
                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
            }
        }

        private static void SaveToXmlFile(List<Book> books)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter writer = new StreamWriter("books.xml"))
            {
                serializer.Serialize(writer, books);
            }
        }
    }
}