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
    public partial class EditDVD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear error messages
            dbErrorLabel.Text = "";
            if (!IsPostBack)
            {
                LoadDVDList();
            }
        }
        /// <summary>
        /// Establishs a connection to the database and loads DVDList
        /// </summary>
        private void LoadDVDList()
        {
            //set up connection and query database
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDID, DVDtitle FROM DVDtable", conn);
            try
            {
                conn.Open();
                //bind data to DVD dropdown list
                reader = comm.ExecuteReader();
                dvdList.DataSource = reader;
                dvdList.DataValueField = "DVDID"; 
                dvdList.DataTextField = "DVDtitle"; 
                dvdList.DataBind();

                reader.Close();
            }
            catch
            {
                //display error message 
                dbErrorLabel.Text = "Error loading the list of DVDs! <br />";
            }
            finally
            {
                conn.Close();
            }
            //clear textboxes and disable buttons
            ButtonUpdate.Enabled = false;
            ButtonDelete.Enabled = false;
            TextBoxTitle.Text = "";
            TextBoxArtist.Text = "";
            TextBoxRating.Text = "";
            TextBoxPrice.Text = "";
            TextBoxImgURL.Text = "";
            TextBoxDescription.Text = "";
            

        }
        /// <summary>
        /// Handles select button click by connecting to the database, selecting DVD attribute values,
        /// and filling textboxes with these values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void selectButton_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDtable.DVDtitle, DVDtable.DVDartist, DVDtable.DVDrating, " +
                    " DVDtable.DVDprice, Details.PicURL, Details.Description FROM DVDtable INNER JOIN Details ON DVDtable.DVDID = Details.DVDID" +
                    " WHERE DVDtable.DVDID = @DVDID", conn);
            //Parameters for SELECT
            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = dvdList.SelectedItem.Value;
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    TextBoxTitle.Text = reader["DVDtitle"].ToString();
                    TextBoxArtist.Text = reader["DVDartist"].ToString();
                    TextBoxRating.Text = reader["DVDrating"].ToString();
                    string temp;
                    temp = reader["DVDprice"].ToString();
                    TextBoxPrice.Text = Convert.ToString(Math.Round(Convert.ToDecimal(temp), 2));
                    TextBoxImgURL.Text = reader["PicURL"].ToString();
                    TextBoxDescription.Text = reader["Description"].ToString();


                    
                }
                reader.Close();
                ButtonUpdate.Enabled = true;
                ButtonDelete.Enabled = true;
            }
            catch
            {
                dbErrorLabel.Text = "Error loading the DVD details!";
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Handles update button click by connecting to the database and updating DVD attributes in two tables in 
        /// the database with the values in the textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlCommand comm2;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            
            //UPDATE  DVDtable
            comm = new SqlCommand("UPDATE DVDtable SET DVDtitle =@DVDtitle, DVDartist =@DVDartist, " +
                  " DVDrating = @DVDrating, DVDprice = @DVDprice " +
                  " WHERE DVDID = @DVDID", conn);
            //parameters for update command
            comm.Parameters.Add("@DVDtitle", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@DVDtitle"].Value = TextBoxTitle.Text;

            comm.Parameters.Add("@DVDartist", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@DVDartist"].Value = TextBoxArtist.Text;

            comm.Parameters.Add("@DVDrating", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDrating"].Value = TextBoxRating.Text;

            comm.Parameters.Add("@DVDprice", System.Data.SqlDbType.Money);
            comm.Parameters["@DVDprice"].Value = TextBoxPrice.Text;

            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = dvdList.SelectedItem.Value;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                dbErrorLabel.Text = "Error updating the dvd details!";
            }
            finally
            {
                conn.Close();
            }

            //UPDATE Details
            comm2 = new SqlCommand("UPDATE Details SET PicURL =@PicURL, Description =@Description " +
                 " WHERE DVDID = @DVDID", conn);
            //parameters for update command
            comm2.Parameters.Add("@PicURL", System.Data.SqlDbType.NVarChar, 100);
            comm2.Parameters["@PicURL"].Value = TextBoxImgURL.Text;

            comm2.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 500);
            comm2.Parameters["@Description"].Value = TextBoxDescription.Text;

            comm2.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm2.Parameters["@DVDID"].Value = dvdList.SelectedItem.Value;
            try
            {
                conn.Open();
                comm2.ExecuteNonQuery();
            }
            catch
            {
                dbErrorLabel.Text = "Error updating the dvd details!";
            }
            finally
            {
                conn.Close();
            }
             

            LoadDVDList();
        }

        /// <summary>
        /// Handles the delete button click by connecting to the database and deleting the selected DVD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlCommand comm2;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);

            //DELETE from DVDtable
            comm = new SqlCommand("DELETE FROM DVDtable WHERE DVDID = @DVDID", conn);

            //parameters for delete command
            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = dvdList.SelectedItem.Value;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                dbErrorLabel.Text = "Error deleting the dvd details!";
            }
            finally
            {
                conn.Close();
            }

            //DELETE from Details
            comm2 = new SqlCommand("DELETE FROM Details WHERE DVDID = @DVDID", conn);

            //parameters for delete command
            comm2.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm2.Parameters["@DVDID"].Value = dvdList.SelectedItem.Value;
            try
            {
                conn.Open();
                comm2.ExecuteNonQuery();
            }
            catch
            {
                dbErrorLabel.Text = "Error deleting the dvd details!";
            }
            finally
            {
                conn.Close();
            }
            //reload dropdown list
            LoadDVDList();
        }


        /// <summary>
        /// Handles logoff button click by logging off user and redirecting to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonLogoff_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/home.aspx");
        }
    }
}