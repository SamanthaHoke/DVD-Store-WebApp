using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HokeDVD.Admin
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Display customers 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCustomers_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            SqlCommand myCmd;
            SqlDataReader myReader;
            string myconnectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            myConnection = new SqlConnection(myconnectionString);
            myCmd = new SqlCommand("SELECT CustomerID, FirstName, LastName FROM Customers", myConnection);
            try
            {
                myConnection.Open();
                myReader = myCmd.ExecuteReader();
                DatalistCust.DataSource = myReader;
                DatalistCust.DataBind();
                myReader.Close();
            }
            finally
            {
                myConnection.Close();
            }
            DatalistCust.Visible = true;
        }

        /// <summary>
        /// Display orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OrdersButton_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            SqlCommand myCmd;
            SqlDataReader myReader;
            string myconnectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            myConnection = new SqlConnection(myconnectionString);
            myCmd = new SqlCommand("SELECT Orders.OrderID, Orders.CustomerID,  DVDsOrdered.DVDID, DVDtable.DVDtitle FROM Orders  " +
                " INNER JOIN DVDsOrdered ON DVDsOrdered.OrderID = Orders.OrderID " +
                " INNER JOIN DVDtable ON DVDsOrdered.DVDID = DVDtable.DVDID " +
                 " WHERE CustomerID = @CustomerID", myConnection);

            myCmd.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int);
            myCmd.Parameters["@CustomerID"].Value = CustNumTextBox.Text;

            try
            {
                myConnection.Open();
                myReader = myCmd.ExecuteReader();
                DatalistOrders.DataSource = myReader;
                DatalistOrders.DataBind();
                myReader.Close();
            }
            finally
            {
                myConnection.Close();
            }
            DatalistOrders.Visible = true;
        }
        /// <summary>
        /// Log out user and redirect to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/home.aspx");
        }
    }
}