using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Theif_Escape
{
    class Grid
    {
        #region [ Enums ]

        //Direction Enum for simple switching
        public enum Direction
        {
            NORTH,
            SOUTH,
            EAST,
            WEST
        }


        //Map list Enum for grid creation
        public enum MapFiles
        {
            Test
        }


        #endregion


        #region [ Fields ]

        // The Grid, Declared
        private Cell[,] _map;

        //The Grid's size
        private int _mapSize;

        // The Grid's starting cell
        private int _startingX;
        private int _startingY;


        #endregion


        #region [ Properties ]


        public int[] StartingCell
        {
            get
            {
                int[] coords = { _startingX, _startingY };
                return coords;
            }
        }

        public int MapSize
        {
            get { return _mapSize; }
        }


        #endregion


        #region [ Constructors ]


        public Grid(MapFiles file)
        {
            //Switch Statement to determine MapSize
            switch (file)
            {
                case MapFiles.Test:
                    _mapSize = 16;
                    break;

                default:
                    _mapSize = 24; //   24 is the size of the Grid control on the form.
                    break;
            }

            //Instantiate the Grid
            _map = new Cell[MapSize, MapSize];

            //For loop to instantiate the array with cells
            for (int x = 0; x < _mapSize; x++)
            {
                for (int y = 0; y < _mapSize; y++)
                {
                    _map[x, y] = new Cell();
                }
            }

            //Now what I'd like to do is load from a file here, but because I haven't found a working solution for that, its being created in code here.
            if (file == MapFiles.Test)
            {
                #region [ Test Map Creation ]
                //Starting Cell
                _startingX = 1;
                _startingY = 1;
                #region Walls
                //create top row of walls
                for (int i = 0; i < 16; i++)
                {
                    _map[0, i].Archetype = Cell.Archetypes.WALL;
                }

                //create bottom row of walls
                for (int i = 0; i < 16; i++)
                {
                    _map[15, i].Archetype = Cell.Archetypes.WALL;
                }

                //create left column of walls
                for (int i = 0; i < 15; i++)
                {
                    _map[i, 0].Archetype = Cell.Archetypes.WALL;
                }

                //create right column of walls
                for (int i = 0; i < 15; i++)
                {
                    _map[i, 15].Archetype = Cell.Archetypes.WALL;
                }
                //create all other walls
                _map[1, 5].Archetype = Cell.Archetypes.WALL;
                _map[1, 12].Archetype = Cell.Archetypes.WALL;

                _map[2, 3].Archetype = Cell.Archetypes.WALL;
                _map[2, 5].Archetype = Cell.Archetypes.WALL;
                _map[2, 8].Archetype = Cell.Archetypes.WALL;
                _map[2, 12].Archetype = Cell.Archetypes.WALL;

                _map[3, 1].Archetype = Cell.Archetypes.WALL;
                _map[3, 2].Archetype = Cell.Archetypes.WALL;
                _map[3, 3].Archetype = Cell.Archetypes.WALL;
                _map[3, 5].Archetype = Cell.Archetypes.WALL;
                _map[3, 7].Archetype = Cell.Archetypes.WALL;
                _map[3, 8].Archetype = Cell.Archetypes.WALL;
                _map[3, 9].Archetype = Cell.Archetypes.WALL;
                _map[3, 11].Archetype = Cell.Archetypes.WALL;
                _map[3, 12].Archetype = Cell.Archetypes.WALL;

                _map[4, 3].Archetype = Cell.Archetypes.WALL;
                _map[4, 5].Archetype = Cell.Archetypes.WALL;
                _map[4, 7].Archetype = Cell.Archetypes.WALL;
                _map[4, 11].Archetype = Cell.Archetypes.WALL;
                _map[4, 12].Archetype = Cell.Archetypes.WALL;
                _map[4, 13].Archetype = Cell.Archetypes.WALL;

                _map[5, 3].Archetype = Cell.Archetypes.WALL;
                _map[5, 5].Archetype = Cell.Archetypes.WALL;
                _map[5, 6].Archetype = Cell.Archetypes.WALL;
                _map[5, 7].Archetype = Cell.Archetypes.WALL;

                _map[6, 11].Archetype = Cell.Archetypes.WALL;
                _map[6, 12].Archetype = Cell.Archetypes.WALL;

                _map[7, 1].Archetype = Cell.Archetypes.WALL;
                _map[7, 2].Archetype = Cell.Archetypes.WALL;
                _map[7, 3].Archetype = Cell.Archetypes.WALL;
                _map[7, 4].Archetype = Cell.Archetypes.WALL;
                _map[7, 5].Archetype = Cell.Archetypes.WALL;
                _map[7, 6].Archetype = Cell.Archetypes.WALL;
                _map[7, 7].Archetype = Cell.Archetypes.WALL;
                _map[7, 8].Archetype = Cell.Archetypes.WALL;
                _map[7, 9].Archetype = Cell.Archetypes.WALL;
                _map[7, 10].Archetype = Cell.Archetypes.WALL;
                _map[7, 11].Archetype = Cell.Archetypes.WALL;
                _map[7, 12].Archetype = Cell.Archetypes.WALL;

                _map[8, 1].Archetype = Cell.Archetypes.WALL;
                _map[8, 2].Archetype = Cell.Archetypes.WALL;
                _map[8, 3].Archetype = Cell.Archetypes.WALL;
                _map[8, 4].Archetype = Cell.Archetypes.WALL;
                _map[8, 5].Archetype = Cell.Archetypes.WALL;
                _map[8, 6].Archetype = Cell.Archetypes.WALL;
                _map[8, 11].Archetype = Cell.Archetypes.WALL;
                _map[8, 12].Archetype = Cell.Archetypes.WALL;

                _map[9, 6].Archetype = Cell.Archetypes.WALL;
                _map[9, 9].Archetype = Cell.Archetypes.WALL;
                _map[9, 11].Archetype = Cell.Archetypes.WALL;
                _map[9, 12].Archetype = Cell.Archetypes.WALL;

                _map[10, 2].Archetype = Cell.Archetypes.WALL;
                _map[10, 3].Archetype = Cell.Archetypes.WALL;
                _map[10, 4].Archetype = Cell.Archetypes.WALL;
                _map[10, 5].Archetype = Cell.Archetypes.WALL;
                _map[10, 6].Archetype = Cell.Archetypes.WALL;
                _map[10, 7].Archetype = Cell.Archetypes.WALL;
                _map[10, 8].Archetype = Cell.Archetypes.WALL;
                _map[10, 9].Archetype = Cell.Archetypes.WALL;

                _map[11, 9].Archetype = Cell.Archetypes.WALL;
                _map[11, 11].Archetype = Cell.Archetypes.WALL;
                _map[11, 12].Archetype = Cell.Archetypes.WALL;
                _map[11, 13].Archetype = Cell.Archetypes.WALL;

                _map[12, 1].Archetype = Cell.Archetypes.WALL;
                _map[12, 2].Archetype = Cell.Archetypes.WALL;
                _map[12, 3].Archetype = Cell.Archetypes.WALL;
                _map[12, 5].Archetype = Cell.Archetypes.WALL;
                _map[12, 6].Archetype = Cell.Archetypes.WALL;
                _map[12, 9].Archetype = Cell.Archetypes.WALL;
                _map[12, 11].Archetype = Cell.Archetypes.WALL;
                _map[12, 12].Archetype = Cell.Archetypes.WALL;

                _map[13, 6].Archetype = Cell.Archetypes.WALL;
                _map[13, 9].Archetype = Cell.Archetypes.WALL;
                _map[13, 12].Archetype = Cell.Archetypes.WALL;

                _map[14, 6].Archetype = Cell.Archetypes.WALL;
                _map[14, 12].Archetype = Cell.Archetypes.WALL;
                #endregion
                #region Floors
                _map[1, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[1, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[1, 6].Archetype = Cell.Archetypes.FLOOR;
                _map[1, 7].Archetype = Cell.Archetypes.FLOOR;
                _map[1, 9].Archetype = Cell.Archetypes.FLOOR;
                _map[1, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[1, 11].Archetype = Cell.Archetypes.FLOOR;

                _map[2, 1].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 6].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 7].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 9].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 11].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[2, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[3, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[3, 6].Archetype = Cell.Archetypes.FLOOR;
                _map[3, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[3, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[4, 1].Archetype = Cell.Archetypes.FLOOR;
                _map[4, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[4, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[4, 6].Archetype = Cell.Archetypes.FLOOR;
                _map[4, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[4, 9].Archetype = Cell.Archetypes.FLOOR;
                _map[4, 10].Archetype = Cell.Archetypes.FLOOR;

                _map[5, 1].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 9].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 11].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 12].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[5, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[6, 1].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 5].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 6].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 7].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 9].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[6, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[7, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[7, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[8, 7].Archetype = Cell.Archetypes.FLOOR;
                _map[8, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[8, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[8, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[8, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[9, 1].Archetype = Cell.Archetypes.FLOOR;
                _map[9, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[9, 3].Archetype = Cell.Archetypes.FLOOR;
                _map[9, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[9, 5].Archetype = Cell.Archetypes.FLOOR;
                _map[9, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[9, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[9, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[9, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[10, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[10, 11].Archetype = Cell.Archetypes.FLOOR;
                _map[10, 12].Archetype = Cell.Archetypes.FLOOR;
                _map[10, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[10, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[11, 1].Archetype = Cell.Archetypes.FLOOR;
                _map[11, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[11, 3].Archetype = Cell.Archetypes.FLOOR;
                _map[11, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[11, 5].Archetype = Cell.Archetypes.FLOOR;
                _map[11, 6].Archetype = Cell.Archetypes.FLOOR;
                _map[11, 7].Archetype = Cell.Archetypes.FLOOR;
                _map[11, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[11, 10].Archetype = Cell.Archetypes.FLOOR;

                _map[12, 7].Archetype = Cell.Archetypes.FLOOR;
                _map[12, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[12, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[12, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[12, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[13, 1].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 3].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 5].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 7].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 11].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 13].Archetype = Cell.Archetypes.FLOOR;
                _map[13, 14].Archetype = Cell.Archetypes.FLOOR;

                _map[14, 1].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 2].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 3].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 4].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 5].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 7].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 8].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 10].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 11].Archetype = Cell.Archetypes.FLOOR;
                _map[14, 14].Archetype = Cell.Archetypes.FLOOR;
                #endregion
                #region Doors
                //Unlocked doors
                _map[1, 3].Archetype = Cell.Archetypes.DOOR;
                _map[10, 1].Archetype = Cell.Archetypes.DOOR;
                _map[8, 9].Archetype = Cell.Archetypes.DOOR;
                _map[14, 9].Archetype = Cell.Archetypes.DOOR;
                _map[3, 10].Archetype = Cell.Archetypes.DOOR;

                //Locked doors
                _map[6, 3].Archetype = Cell.Archetypes.DOOR;
                _map[6, 3].Modifier = Cell.Modifiers.LOCKED;
                _map[12, 4].Archetype = Cell.Archetypes.DOOR;
                _map[12, 4].Modifier = Cell.Modifiers.LOCKED;
                _map[1, 8].Archetype = Cell.Archetypes.DOOR;
                _map[1, 8].Modifier = Cell.Modifiers.LOCKED;
                _map[4, 14].Archetype = Cell.Archetypes.DOOR;
                _map[4, 14].Modifier = Cell.Modifiers.LOCKED;
                _map[11, 14].Archetype = Cell.Archetypes.DOOR;
                _map[11, 14].Modifier = Cell.Modifiers.LOCKED;
                #endregion
                #region Stairs
                _map[1, 13].Archetype = Cell.Archetypes.STAIR;
                _map[14,13].Archetype = Cell.Archetypes.STAIR;
                #endregion
                #region Items
                _map[9, 7].Content = Cell.Contents.KEY;
                #endregion
                #endregion
            }
        }


        #endregion


        #region [ Methods ]
        

        //  Returns the Archetype of a cell
        public Cell.Archetypes CheckType(int x, int y)
        {
            Cell.Archetypes result = _map[x, y].Archetype;
            return result;
        }


        //  Checks for Items in a given cell
        public Cell.Contents CheckForItem(int x, int y)
        {
            Cell.Contents result = _map[x, y].Content;
            return result;
        }


        //  Removes Item's in a given cell, and passes back the item in the cell.
        public Cell.Contents RemoveItem(int x, int y)
        {
            Cell.Contents result = _map[x, y].Content;
            _map[x, y].Content = Cell.Contents.NULL;
            return result;
        }


        //  Checks if a door is unlocked
        public Cell.Modifiers CheckDoorModifier(int x, int y)
        {
            Cell.Modifiers result = _map[x, y].Modifier;
            return result;
        }


        //  Toggles Lock status on a door, and passes back new status
        public Cell.Modifiers ToggleDoorModifier(int x, int y)
        {
            if (_map[x, y].Modifier == Cell.Modifiers.LOCKED)
                _map[x, y].Modifier = Cell.Modifiers.UNLOCKED;
            if (_map[x, y].Modifier == Cell.Modifiers.UNLOCKED)
                _map[x, y].Modifier = Cell.Modifiers.LOCKED;
            Cell.Modifiers result = _map[x, y].Modifier;
            return result;
        }


        #endregion
    }
}
