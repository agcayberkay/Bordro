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

    public partial class PuantajB : DevExpress.XtraEditors.XtraForm
    {
        public static OracleConnection con = new OracleConnection("User Id =berkay; Password=1;Server=DBServer; Direct=True;Sid=EVREDB;");
      
        public PuantajB()
        {
            InitializeComponent();
        }

        private void PuantajB_Load(object sender, EventArgs e)
        {
           
        }

        void tabloCekme()
        {
            OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM PuantajTable t", con);
            OracleDataTable dt = new OracleDataTable();
            da.Fill(dt);
           
        }
    }
}
