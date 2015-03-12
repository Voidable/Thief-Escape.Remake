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
        Grid cellGrid;
        string name;

        //Exit bool is used to prevent unwanted shutdowns 
        //  when going to the main menu.
        bool exit = true;


        #endregion


        #region [ Constructors ]


        //Default constructor
        public FrmGame()
        {
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
            player = new Player(name);

            //  Create the Inventory
            Inventory = new List<Item>();

            //  Create the Grid
            cellGrid = new Grid(Grid.MapFiles.Test);

            //  Create the Map
            CreateMap();

            //  Place the player
            player.SetLocation(cellGrid.StartingCell);
            //  Clear the fog

            //  Check Valid Movements

            //  Initial Prompt
            InitalPrompt();

        }

        //starting dialog
        public void InitalPrompt()
        {
            lstDialog.Items.Add(string.Format("Hello {0}, welcome to the game", name));
            lstDialog.Items.Add("Help Robbie get out of the house with all his treasures!");
            lstDialog.Items.Add("");
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
            //to-do
        }



        #endregion

        #endregion


        #region [ Actions ]

        #region [ Action Button Clicks ]


        // Pick-up Key Button
        private void btnPickupKey_Click(object sender, EventArgs e)
        {
            int[] keyDetails = CheckForNearbyKey();
            if (keyDetails[0] != 0)
            {
                //  Remove key from grid.
                cellGrid.RemoveItem(keyDetails[1], keyDetails[2]);
                //  Add a key to the inventory
                Item key = new Item(Item.ItemType.KEY);
                Inventory.Add(key);
                UpdateInventory();
            }
            else
            {
                lstDialog.Items.Add("There is no key nearby!");
                lstDialog.SelectedIndex = lstDialog.Items.Count - 1;
                lstDialog.SelectedIndex = -1;
            }
        }



        // Use Key Button
        private void btnUseKey_Click(object sender, EventArgs e)
        {
            //to-do
        }

        #endregion

        #region [ Action Methods ]

        private int[] CheckForNearbyKey()
        {
            //The array defined as (bool,x-coord,y-coord). Bool is 0-false 1-true, with default of false.
            int[] result = { 0, 0, 0 };

            //Creates starting point for search, 1 cell up and 1 cell left.
            int x = player.XCoord - 1;
            int y = player.YCoord - 1;

            //Goes through each "column" of the search area
            for (int ix = 0; ix < 3; ix++)
            {
                //Goes through each "row" of the column
                for (int iy = 0; iy < 3; iy++)
                {
                    //If the cell has a key, return true.
                    if (cellGrid.CheckForItem((x + ix), (y + iy)) == Cell.Contents.KEY)
                    {
                        //Bool true
                        result[0] = 1;
                        //Key's x-coord
                        result[1] = (x + ix);
                        //Key's y-coord
                        result[2] = (y + iy);
                    }
                }
            }

            return result;

        }

        private void UpdateInventory()
        {
            //to-do
        }



        #endregion

        #endregion


        #region [ Image Map ]

        public void CreateMap()
        {
            //  Define the colors for the cells
            Color wallColor = Color.DimGray;
            Color floorColor = Color.White;
            Color doorUnlockedColor = Color.SaddleBrown;
            Color doorLockedColor = Color.Chocolate;
            Color stairColor = Color.Cyan;
            Color kittenColor = Color.Purple;
            Color keyColor = Color.SpringGreen;


            //Get the max range of the cellGrid
            int maxRange = cellGrid.MapSize + 1;


            //For loop to process each cell in the cellGrid and set the color appropriately.
            for (int x = 1; x < maxRange; x++)
            {
                for (int y = 1; y < maxRange; y++)
                {
                    //  Get the Archetype
                    Cell.Archetypes type = cellGrid.CheckType(x - 1, y - 1);

                    //  Get the Modifier
                    Cell.Modifiers mod = cellGrid.CheckDoorModifier(x - 1, y - 1);

                    //  Get the Contents
                    Cell.Contents cont = cellGrid.CheckForItem(x - 1, y - 1);

                    //  Switch on the Archetype
                    switch (type)
                    {
                        case Cell.Archetypes.WALL:
                            //  Switch on Contents
                            switch (cont)
                            {
                                case Cell.Contents.NULL:
                                    //  Empty Walls are black
                                    grdconMap[y, x].BackColor = wallColor;
                                    break;
                                case Cell.Contents.KEY:
                                    //  Keys are springGreen
                                    grdconMap[y, x].BackColor = keyColor;
                                    break;
                                case Cell.Contents.KITTEN:
                                    // Kittens are purple
                                    grdconMap[y, x].BackColor = kittenColor;
                                    break;
                            }
                            break;

                        case Cell.Archetypes.FLOOR:
                            //  Switch on Contents
                            switch (cont)
                            {
                                case Cell.Contents.NULL:
                                    //  Empty Walls are black
                                    grdconMap[y, x].BackColor = floorColor;
                                    break;
                                case Cell.Contents.KEY:
                                    //  Keys are springGreen
                                    grdconMap[y, x].BackColor = keyColor;
                                    break;
                                case Cell.Contents.KITTEN:
                                    // Kittens are purple
                                    grdconMap[y, x].BackColor = kittenColor;
                                    break;
                            }
                            break;

                        case Cell.Archetypes.DOOR:
                            //  Switch on Modifier
                            switch (mod)
                            {
                                case Cell.Modifiers.LOCKED:
                                    //  Locked doors are dark brown
                                    grdconMap[y, x].BackColor = doorLockedColor;
                                    break;
                                case Cell.Modifiers.UNLOCKED:
                                    //  Unlocked doors are light brown
                                    grdconMap[y, x].BackColor = doorUnlockedColor;
                                    break;
                            }
                            break;

                        case Cell.Archetypes.STAIR:
                            //  Stairs are cyan
                            grdconMap[y, x].BackColor = stairColor;
                            break;

                    }
                }
            }

        }



        #endregion


    }
}
