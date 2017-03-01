<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="jQueryWCF.Default" %>

<!DOCTYPE html>

<html>
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <p id="output"></p><br/>
            <input id="buttonNext" type="button" value="Следующий элемент >>" /><br />
            <asp:Button ID="Button1" runat="server" Text="Рестарт >>" OnClick="Button1_Click" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            <scripts>
                <asp:ScriptReference Path="~/js/jquery-1.11.1.min.js" />
                <asp:ScriptReference Path="~/js/default.js" />
            </scripts>
            <services>
                <asp:ServiceReference Path="~/Service1.svc" />
            </services>
        </asp:ScriptManager>
        </div>
        </form>
    
    </body>
</html>
