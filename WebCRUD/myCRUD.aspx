<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="YourNamespace.Table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Table Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Добавление элементов различных разделов -->
            <asp:Label ID="lblData1" runat="server" Text="Data Element 1" /><br />
            <asp:TextBox ID="txtData1" runat="server"></asp:TextBox><br />
            
            <asp:Label ID="lblData2" runat="server" Text="Data Element 2" /><br />
            <asp:DropDownList ID="ddlData2" runat="server">
                <asp:ListItem Text="Option 1" Value="1" />
                <asp:ListItem Text="Option 2" Value="2" />
            </asp:DropDownList><br />
            
            <asp:Label ID="lblNavigation1" runat="server" Text="Navigation Element 1" /><br />
            <asp:HyperLink ID="hlNavigation1" runat="server" NavigateUrl="#" Text="Link 1" /><br />
            
            <asp:Label ID="lblNavigation2" runat="server" Text="Navigation Element 2" /><br />
            <asp:HyperLink ID="hlNavigation2" runat="server" NavigateUrl="#" Text="Link 2" /><br />
            
            <asp:Label ID="lblValidator1" runat="server" Text="Validator Element 1" /><br />
            <asp:RegularExpressionValidator ID="revValidator1" runat="server" ControlToValidate="txtValidator1"
                ErrorMessage="Invalid input" ValidationExpression="\d+" /><br />
            
            <asp:Label ID="lblValidator2" runat="server" Text="Validator Element 2" /><br />
            <asp:RequiredFieldValidator ID="rfvValidator2" runat="server" ControlToValidate="txtValidator2"
                ErrorMessage="This field is required" /><br />
            
            <asp:Label ID="lblHtml1" runat="server" Text="HTML Element 1" /><br />
            <input type="text" id="txtHtml1" runat="server" /><br />
            
            <asp:Label ID="lblHtml2" runat="server" Text="HTML Element 2" /><br />
            <textarea id="txtHtml2" runat="server"></textarea><br />

            <!-- Использование серверного элемента HtmlTable для отображения таблицы -->
            <asp:Table ID="htmlTable" runat="server"></asp:Table>
        </div>
    </form>
</body>
</html>
