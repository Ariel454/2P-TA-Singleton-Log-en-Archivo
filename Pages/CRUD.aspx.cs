﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System;
using System.IO;
using System.Web;


namespace CRUD.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
       
        
       public static string sID = "-1";
       public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el id
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                    //tbestado.TextMode = TextBoxMode;
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo usuario";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de usuario";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar usuario";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar usuario";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CodigoPeriodoLectivo", SqlDbType.Int).Value = sID;
            da.SelectCommand.Parameters.Add("@DescripcionPeriodoLectivo", SqlDbType.VarChar).Value = ""; // Agrega este parámetro con un valor vacío
            da.SelectCommand.Parameters.Add("@AAia", SqlDbType.VarChar).Value = ""; // Agrega este parámetro con un valor vacío
            da.SelectCommand.Parameters.Add("@Estado", SqlDbType.VarChar).Value = ""; // Agrega este parámetro con un valor vacío
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                tbCodigoPeriodoLectivo.Text = row[1].ToString();
                tbDescripcionPeriodoLectivo.Text = row[2].ToString();
                tbsucursal.Text = row[3].ToString();
                tbestado.Text = row[4].ToString();
            }

            con.Close();
        }


        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodigoPeriodoLectivo", SqlDbType.VarChar).Value = tbCodigoPeriodoLectivo.Text; 
            cmd.Parameters.Add("@DescripcionPeriodoLectivo", SqlDbType.Int).Value = tbDescripcionPeriodoLectivo.Text; 
            cmd.Parameters.Add("@AAia", SqlDbType.VarChar).Value = tbsucursal.Text; 
            cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = tbestado.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            string logEntry = $"{DateTime.Now.ToString()} - IP: {Request.UserHostAddress} - Acción: Crear";
            File.AppendAllText(Server.MapPath("~/Pages/Logs/ActivityLog.txt"), logEntry + Environment.NewLine);
            Response.Redirect("Index.aspx");


        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodigoPeriodoLectivo", SqlDbType.Int).Value = tbCodigoPeriodoLectivo.Text;
            cmd.Parameters.Add("@DescripcionPeriodoLectivo", SqlDbType.VarChar).Value = tbCodigoPeriodoLectivo.Text;
            cmd.Parameters.Add("@AAia", SqlDbType.Int).Value = tbDescripcionPeriodoLectivo.Text;
            cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = tbestado.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            string logEntry = $"{DateTime.Now.ToString()} - IP: {Request.UserHostAddress} - Acción: Actualizar";
            File.AppendAllText(Server.MapPath("~/Pages/Logs/ActivityLog.txt"), logEntry + Environment.NewLine);
            Response.Redirect("Index.aspx");


        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodigoPeriodoLectivo", SqlDbType.Int).Value = tbCodigoPeriodoLectivo.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            string logEntry = $"{DateTime.Now.ToString()} - IP: {Request.UserHostAddress} - Acción: Eliminar";
            File.AppendAllText(Server.MapPath("~/Pages/Logs/ActivityLog.txt"), logEntry + Environment.NewLine);
            Response.Redirect("Index.aspx");


        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        void RegistrarActividadEnArchivo(string accion)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Pages/Logs/ActivityLog.txt"); // Ruta del archivo de registro

            string fecha = DateTime.Now.ToString();
            string ip = HttpContext.Current.Request.UserHostAddress;

            string registro = $"{fecha} - IP: {ip} - Acción: {accion}";

            // Escribir el registro en el archivo
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(registro);
            }
        }


    }
}