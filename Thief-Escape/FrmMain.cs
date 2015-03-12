using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Theif_Escape
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region [ Button Click Events ]

        //New Game Button
        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        //Load Game Button
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            //to-do
        }

        //Exit Game Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
