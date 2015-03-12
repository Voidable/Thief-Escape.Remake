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


        //  Load Button
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            //to-do
            //Planned feature: Load a game from a save file
        }


        //  Save Button
        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            //to-do
            //Planned feature: Save a gamestate to file
        }

        
        //  Menu Button
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            //Change the exit bool to false;
            exit = false;
            //Load the menu form
            FrmMain frm = new FrmMain();
            frm.Show();

            //Close this form
            this.Close();
        }


        #endregion


        #region [ Movement ]

        #region [ Movement Button Clicks ]

        //  North Button
        private void btnMoveNorth_Click(object sender, EventArgs e)
        {
            //  Move the player North ( y - 1 )

            //  Re-evaluate Valid Movements

            //  Remove Map color from previous cell

            //  Change Map color of current cell

            //  Remake fog of war

        }

        //  East Button
        private void btnMoveEast_Click(object sender, EventArgs e)
        {
            //  Move the player East ( x + 1 )

            //  Re-evaluate Valid Movements

            //  Remove Map color from previous cell

            //  Change Map color of current cell

            //  Remake fog of war

        }

        // South Button
        private void btnMoveSouth_Click(object sender, EventArgs e)
        {
            //  Move the player South ( y + 1 )

            //  Re-evaluate Valid Movements

            //  Remove Map color from previous cell

            //  Change Map color of current cell

            //  Remake fog of war

        }

        //  West Button
        private void btnMoveWest_Click(object sender, EventArgs e)
        {
            //  Move the player West ( x - 1 )

            //  Re-evaluate Valid Movements

            //  Remove Map color from previous cell

            //  Change Map color of current cell

            //  Remake fog of war

        }


        #endregion

        #region [ Movement Methods ]

        public void CheckValidMovements(int x, int y)
        {

        }



        #endregion

#endregion


        #region [ Actions ]

        #region [ Action Button Clicks ]


        // Pick-up Key Button
        private void btnPickupKey_Click(object sender, EventArgs e)
        {

        }



        // Use Key Button
        private void btnUseKey_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region [ Action Methods ]
        




        #endregion

        #endregion


    }
}
