using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvreBordroT
{
    public partial class Employees : DevExpress.XtraEditors.XtraForm
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {
            personelCekme();
        }

        void personelCekme()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = "User Id =berkay; Password=1;Server=DBServer; Direct=True;Sid=EVREDB;";
            OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM EvreMessenger t", con);
            OracleDataTable dt = new OracleDataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

    }
}
