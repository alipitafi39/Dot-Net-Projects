using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // ==========================================
        // GET ALL CUSTOMERS
        // ==========================================

        private void GetAllCustomers()
        {
            using (CustomerDBEntities db =
                   new CustomerDBEntities())
            {
                var customers = db.Customers
                    .OrderByDescending(x => x.CustomerId)
                    .ToList();

                gvCustomers.DataSource = customers;

                gvCustomers.DataBind();
            }
        }


        // ==========================================
        // CREATE CUSTOMER
        // ==========================================

        private void CreateCustomer()
        {
            try
            {
                using (CustomerDBEntities db =
                       new CustomerDBEntities())
                {
                    Customer customer = new Customer();

                    customer.FirstName =
                        txtFirstName.Text.Trim();

                    customer.LastName =
                        txtLastName.Text.Trim();

                    customer.Email =
                        txtEmail.Text.Trim();

                    customer.Phone =
                        txtPhone.Text.Trim();

                    customer.Address =
                        txtAddress.Text.Trim();

                    customer.City =
                        txtCity.Text.Trim();

                    customer.CreatedDate =
                        DateTime.Now;


                    db.Customers.Add(customer);

                    db.SaveChanges();
                }


                ShowMessage(
                    "Customer created successfully.",
                    "success");


                ClearForm();

                GetAllCustomers();
            }
            catch (Exception ex)
            {
                ShowMessage(
                    "Error: " + ex.Message,
                    "danger");
            }
        }


        // ==========================================
        // SAVE BUTTON
        // CREATE OR UPDATE
        // ==========================================

        protected void btnSave_Click(
            object sender,
            EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }


            int customerId;


            if (int.TryParse(
                hfCustomerId.Value,
                out customerId))
            {
                // UPDATE

                UpdateCustomer(customerId);
            }
            else
            {
                // CREATE

                CreateCustomer();
            }
        }


        // ==========================================
        // GET CUSTOMER BY ID
        // USED FOR EDIT
        // ==========================================

        private void GetCustomerById(
            int customerId)
        {
            using (CustomerDBEntities db =
                   new CustomerDBEntities())
            {
                Customer customer =
                    db.Customers
                      .FirstOrDefault(x =>
                          x.CustomerId == customerId);


                if (customer == null)
                {
                    ShowMessage(
                        "Customer not found.",
                        "danger");

                    return;
                }


                // Store ID

                hfCustomerId.Value =
                    customer.CustomerId.ToString();


                // Fill Form

                txtFirstName.Text =
                    customer.FirstName;

                txtLastName.Text =
                    customer.LastName;

                txtEmail.Text =
                    customer.Email;

                txtPhone.Text =
                    customer.Phone;

                txtAddress.Text =
                    customer.Address;

                txtCity.Text =
                    customer.City;


                // Change form title

                lblFormTitle.Text =
                    "Edit Customer";


                // Change button text

                btnSave.Text =
                    "Update Customer";
            }
        }

        protected void gvCustomers_RowCommand(
    object sender,
    GridViewCommandEventArgs e)
        {
            int customerId;

            if (!int.TryParse(
                e.CommandArgument.ToString(),
                out customerId))
            {
                return;
            }

            if (e.CommandName == "EditCustomer")
            {
                GetCustomerById(customerId);
            }
            else if (e.CommandName == "DeleteCustomer")
            {
                DeleteCustomer(customerId);
            }
        }

        // ==========================================
        // EDIT BUTTON
        // ==========================================

        //protected void gvCustomers_RowEditing(
        //    object sender,
        //    GridViewEditEventArgs e)
        //{
        //    try
        //    {
        //        int customerId =
        //            Convert.ToInt32(
        //                gvCustomers
        //                .DataKeys[e.NewEditIndex]
        //                .Value);


        //        GetCustomerById(customerId);


        //        // We don't want GridView
        //        // inline edit mode.

        //        gvCustomers.EditIndex = -1;
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessage(
        //            "Error: " + ex.Message,
        //            "danger");
        //    }
        //}


        // ==========================================
        // UPDATE CUSTOMER
        // ==========================================

        private void UpdateCustomer(
            int customerId)
        {
            try
            {
                using (CustomerDBEntities db =
                       new CustomerDBEntities())
                {
                    Customer customer =
                        db.Customers
                          .FirstOrDefault(x =>
                              x.CustomerId == customerId);


                    if (customer == null)
                    {
                        ShowMessage(
                            "Customer not found.",
                            "danger");

                        return;
                    }


                    customer.FirstName =
                        txtFirstName.Text.Trim();

                    customer.LastName =
                        txtLastName.Text.Trim();

                    customer.Email =
                        txtEmail.Text.Trim();

                    customer.Phone =
                        txtPhone.Text.Trim();

                    customer.Address =
                        txtAddress.Text.Trim();

                    customer.City =
                        txtCity.Text.Trim();


                    db.SaveChanges();
                }


                ShowMessage(
                    "Customer updated successfully.",
                    "success");


                ClearForm();

                GetAllCustomers();
            }
            catch (Exception ex)
            {
                ShowMessage(
                    "Error: " + ex.Message,
                    "danger");
            }
        }


        // ==========================================
        // DELETE BUTTON
        // ==========================================

        //protected void gvCustomers_RowDeleting(
        //    object sender,
        //    GridViewDeleteEventArgs e)
        //{
        //    try
        //    {
        //        int customerId =
        //            Convert.ToInt32(
        //                gvCustomers
        //                .DataKeys[e.RowIndex]
        //                .Value);


        //        DeleteCustomer(customerId);
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessage(
        //            "Error: " + ex.Message,
        //            "danger");
        //    }
        //}


        // ==========================================
        // DELETE CUSTOMER
        // ==========================================

        private void DeleteCustomer(
            int customerId)
        {
            try
            {
                using (CustomerDBEntities db =
                       new CustomerDBEntities())
                {
                    Customer customer =
                        db.Customers
                          .FirstOrDefault(x =>
                              x.CustomerId == customerId);


                    if (customer == null)
                    {
                        ShowMessage(
                            "Customer not found.",
                            "danger");

                        return;
                    }


                    db.Customers.Remove(customer);

                    db.SaveChanges();
                }


                ShowMessage(
                    "Customer deleted successfully.",
                    "success");


                GetAllCustomers();
            }
            catch (Exception ex)
            {
                ShowMessage(
                    "Error: " + ex.Message,
                    "danger");
            }
        }


        // ==========================================
        // SEARCH
        // ==========================================

        protected void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            string search =
                txtSearch.Text.Trim();


            using (CustomerDBEntities db =
                   new CustomerDBEntities())
            {
                var customers =
                    db.Customers
                      .Where(x =>
                          x.FirstName.Contains(search) ||
                          x.LastName.Contains(search) ||
                          x.Email.Contains(search) ||
                          x.Phone.Contains(search) ||
                          x.City.Contains(search))
                      .OrderByDescending(
                          x => x.CustomerId)
                      .ToList();


                gvCustomers.DataSource =
                    customers;

                gvCustomers.DataBind();
            }
        }


        // ==========================================
        // SHOW ALL
        // ==========================================

        protected void btnShowAll_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Text =
                string.Empty;


            GetAllCustomers();
        }


        // ==========================================
        // CANCEL
        // ==========================================

        protected void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            ClearForm();
        }


        // ==========================================
        // CLEAR FORM
        // ==========================================

        private void ClearForm()
        {
            hfCustomerId.Value =
                string.Empty;


            txtFirstName.Text =
                string.Empty;

            txtLastName.Text =
                string.Empty;

            txtEmail.Text =
                string.Empty;

            txtPhone.Text =
                string.Empty;

            txtAddress.Text =
                string.Empty;

            txtCity.Text =
                string.Empty;


            lblFormTitle.Text =
                "Add Customer";


            btnSave.Text =
                "Save Customer";


            // Clear validation state

            Page.Validate();
        }


        // ==========================================
        // SHOW MESSAGE
        // ==========================================

        private void ShowMessage(
            string message,
            string type)
        {
            lblMessage.Text =
                message;

            lblMessage.CssClass =
                "alert alert-" +
                type +
                " d-inline-block";
        }
    }
}