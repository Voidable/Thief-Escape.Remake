using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Theif_Escape
{
    public partial class FrmGame : Form
    {
        #region [ Globals ]


        Player player;
        List<Item> Inventory;
        string name;

        //Exit bool is used to prevent unwanted shutdowns 
        //  when going to the main menu.
        bool exit = true;


        #endregion


        #region [ Constructors ]


        //Default constructor
        public FrmGame()
        {
            // TODO: Complete member initialization
            InitializeComponent();

            //Defaut constructor creates name of "User"
            name = "User";
        }



        // Overloaded FormGame constructor to pass in name from name form
        public FrmGame(string playername)
        {
            InitializeComponent();

            //Change the player name
            name = playername;
        }


        #endregion


        #region [ Form Events ]


        //  Form Closed
        private void FrmGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (exit)
                Application.Exit();

        }


        //  Form Loaded
        private void FrmGame_Load(object sender, EventArgs e)
        {
            //  Create the Player

            //  Create the Inventory

            //  Create the Grid

            //  Create the Map

            //  Place the player

            //  Clear the fog

            //  Check Valid Movements

            //  Initial Prompt

        }


        #endregion


        #region [ Menu Button Clicks ]


        private void btnLoadGame_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {

        }


        #endregion


    }
}
