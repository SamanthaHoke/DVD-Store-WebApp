using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace HokeDVD.Admin
{
    public partial class AddDVD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles Add button click by connecting to database and creating a new dvd record, if the page is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddDVDButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                long insertedId = 0;
                //set up connection and insert record for new DVD
                SqlConnection conn;
                SqlCommand comm;
                SqlCommand comm2;
                string connectionString = ConfigurationManager.ConnectionStrings["DVDconnstring"].ConnectionString;
                conn = new SqlConnection(connectionString);
                //INSERT INTO DVDtable
                comm = new SqlCommand("INSERT INTO DVDtable ( DVDtitle, " +
                         "DVDartist, DVDrating, DVDprice) " +
                         "VALUES (@DVDtitle, @DVDartist, " +
                         "@DVDrating, @DVDprice); SELECT SCOPE_IDENTITY()", conn);
                
                //parameters for insert command
                comm.Parameters.Add("@DVDtitle", System.Data.SqlDbType.NVarChar, 50);
                comm.Parameters["@DVDtitle"].Value = TextboxTitle.Text;

                comm.Parameters.Add("@DVDartist", System.Data.SqlDbType.NVarChar, 50);
                comm.Parameters["@DVDartist"].Value = TextboxArtist.Text;

                comm.Parameters.Add("@DVDrating", System.Data.SqlDbType.Int);
                comm.Parameters["@DVDrating"].Value = TextboxRating.Text;

                comm.Parameters.Add("@DVDprice", System.Data.SqlDbType.Money);
                comm.Parameters["@DVDprice"].Value = TextboxPrice.Text;
                try
                {
                    conn.Open();
                    insertedId = Convert.ToInt64(comm.ExecuteScalar());
                    
                }
                catch
                {
                    dbErrorLabel.Text = "Error submitting the new DVD! Please " + "try again later, and/ or change the entered data!";
                }
                finally
                {
                    conn.Close();
                    //clear textboxes
                    TextboxTitle.Text = string.Empty;
                    TextboxArtist.Text = string.Empty;
                    TextboxRating.Text = string.Empty;
                    TextboxPrice.Text = string.Empty;

                }

                //INSERT INTO Details
                comm2 = new SqlCommand("INSERT INTO Details ( DVDID, " +
                         "Description, PicURL) " +
                         "VALUES (@DVDID, @Description, " +
                         "@PicURL)", conn);

                //parameters for insert command
                comm2.Parameters.Add("@DVDID", System.Data.SqlDbType.Int);
                comm2.Parameters["@DVDID"].Value = (int)insertedId;

                comm2.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 500);
                comm2.Parameters["@Description"].Value = TextBoxDescription.Text;

                comm2.Parameters.Add("@PicURL", System.Data.SqlDbType.NVarChar, 100);
                comm2.Parameters["@PicURL"].Value = TextboxImgURL.Text;
                try
                {
                    conn.Open();
                    comm2.ExecuteNonQuery();

                }
                catch
                {
                    dbErrorLabel.Text = "Error submitting the new DVD! Please " + "try again later, and/ or change the entered data!";
                }
                finally
                {
                    conn.Close();
                    //clear textboxes
                    TextboxImgURL.Text = "";
                    TextBoxDescription.Text = "";

                }

            }

        }

        /// <summary>
        /// Handles click event for Log off button by logging off user and redirecting to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonLogOff_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/home.aspx");
        }
    }
}