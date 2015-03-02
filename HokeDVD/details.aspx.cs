using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HokeDVD
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Fill labels with selected DVD info
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("SELECT DVDtable.DVDtitle, DVDtable.DVDartist, DVDtable.DVDrating, Details.Description, Details.PicURL FROM DVDtable INNER JOIN Details ON DVDtable.DVDID = Details.DVDID WHERE  DVDtable.DVDID = @DVDID", conn);

            comm.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
            comm.Parameters["@DVDID"].Value = Convert.ToInt32(Request.QueryString["id"]); // get the passed DVDID
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    LabelTitle.Text = reader["DVDtitle"].ToString();
                    LabelArtist.Text = reader["DVDartist"].ToString();
                    LabelRating.Text = reader["DVDrating"].ToString();
                    LabelDescription.Text = reader["Description"].ToString();
                    Pic.ImageUrl = reader["PicURL"].ToString();
                }
                reader.Close();
            }
            catch
            {
                dbErrorLabel.Text = "Error loading the DVD info";
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Handles done button click by redirecting to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("/home.aspx");
        }
    }
}