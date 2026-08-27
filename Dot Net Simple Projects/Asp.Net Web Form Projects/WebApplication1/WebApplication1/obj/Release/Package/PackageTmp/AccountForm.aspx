<%--<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="AccountForm.aspx.cs"
    Inherits="WebApplication1.AccountForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title>Account Information</title>

    <style type="text/css">

        * {
            box-sizing: border-box;
        }

        body {
            margin: 0;
            padding: 0;
            font-family: "Segoe UI", Arial, sans-serif;
            background: #f2f5f9;
            color: #333;
        }

        .page {
            width: 92%;
            max-width: 1200px;
            margin: 40px auto;
        }

        .header {
            background: #1769aa;
            color: white;
            padding: 25px 30px;
            border-radius: 10px 10px 0 0;
        }

        .header h1 {
            margin: 0;
            font-size: 28px;
            font-weight: 600;
        }

        .header p {
            margin: 7px 0 0;
            color: #dceeff;
            font-size: 14px;
        }

        .content {
            background: white;
            padding: 30px;
            border-radius: 0 0 10px 10px;
            box-shadow: 0 5px 20px rgba(0,0,0,0.08);
        }

        .search-box {
            background: #f8fafc;
            border: 1px solid #e1e7ef;
            border-radius: 8px;
            padding: 22px;
            margin-bottom: 25px;
        }

        .search-title {
            font-size: 18px;
            font-weight: 600;
            color: #263238;
            margin-bottom: 15px;
        }

        .label {
            display: block;
            font-size: 14px;
            font-weight: 600;
            margin-bottom: 7px;
            color: #455a64;
        }

        .textbox {
            width: 280px;
            height: 40px;
            padding: 8px 12px;
            border: 1px solid #cbd5e1;
            border-radius: 6px;
            font-size: 14px;
            margin-bottom: 15px;
        }

        .textbox:focus {
            border-color: #1769aa;
            outline: none;
            box-shadow: 0 0 0 3px rgba(23,105,170,0.12);
        }

        .button-row {
            display: flex;
            gap: 10px;
            flex-wrap: wrap;
        }

        .btn {
            height: 40px;
            padding: 0 20px;
            border: none;
            border-radius: 6px;
            color: white;
            font-size: 14px;
            font-weight: 600;
            cursor: pointer;
        }

        .btn-web {
            background: #6c757d;
        }

        .btn-web:hover {
            background: #545b62;
        }

        .btn-wcf {
            background: #1769aa;
        }

        .btn-wcf:hover {
            background: #0d4f80;
        }

        .message {
            display: block;
            margin: 10px 0 20px;
            color: #dc3545;
            font-size: 14px;
        }

        .grid-title {
            font-size: 18px;
            font-weight: 600;
            color: #263238;
            margin-bottom: 12px;
        }

        .grid-container {
            overflow-x: auto;
        }

        .account-grid {
            width: 100%;
            border-collapse: collapse;
            font-size: 14px;
        }

        .account-grid th {
            background: #1769aa;
            color: white;
            padding: 13px 12px;
            text-align: left;
            white-space: nowrap;
        }

        .account-grid td {
            padding: 12px;
            border-bottom: 1px solid #e5e7eb;
        }

        .account-grid tr:nth-child(even) {
            background: #f8fafc;
        }

        .account-grid tr:hover {
            background: #eaf4ff;
        }

        @media screen and (max-width: 600px) {

            .page {
                width: 96%;
                margin: 15px auto;
            }

            .content {
                padding: 18px;
            }

            .textbox {
                width: 100%;
            }

            .button-row {
                display: block;
            }

            .btn {
                width: 100%;
                margin-bottom: 8px;
            }
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div>

        <h2>Get Account</h2>

        <asp:TextBox
            ID="txtAccountNumber"
            runat="server"
            CssClass="form-control"
            placeholder="ACC-1001">
        </asp:TextBox>

        <br />

        <asp:Button
            ID="btnGetAccount"
            runat="server"
            Text="Get Account Via Web Service"
            OnClick="btnGetAccount_Click"
            CausesValidation="false" />

         <asp:Button
            ID="btnFetchAccountsByWCF"
            runat="server"
            Text="Get Account Via WCF"
            OnClick="btnFetchAccounts_Click"
            CausesValidation="false" />

        <br />
        <br />

        <asp:Label
            ID="lblMessage"
            runat="server">
        </asp:Label>

        <br />
        <br />

        <asp:GridView ID="gvAccounts"
    runat="server"
    AutoGenerateColumns="False"
    Width="100%"
    AutoGenerateEditButton="False">

    <Columns>

        <asp:BoundField
            DataField="AccountId"
            HeaderText="Account ID" />

        <asp:BoundField
            DataField="AccountNumber"
            HeaderText="Account Number" />

        <asp:BoundField
            DataField="AccountName"
            HeaderText="Account Name" />

        <asp:BoundField
            DataField="AccountType"
            HeaderText="Account Type" />

        <asp:BoundField
            DataField="Balance"
            HeaderText="Balance"
            DataFormatString="{0:N2}" />

        <asp:BoundField
            DataField="Status"
            HeaderText="Status" />

    </Columns>

</asp:GridView>

    </div>

</form>

</body>

</html>--%>

<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="AccountForm.aspx.cs"
    Inherits="WebApplication1.AccountForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title>Account Information</title>

    <style type="text/css">

        * {
            box-sizing: border-box;
        }

        body {
            margin: 0;
            padding: 0;
            font-family: "Segoe UI", Arial, sans-serif;
            background: #f2f5f9;
            color: #333;
        }

        .page {
            width: 92%;
            max-width: 1200px;
            margin: 40px auto;
        }

        .header {
            background: #1769aa;
            color: white;
            padding: 25px 30px;
            border-radius: 10px 10px 0 0;
        }

        .header h1 {
            margin: 0;
            font-size: 28px;
            font-weight: 600;
        }

        .header p {
            margin: 7px 0 0;
            color: #dceeff;
            font-size: 14px;
        }

        .content {
            background: white;
            padding: 30px;
            border-radius: 0 0 10px 10px;
            box-shadow: 0 5px 20px rgba(0,0,0,0.08);
        }

        .search-box {
            background: #f8fafc;
            border: 1px solid #e1e7ef;
            border-radius: 8px;
            padding: 22px;
            margin-bottom: 25px;
        }

        .search-title {
            font-size: 18px;
            font-weight: 600;
            color: #263238;
            margin-bottom: 15px;
        }

        .label {
            display: block;
            font-size: 14px;
            font-weight: 600;
            margin-bottom: 7px;
            color: #455a64;
        }

        .textbox {
            width: 280px;
            height: 40px;
            padding: 8px 12px;
            border: 1px solid #cbd5e1;
            border-radius: 6px;
            font-size: 14px;
            margin-bottom: 15px;
        }

        .textbox:focus {
            border-color: #1769aa;
            outline: none;
            box-shadow: 0 0 0 3px rgba(23,105,170,0.12);
        }

        .button-row {
            display: flex;
            gap: 10px;
            flex-wrap: wrap;
        }

        .btn {
            height: 40px;
            padding: 0 20px;
            border: none;
            border-radius: 6px;
            color: white;
            font-size: 14px;
            font-weight: 600;
            cursor: pointer;
        }

        .btn-web {
            background: #6c757d;
        }

        .btn-web:hover {
            background: #545b62;
        }

        .btn-wcf {
            background: #1769aa;
        }

        .btn-wcf:hover {
            background: #0d4f80;
        }

        .message {
            display: block;
            margin: 10px 0 20px;
            color: #dc3545;
            font-size: 14px;
        }

        .grid-title {
            font-size: 18px;
            font-weight: 600;
            color: #263238;
            margin-bottom: 12px;
        }

        .grid-container {
            overflow-x: auto;
        }

        .account-grid {
            width: 100%;
            border-collapse: collapse;
            font-size: 14px;
        }

        .account-grid th {
            background: #1769aa;
            color: white;
            padding: 13px 12px;
            text-align: left;
            white-space: nowrap;
        }

        .account-grid td {
            padding: 12px;
            border-bottom: 1px solid #e5e7eb;
        }

        .account-grid tr:nth-child(even) {
            background: #f8fafc;
        }

        .account-grid tr:hover {
            background: #eaf4ff;
        }

        @media screen and (max-width: 600px) {

            .page {
                width: 96%;
                margin: 15px auto;
            }

            .content {
                padding: 18px;
            }

            .textbox {
                width: 100%;
            }

            .button-row {
                display: block;
            }

            .btn {
                width: 100%;
                margin-bottom: 8px;
            }
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

    <div class="page">

        <!-- Header -->

        <div class="header">

            <h1>Account Information</h1>

            <p>
                Search customer account information using Web Service or WCF Service
            </p>

        </div>


        <!-- Content -->

        <div class="content">

            <!-- Search -->

            <div class="search-box">

                <div class="search-title">
                    Account Search
                </div>

                <asp:Label
                    ID="lblAccountId"
                    runat="server"
                    Text="Account ID"
                    CssClass="label">
                </asp:Label>

                <asp:TextBox
                    ID="txtAccountNumber"
                    runat="server"
                    CssClass="textbox"
                    placeholder="Enter Account ID">
                </asp:TextBox>

                <div class="button-row">

                    <!-- Existing Web Service -->

                    <asp:Button
                        ID="btnGetAccount"
                        runat="server"
                        Text="Get Account Via Web Service"
                        CssClass="btn btn-web"
                        OnClick="btnGetAccount_Click"
                        CausesValidation="false" />

                    <!-- WCF -->

                    <asp:Button
                        ID="btnFetchAccountsByWCF"
                        runat="server"
                        Text="Get Account Via WCF"
                        CssClass="btn btn-wcf"
                        OnClick="btnFetchAccounts_Click"
                        CausesValidation="false" />

                </div>

            </div>


            <!-- Message -->

            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="message">
            </asp:Label>


            <!-- Grid -->

            <div class="grid-title">
                Account Details
            </div>

            <div class="grid-container">

                <asp:GridView
                    ID="gvAccounts"
                    runat="server"
                    CssClass="account-grid"
                    AutoGenerateColumns="False"
                    Width="100%"
                    GridLines="None">

                    <Columns>

                        <asp:BoundField
                            DataField="AccountId"
                            HeaderText="Account ID" />

                        <asp:BoundField
                            DataField="AccountNumber"
                            HeaderText="Account Number" />

                        <asp:BoundField
                            DataField="AccountName"
                            HeaderText="Account Name" />

                        <asp:BoundField
                            DataField="AccountType"
                            HeaderText="Account Type" />

                        <asp:BoundField
                            DataField="Balance"
                            HeaderText="Balance"
                            DataFormatString="{0:N2}" />

                        <asp:BoundField
                            DataField="Status"
                            HeaderText="Status" />

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</form>

</body>

</html>
