using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace HokeDVD
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //set up connection and display DVDs on every page load
                SqlConnection myConnection;
                SqlCommand myCmd;
                SqlDataReader myReader;
                string myconnectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
                myConnection= new SqlConnection(myconnectionString);
                myCmd = new SqlCommand("SELECT DVDID, DVDtitle, DVDrating, DVDartist, DVDprice FROM DVDtable", myConnection);
                   try
                   {
                      myConnection.Open();
                      myReader = myCmd.ExecuteReader();
                      DVDDatalist.DataSource = myReader;
                      DVDDatalist.DataBind();
                      myReader.Close();
                   }
                   finally
                   {
                      myConnection.Close();
                   }

        }

        /// <summary>
        /// Handles all item commands for DVD datalist
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void DVDDatalist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "details")
            {
                //redirect to details page
                Response.Redirect("details.aspx?id=" + e.CommandArgument);
            }
            else if (e.CommandName == "buyDVD")
            {
                //redirect to buy DVD page
                Response.Redirect("BuyDVD.aspx?id=" + e.CommandArgument);
            }
        }
    }
}