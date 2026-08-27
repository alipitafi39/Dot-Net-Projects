<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="WebApplication1.CustomerForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Customer Information</title>
    <link href="Content/CustomerForm.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>

<body>
    <form id="form1" runat="server">

        <div class="page-wrapper">

            <div class="customer-card">

                <!-- Header -->
                <div class="card-header">
                    <div class="header-icon">
                        👤
                    </div>

                    <div>
                        <h1>Customer Information</h1>
                        <p>Please enter the customer's details below</p>
                    </div>
                </div>

                <!-- Form -->
                <div class="form-content">

                    <div class="section-title">
                        <span>Personal Details</span>
                    </div>

                    <div class="form-grid">

                        <div class="form-group">
                            <label>Customer ID</label>
                            <asp:TextBox ID="txtCustomerID"
                                runat="server"
                                CssClass="form-control"
                                placeholder="e.g. CUST-1001">
                            </asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Customer Name <span>*</span></label>
                            <asp:TextBox ID="txtCustomerName"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Enter customer name">
                            </asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Phone Number <span>*</span></label>
                            <asp:TextBox ID="txtPhone"
                                runat="server"
                                CssClass="form-control"
                                placeholder="+92 300 1234567">
                            </asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Email Address</label>
                            <asp:TextBox ID="txtEmail"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Email"
                                placeholder="customer@example.com">
                            </asp:TextBox>
                        </div>

                    </div>

                    <div class="section-title">
                        <span>Address Details</span>
                    </div>

                    <div class="form-grid">

                        <div class="form-group full-width">
                            <label>Address</label>
                            <asp:TextBox ID="txtAddress"
                                runat="server"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                Rows="3"
                                placeholder="Enter complete address">
                            </asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox ID="txtCity"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Enter city">
                            </asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Country</label>
                            <asp:DropDownList ID="ddlCountry"
                                runat="server"
                                CssClass="form-control">
                                <asp:ListItem Value="">Select Country</asp:ListItem>
                                <asp:ListItem Value="Pakistan">Pakistan</asp:ListItem>
                                <asp:ListItem Value="India">India</asp:ListItem>
                                <asp:ListItem Value="UAE">United Arab Emirates</asp:ListItem>
                                <asp:ListItem Value="UK">United Kingdom</asp:ListItem>
                                <asp:ListItem Value="USA">United States</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="section-title">
                        <span>Additional Information</span>
                    </div>

                    <div class="form-grid">

                        <div class="form-group">
                            <label>Customer Type</label>
                            <asp:DropDownList ID="ddlCustomerType"
                                runat="server"
                                CssClass="form-control">
                                <asp:ListItem Value="">Select Type</asp:ListItem>
                                <asp:ListItem Value="Individual">Individual</asp:ListItem>
                                <asp:ListItem Value="Business">Business</asp:ListItem>
                                <asp:ListItem Value="Corporate">Corporate</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>Status</label>
                            <asp:DropDownList ID="ddlStatus"
                                runat="server"
                                CssClass="form-control">
                                <asp:ListItem Value="Active">Active</asp:ListItem>
                                <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group full-width">
                            <label>Notes</label>
                            <asp:TextBox ID="txtNotes"
                                runat="server"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                Rows="4"
                                placeholder="Additional notes...">
                            </asp:TextBox>
                        </div>

                    </div>

                </div>

                <!-- Footer -->
                <div class="card-footer">

                    <asp:Button ID="btnClear"
                        runat="server"
                        Text="Clear"
                        CssClass="btn btn-secondary"
                        OnClick="btnClear_Click" />

                    <asp:Button ID="btnSave"
                        runat="server"
                        Text="Save Customer"
                        CssClass="btn btn-primary"
                        OnClick="btnSave_Click" />

                </div>

            </div>

        </div>

    </form>
</body>
</html>
