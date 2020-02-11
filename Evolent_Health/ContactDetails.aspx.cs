using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Evolent_Health
{
    public partial class ContactDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_ContactDetail"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void Insert(object sender, EventArgs e)
        {
            string Firstname = txtFName.Text;
            string Lastname = txtLname.Text;
            string Email = txtaddmail.Text;
            string Mobile = txtaddmobile.Text;
            string Status = "Inactive";
            if (chkstatus.Checked)
            {
                Status = "Active";
            }
            txtFName.Text = string.Empty;
            txtLname.Text = string.Empty;
            txtaddmail.Text = string.Empty;
            txtaddmobile.Text = string.Empty;
            string query = "INSERT INTO tbl_ContactDetail VALUES(@Firstname,@Lastname,@Email,@Mobile,@Status)";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Firstname", Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", Lastname);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int ContactId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string Firstname = (row.Cells[2].Controls[0] as TextBox).Text;
            string Lastname = (row.Cells[3].Controls[0] as TextBox).Text;
            string Email = (row.Cells[4].Controls[0] as TextBox).Text;
            string Mobile = (row.Cells[5].Controls[0] as TextBox).Text;
            string Status = (row.Cells[6].Controls[0] as TextBox).Text;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_ContactDetail SET Firstname=@Firstname, Lastname=@Lastname,Email=@Email,Mobile=@Mobile,Status=@Status WHERE ContactId=@ContactId"))
                {
                    cmd.Parameters.AddWithValue("@ContactId", ContactId);
                    cmd.Parameters.AddWithValue("@Firstname", Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", Lastname);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this record ?');";
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ContactId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_ContactDetail WHERE ContactId = @ContactId"))
                {
                    cmd.Parameters.AddWithValue("@ContactId", ContactId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
        }
    }
}