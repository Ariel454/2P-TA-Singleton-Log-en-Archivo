<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogViewer.aspx.cs" Inherits="CRUD.Pages.LogViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log Viewer</title>
    <style>
        .log-container {
            width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f1f1f1;
            font-family: Arial, sans-serif;
        }

        .log-entry {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="log-container">
            <h2>Log Viewer</h2>
            <hr />
            <div id="logContent" runat="server"></div>
        </div>
    </form>
</body>
</html>
