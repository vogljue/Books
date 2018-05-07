using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using Books.Entities;

namespace Books.Utilities
{
    public class BookUtils : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose on BookUtils");
        }

        public void ReadAllBooks()
        {
            using (StreamReader reader = new StreamReader("/projects/Books/books.xml"))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                using (XmlReader xmlReader = XmlReader.Create(reader, settings))
                {
                    XmlDocument doc = new XmlDocument();
                    //doc.PreserveWhitespace = true;
                    doc.Load(xmlReader);

                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                    nsmgr.AddNamespace("bk", "http://www.contoso.com/books");

                    XmlNode root = doc.DocumentElement;
                    XmlNodeList nodeList;
                    nodeList = root.SelectNodes("//bk:books/bk:book[@genre='novel']", nsmgr);
                    foreach (XmlNode book in nodeList)
                    {
                        Console.WriteLine("ISBN = " + book.Attributes.GetNamedItem("ISBN").Value);
                        foreach (XmlNode item in book.ChildNodes)
                        {
                            Console.WriteLine($"{item.Name} = {item.InnerText}");
                        }
                    }

                }
            }
        }

        public void ReadBooksDTO()
        {
            Console.WriteLine("All Books ---");
            BookDto bookDto = new BookDto();
            DataTable table = bookDto.CreateDataTable();
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"genre={row.Field<string>(0)}, title={row.Field<string>(2)}");
            }

            Console.WriteLine("Comic Books ---");
            IEnumerable<DataRow> rows = from r in table.AsEnumerable()
                                        where r.Field<string>(0).Equals("Comic")
                                        orderby r.Field<string>(2)
                                        select r;
            foreach (DataRow row in rows)
            {
                Console.WriteLine($"genre={row.Field<string>(0)}, title={row.Field<string>(2)}");
            }

        }
    }
}
