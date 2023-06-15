using System;
using System.IO;

namespace CRUD.Pages
{
    public partial class LogViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/Pages/Logs/ActivityLog.txt"); // Ruta del archivo de registro

            if (File.Exists(filePath))
            {
                string logContent = File.ReadAllText(filePath);

                // Mostrar el contenido del log en el elemento div "logContent"
                logContent = logContent.Replace(Environment.NewLine, "<br/>");
                this.logContent.InnerHtml = logContent;
            }
            else
            {
                this.logContent.InnerHtml = "No se encontró el archivo de registro.";
            }
        }
    }
}
