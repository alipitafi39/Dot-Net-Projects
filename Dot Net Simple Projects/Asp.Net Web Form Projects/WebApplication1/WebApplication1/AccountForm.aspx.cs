using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.AccountService;

namespace WebApplication1
{
    public partial class AccountForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // =================================================
        // GET ACCOUNT BUTTON TO FETCH DATA FROM WCF SERVICE
        // =================================================
        protected void btnFetchAccounts_Click(object sender, EventArgs e)
        {
            AccountWcfService.AccountService client =
                new AccountWcfService.AccountService();

            try
            {
                AccountWcfService.Account[] accounts;

                if (!String.IsNullOrWhiteSpace(txtAccountNumber.Text))
                {
                    
                    var account = client.GetAccount(
                        txtAccountNumber.Text);

                    accounts = new AccountWcfService.Account[] { account };
                }
                else
                {
                    accounts = client.GetAccounts();
                }

                gvAccounts.DataSource = accounts;
                gvAccounts.DataBind();
            }
            catch (Exception ex)
            {
                // For testing
                Response.Write("<script>alert('Error: " +
                    ex.Message.Replace("'", "\\'") +
                    "');</script>");
            }
        }

        // =================================================
        // GET ACCOUNT BUTTON TO FETCH DATA FROM WEB SERVICE
        // =================================================

        protected void btnGetAccount_Click(
            object sender,
            EventArgs e)
        {
            string accountNumber =
                txtAccountNumber.Text.Trim();


            try
            {
                // Create Web Service client

                WebApplication1.AccountService.AccountService service =
                    new WebApplication1.AccountService.AccountService();


                // Call separate Web Service

                WebApplication1.AccountService.Account[] accounts=null;

                if (!String.IsNullOrWhiteSpace(accountNumber))
                {
                    var account = service.GetAccount(
                       accountNumber);

                    if (account != null)
                    accounts = new WebApplication1.AccountService.Account[] { account };
                }
                else
                {
                    accounts = service.GetAllAccounts();
                }

                if (accounts == null)
                {
                    lblMessage.Text =
                        "Account not found.";

                    lblMessage.CssClass =
                        "text-danger";

                    gvAccounts.DataSource = null;

                    gvAccounts.DataBind();

                    return;
                }


                // Put account into GridView

                gvAccounts.DataSource = accounts;

                gvAccounts.DataBind();


                lblMessage.Text =
                    "Account fetched successfully.";

                lblMessage.CssClass =
                    "text-success";
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error: " + ex.Message;

                lblMessage.CssClass =
                    "text-danger";
            }
        }
    }
}