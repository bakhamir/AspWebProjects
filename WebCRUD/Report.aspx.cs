using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCRUD
{
    public partial class Report : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["param1"] == "excel")
            {
                Response.Write(Request.QueryString["param1"].ToString());
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", "report.xlsx"));

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.AddWorksheet(getData(), "report");
                    //ws.Cell(1, 1).Value = "Id";
                    //ws.Cell(1, 2).Value = "Name";
                    using (MemoryStream ms = new MemoryStream())
                    {
                        wb.SaveAs(ms);
                        //ms.CopyTo(Response.OutputStream);
                        Response.OutputStream.Write(ms.ToArray(), 0, (int)ms.Length);
                        Response.End();
                    }
                }
            }
            if (Request.QueryString["param1"] == "csv")
            {
                Response.Write(Request.QueryString["param1"].ToString());
                Response.Clear();
                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", "report.csv"));

                using (var writer = new StreamWriter(Response.OutputStream, Encoding.UTF8))
                {
                    var dataTable = getData();

                    foreach (DataColumn column in dataTable.Columns)
                    {
                        writer.Write($"{column.ColumnName},");
                    }
                    writer.WriteLine(); 

                    foreach (DataRow row in dataTable.Rows)
                    {
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            writer.Write($"{row[i]},");
                        }
                        writer.WriteLine(); 
                    }

                    Response.End();
                }
            }

        }

        protected DataTable getData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("select * from city", db))
                {
                    dt.Load(cmd.ExecuteReader());
                }
                db.Close();

            }
            return dt;
        }
    }
}