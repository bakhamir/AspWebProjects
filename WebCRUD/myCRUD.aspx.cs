using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebCRUD.Model;

namespace WebCRUD
{
    public partial class myCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Заполнение HtmlTable данными
            FillTable();
        }

        private void FillTable()
        {
            for (int i = 1; i <= 31; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell1 = new HtmlTableCell();
                HtmlTableCell cell2 = new HtmlTableCell();
                HtmlTableCell cell3 = new HtmlTableCell();

                cell1.InnerText = i.ToString();
                cell2.InnerText = "январь";
                cell3.InnerText = "2023";

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);

                htmlTable.Rows.Add(row);
            }
        }
    }
}