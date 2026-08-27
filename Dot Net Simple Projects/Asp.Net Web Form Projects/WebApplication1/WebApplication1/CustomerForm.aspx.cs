using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CustomerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(customerName))
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "error",
                    "alert('Please enter customer name.');",
                    true);

                return;
            }

            if (string.IsNullOrEmpty(phone))
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "error",
                    "alert('Please enter phone number.');",
                    true);

                return;
            }

            // TODO:
            // Save customer information to your SQL Server database here.

            ClientScript.RegisterStartupScript(
                this.GetType(),
                "success",
                "alert('Customer saved successfully!');",
                true);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtNotes.Text = "";

            ddlCountry.SelectedIndex = 0;
            ddlCustomerType.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
        }
    }
}