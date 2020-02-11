﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactDetails.aspx.cs" Inherits="Evolent_Health.ContactDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
            background-color: #fff;
        }
        table th
        {
            background-color: #B8DBFD;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
        table, table table td
        {
            border: 0px solid #ccc;
        }
           .button {
              background-color: #4CAF50; /* Green */
              border: none;
              color: white;
              padding: 5px 22px;
              text-align: center;
              text-decoration: none;
              display: inline-block;
              font-size: 16px;
              margin: 1px 0px;
              cursor: pointer;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table border="1" style="border-collapse: collapse;width:960px;">
            <tr>
                <td style="width: 200px">
                   FirstName:<br />
                   <asp:TextBox ID="txtFName" runat="server" Width="180" />
                    <asp:RequiredFieldValidator ID="fnamereq" runat="server" ControlToValidate="txtFName" ErrorMessage="*" ForeColor="Red" ValidationGroup="btnsubmitvalidate"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 200px">
                   LastName:<br />
                   <asp:TextBox ID="txtLname" runat="server" Width="180" />
                    <asp:RequiredFieldValidator ID="lnamereq" runat="server" ControlToValidate="txtLname" ErrorMessage="*" ForeColor="Red" ValidationGroup="btnsubmitvalidate"></asp:RequiredFieldValidator>
                </td>
                 <td style="width: 200px">
                   Email:<br />
                   <asp:TextBox ID="txtaddmail" runat="server" Width="180" />
                     <asp:RequiredFieldValidator ID="txtmailreq" runat="server" ControlToValidate="txtaddmail" ErrorMessage="*" ForeColor="Red" ValidationGroup="btnsubmitvalidate"></asp:RequiredFieldValidator>
                </td>
                 <td style="width: 200px">
                   Mobile:<br />
                   <asp:TextBox ID="txtaddmobile" runat="server" Width="180" MaxLength="13" TextMode="Number" />
                     <asp:RequiredFieldValidator ID="txtmobreq" runat="server" ControlToValidate="txtaddmobile" ErrorMessage="*" ForeColor="Red" ValidationGroup="btnsubmitvalidate"></asp:RequiredFieldValidator>
                </td>
                 <td style="width: 160px">
                   Status:<br />
                   <asp:CheckBox ID="chkstatus" runat="server" Width="142" Checked="false" />
                </td>
                <td style="width: 200px">
                   <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" ValidationGroup="btnsubmitvalidate" class="button" />                 
                </td>
            </tr>            
        </table>
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="ContactId" OnRowDataBound="OnRowDataBound"
        OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating"
        OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateEditButton="true"
        ShowHeaderWhenEmpty="true" AutoGenerateDeleteButton="true" Width="1020px">
    </asp:GridView>
    </form>
</body>
</html>

