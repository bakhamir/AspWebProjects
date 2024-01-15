using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebCRUD.Model;

namespace WebCRUD
{
    public partial class myCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            gvCity.DataSource = getData();
            gvCity.DataBind();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            gvCity.DataSource = getData();
            gvCity.DataBind();
        }

        List<City> getData()
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
               return db.Query<City>("pCity;6", new {name = tbSearch.Text},commandType:System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        protected void btSearch_Click2(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                var result = db.ExecuteScalar<string>("pCity;3", new { name = TbName.Text }, commandType: CommandType.StoredProcedure);
                if (result == "ok")
                {
                    gvCity.DataSource = getData();
                    gvCity.DataBind();
                }
            }

        }


        protected void btSearch_ClickEd(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                var result = db.ExecuteScalar<string>("pCity;4", new { id = hfId.Value, name = TbName.Text }, commandType: CommandType.StoredProcedure);
                if (result == "ok")
                {
                    gvCity.DataSource = getData();
                    gvCity.DataBind();
                }
            }
        }

        protected void gvCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbName.Text = gvCity.DataKeys[gvCity.SelectedIndex].Values[1].ToString();
            hfId.Value = gvCity.DataKeys[gvCity.SelectedIndex].Values[0].ToString();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["db"]))
            {
                var result = db.ExecuteScalar<int>("pCity;5", new { id = hfId.Value}, commandType: CommandType.StoredProcedure);
                if (result > 0)
                {
                    gvCity.DataSource = getData();
                    gvCity.DataBind();
                }
            }
        }

        protected void TbName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Report.aspx?param1=excel");

        }
    }
}