﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theif_Escape
{
    class Player
    {
        #region [ Fields ]


        //Player's name
        string _name;

        //Player's coords
        int _x;
        int _y;


        #endregion

        #region [ Properties ]


        //Gets or sets the player's name.
        public string Name 
        {
            get { return _name; }
            
            set { _name = value.Trim(); }
        }


        //Gets or sets the player's X coordinate
        public int XCoord 
        {
            get { return _x; }

            set
            {
                //Restrict coord values to >= 0
                if (value >= 0)
                    _x = value;
            }
        }


        //Gets or sets the player's Y coordinate
        public int YCoord
        {
            get { return _y; }

            set
            {
                //Restrict coord values to >= 0
                if (value >= 0)
                    _y = value;
            }
        }


        //Gets an Array containing the X,Y coordinate pair
        public int[] Coordinates 
        { 
            get
            {
                int[] coords = {_x,_y};
                return coords;
            }
        }


        #endregion
    }
}