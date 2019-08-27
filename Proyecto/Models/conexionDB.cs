using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Proyecto.Models
{
    public class conexionDB
    {
        public static DataTable usuariosDT;
        SqlConnection conn = new SqlConnection("Server=CR-JLEITON\\SQLEXPRESS;uid=;pwd=;database=INDEPENDENT_EMPLOYEE_DB");

        public conexionDB()
        {

            string rpta = "";
            //string CN = "Server = mcastro/SQLEXPRESS; Database = Fotografia; Trusted_Connection = True";
            string CN = "Server=CR-JLEITON\\SQLEXPRESS;uid=;pwd=;database=INDEPENDENT_EMPLOYEE_DB;";
            SqlConnection sqlcon = new SqlConnection();

            try
            {
                sqlcon.ConnectionString = CN;
                sqlcon.Open();
            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            if (sqlcon.State == ConnectionState.Open)
                MessageBox.Show("ok");
            else
                MessageBox.Show("no se conecto");
        }

    }

    }