using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace CRUD.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvusuarios.DataSource = dt;
            gvusuarios.DataBind();
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string logEntry = $"{DateTime.Now} - IP: {Request.UserHostAddress} - Acción: Creación de registro";
            LogActivity(logEntry);
            Response.Redirect("~/Pages/CRUD.aspx?op=C");

        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            string logEntry = $"{DateTime.Now} - IP: {Request.UserHostAddress} - Acción: Actualización de registro";
            LogActivity(logEntry);
            Response.Redirect("~/Pages/CRUD.aspx?id="+id+"&op=R");

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            string logEntry = $"{DateTime.Now} - IP: {Request.UserHostAddress} - Acción: Actualización de registro";
            LogActivity(logEntry);
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U");

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            string logEntry = $"{DateTime.Now} - IP: {Request.UserHostAddress} - Acción: Actualización de registro";
            LogActivity(logEntry);
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=D");

        }

        protected void BtnVerLog_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de Log Viewer
            Response.Redirect("~/Pages/LogViewer.aspx");
        }

        private void LogActivity(string logEntry)
        {
            string logFilePath = Server.MapPath("~/Pages/Logs/ActivityLog.txt");

            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            Console.WriteLine("Entrada guardada en el archivo correctamente.");
        }
    }
}