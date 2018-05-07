using System.Data;

namespace Books.Entities
{
    public class BookDto
    {
        public DataTable CreateDataTable()
        {
            DataTable table = new DataTable("Books");
            table.Columns.Add("genre", typeof(string));
            table.Columns.Add("isbn", typeof(string));
            table.Columns.Add("title", typeof(string));

            DataRow row1 = table.NewRow();
            row1.SetField<string>(0, "Novel");
            row1.SetField<string>(1, "1-123-456-78");
            row1.SetField<string>(2, "Time Machine");
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2.SetField<string>(0, "Comic");
            row2.SetField<string>(1, "1-444-456-78");
            row2.SetField<string>(2, "Marvels Avenger");
            table.Rows.Add(row2);

            DataRow row3 = table.NewRow();
            row3.SetField<string>(0, "Comic");
            row3.SetField<string>(1, "1-777-456-78");
            row3.SetField<string>(2, "DC Superman");
            table.Rows.Add(row3);

            DataRow row4 = table.NewRow();
            row4.SetField<string>(0, "Comic");
            row4.SetField<string>(1, "1-999-456-78");
            row4.SetField<string>(2, "Marvels Batman");
            table.Rows.Add(row4);


            //table.WriteXml("C:/Users/voglj/Projekte/booksdto.xml");

            return table;
        }
    }
}
