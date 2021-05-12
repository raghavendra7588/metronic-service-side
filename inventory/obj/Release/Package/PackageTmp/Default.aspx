
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="inventory.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .submitButton {
            display: none;
        }
        .formTable{
            display: none;
        }
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript">


        $(document).ready(function () {      
            $("[id*='submit']").click();
        });
    </script>



</head>
<body>
    <h4 style="text-align:center">YOUR TRANSACTION IS IN PROGRESS</h4>
    <form id="form1" runat="server" method="post">

        <div id="frmError" runat="server">
            <span style="color: red;display:none">Please fill all mandatory fields.</span>
            <br />
            <br />
        </div>


        <input type="hidden" runat="server" id="key" name="key" />
        <input type="hidden" runat="server" id="hash" name="hash" />
        <input type="hidden" runat="server" id="txnid" name="txnid" />
        <table class="formTable">
            <tr>
                <td><b>Mandatory Parameters</b></td>
            </tr>
            <tr>
                <td>Amount: </td>
                <td>
                    <asp:TextBox ID="amount" runat="server" /></td>
                <td>First Name: </td>
                <td>
                    <asp:TextBox ID="firstname" runat="server" /></td>
            </tr>
            <tr>
                <td>Email: </td>
                <td>
                    <asp:TextBox ID="email" runat="server" /></td>
                <td>Phone: </td>
                <td>
                    <asp:TextBox ID="phone" runat="server" /></td>
            </tr>
            <tr>
                <td>Product Info: </td>
                <td colspan="3">
                    <asp:TextBox ID="productinfo" runat="server" /></td>
            </tr>
            <tr>
                <td>Success URI: </td>
                <td colspan="3">
                    <asp:TextBox ID="surl" runat="server" /></td>
            </tr>
            <tr>
                <td>Failure URI: </td>
                <td colspan="3">
                    <asp:TextBox ID="furl" runat="server" /></td>
            </tr>
            <tr>
                <td><b>Optional Parameters</b></td>
            </tr>
            <tr>
                <td>Last Name: </td>
                <td>
                    <asp:TextBox ID="lastname" runat="server" /></td>
                <td>Cancel URI: </td>
                <td>
                    <asp:TextBox ID="curl" runat="server" /></td>

            </tr>
            <tr>
                <td>Address1: </td>
                <td>
                    <asp:TextBox ID="address1" runat="server" /></td>
                <td>Address2: </td>
                <td>
                    <asp:TextBox ID="address2" runat="server" /></td>
            </tr>
            <tr>
                <td>City: </td>
                <td>
                    <asp:TextBox ID="city" runat="server" /></td>
                <td>State: </td>
                <td>
                    <asp:TextBox ID="state" runat="server" /></td>
            </tr>
            <tr>
                <td>Country: </td>
                <td>
                    <asp:TextBox ID="country" runat="server" /></td>
                <td>Zipcode: </td>
                <td>
                    <asp:TextBox ID="zipcode" runat="server" /></td>
            </tr>
            <tr>
                <td>UDF1: </td>
                <td>
                    <asp:TextBox ID="udf1" runat="server" /></td>
                <td>UDF2: </td>
                <td>
                    <asp:TextBox ID="udf2" runat="server" /></td>
            </tr>
            <tr>
                <td>UDF3: </td>
                <td>
                    <asp:TextBox ID="udf3" runat="server" /></td>
                <td>UDF4: </td>
                <td>
                    <asp:TextBox ID="udf4" runat="server" /></td>
            </tr>
            <tr>
                <td>UDF5: </td>
                <td>
                    <asp:TextBox ID="udf5" runat="server" /></td>
                <td>PG: </td>
                <td>
                    <asp:TextBox ID="pg" runat="server" /></td>
            </tr>
            <tr>
                <td>Service Provider: </td>
                <td>
                    <asp:TextBox ID="service_provider" runat="server" Text="payu_paisa" /></td>
            </tr>
            <tr>

                <td colspan="4"></td>

            </tr>
        </table>
        <br />
        <asp:Button ID="submit" class="submitButton" Text="submit" Width="100px" runat="server" OnClick="Button1_Click" />
    </form>
</body>
</html>
