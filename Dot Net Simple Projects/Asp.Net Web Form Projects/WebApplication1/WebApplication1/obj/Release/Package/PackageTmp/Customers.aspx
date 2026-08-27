<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="WebApplication1.Customers" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title>Customer Management</title>

    <meta charset="utf-8" />

    <meta name="viewport"
          content="width=device-width, initial-scale=1" />

    <link
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
        rel="stylesheet" />

</head>

<body>

<form id="form1" runat="server">

<div class="container mt-5">

    <h2 class="mb-4">
        Customer Management
    </h2>


    <!-- ========================================= -->
    <!-- CUSTOMER FORM -->
    <!-- ========================================= -->

    <div class="card mb-4">

        <div class="card-header">

            <asp:Label
                ID="lblFormTitle"
                runat="server"
                Text="Add Customer"
                Font-Bold="true">
            </asp:Label>

        </div>


        <div class="card-body">

            <!-- Customer ID -->

            <asp:HiddenField
                ID="hfCustomerId"
                runat="server" />


            <div class="row">


                <!-- FIRST NAME -->

                <div class="col-md-6 mb-3">

                    <label class="form-label">
                        First Name
                    </label>

                    <asp:TextBox
                        ID="txtFirstName"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvFirstName"
                        runat="server"
                        ControlToValidate="txtFirstName"
                        ErrorMessage="First name is required."
                        CssClass="text-danger"
                        Display="Dynamic"
                        ValidationGroup="CustomerForm">
                    </asp:RequiredFieldValidator>

                </div>


                <!-- LAST NAME -->

                <div class="col-md-6 mb-3">

                    <label class="form-label">
                        Last Name
                    </label>

                    <asp:TextBox
                        ID="txtLastName"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvLastName"
                        runat="server"
                        ControlToValidate="txtLastName"
                        ErrorMessage="Last name is required."
                        CssClass="text-danger"
                        Display="Dynamic"
                        ValidationGroup="CustomerForm">
                    </asp:RequiredFieldValidator>

                </div>


                <!-- EMAIL -->

                <div class="col-md-6 mb-3">

                    <label class="form-label">
                        Email
                    </label>

                    <asp:TextBox
                        ID="txtEmail"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvEmail"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Email is required."
                        CssClass="text-danger"
                        Display="Dynamic"
                        ValidationGroup="CustomerForm">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator
                        ID="revEmail"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Enter a valid email."
                        CssClass="text-danger"
                        Display="Dynamic"
                        ValidationGroup="CustomerForm"
                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$">
                    </asp:RegularExpressionValidator>

                </div>


                <!-- PHONE -->

                <div class="col-md-6 mb-3">

                    <label class="form-label">
                        Phone
                    </label>

                    <asp:TextBox
                        ID="txtPhone"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                </div>


                <!-- ADDRESS -->

                <div class="col-md-6 mb-3">

                    <label class="form-label">
                        Address
                    </label>

                    <asp:TextBox
                        ID="txtAddress"
                        runat="server"
                        CssClass="form-control"
                        TextMode="MultiLine"
                        Rows="3">
                    </asp:TextBox>

                </div>


                <!-- CITY -->

                <div class="col-md-6 mb-3">

                    <label class="form-label">
                        City
                    </label>

                    <asp:TextBox
                        ID="txtCity"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                </div>

            </div>


            <!-- SAVE -->

            <asp:Button
                ID="btnSave"
                runat="server"
                Text="Save Customer"
                CssClass="btn btn-primary me-2"
                ValidationGroup="CustomerForm"
                OnClick="btnSave_Click" />


            <!-- CANCEL -->

            <asp:Button
                ID="btnCancel"
                runat="server"
                Text="Cancel"
                CssClass="btn btn-secondary"
                CausesValidation="false"
                OnClick="btnCancel_Click" />


            <br />
            <br />


            <!-- MESSAGE -->

            <asp:Label
                ID="lblMessage"
                runat="server">
            </asp:Label>

        </div>

    </div>



    <!-- ========================================= -->
    <!-- SEARCH -->
    <!-- ========================================= -->

    <div class="card mb-4">

        <div class="card-body">

            <div class="row">

                <div class="col-md-8">

                    <asp:TextBox
                        ID="txtSearch"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Search by name, email, phone or city">
                    </asp:TextBox>

                </div>


                <div class="col-md-4">

                    <asp:Button
                        ID="btnSearch"
                        runat="server"
                        Text="Search"
                        CssClass="btn btn-success me-2"
                        CausesValidation="false"
                        OnClick="btnSearch_Click" />


                    <asp:Button
                        ID="btnShowAll"
                        runat="server"
                        Text="Show All"
                        CssClass="btn btn-secondary"
                        CausesValidation="false"
                        OnClick="btnShowAll_Click" />

                </div>

            </div>

        </div>

    </div>



    <!-- ========================================= -->
    <!-- CUSTOMER GRID -->
    <!-- ========================================= -->

    <div class="card">

        <div class="card-header">

            <strong>
                Customer List
            </strong>

        </div>


        <div class="card-body">



           <asp:GridView
    ID="gvCustomers"
    runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="CustomerId"
    CssClass="table table-bordered table-striped"
    EmptyDataText="No customers found."
    OnRowCommand="gvCustomers_RowCommand">

    <Columns>

        <asp:BoundField
            DataField="CustomerId"
            HeaderText="ID"
            ReadOnly="true" />

        <asp:BoundField
            DataField="FirstName"
            HeaderText="First Name"
            ReadOnly="true" />

        <asp:BoundField
            DataField="LastName"
            HeaderText="Last Name"
            ReadOnly="true" />

        <asp:BoundField
            DataField="Email"
            HeaderText="Email"
            ReadOnly="true" />

        <asp:BoundField
            DataField="Phone"
            HeaderText="Phone"
            ReadOnly="true" />

        <asp:BoundField
            DataField="City"
            HeaderText="City"
            ReadOnly="true" />

        <asp:BoundField
            DataField="CreatedDate"
            HeaderText="Created Date"
            DataFormatString="{0:yyyy-MM-dd}"
            ReadOnly="true" />

        <asp:TemplateField HeaderText="Actions">

            <ItemTemplate>

                <asp:LinkButton
                    ID="btnEdit"
                    runat="server"
                    Text="Edit"
                    CommandName="EditCustomer"
                    CommandArgument='<%# Eval("CustomerId") %>'
                    CausesValidation="false"
                    CssClass="btn btn-warning btn-sm me-2">
                    Edit
                </asp:LinkButton>

                <asp:LinkButton
                    ID="btnDelete"
                    runat="server"
                    Text="Delete"
                    CommandName="DeleteCustomer"
                    CommandArgument='<%# Eval("CustomerId") %>'
                    CausesValidation="false"
                    CssClass="btn btn-danger btn-sm"
                    OnClientClick="return confirm('Are you sure you want to delete this customer?');">
                    Delete
                </asp:LinkButton>

            </ItemTemplate>

        </asp:TemplateField>

    </Columns>

</asp:GridView>

        </div>

    </div>

</div>

</form>

</body>

</html>
