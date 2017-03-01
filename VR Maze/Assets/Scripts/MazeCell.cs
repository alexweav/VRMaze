using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// A single cell of a maze
    /// </summary>
    class MazeCell
    {
        private bool startCell;
        private bool finishCell;
        private bool southPath;
        private bool eastPath;
        private int[] cellLocation = new int[2];

        /// <summary>
        /// Constructor 4 arguments
        /// </summary>
        public MazeCell(int x, int z, bool EastPath, bool SouthPath)
        {
            southPath = SouthPath;
            eastPath = EastPath;
            cellLocation[0] = x;
            cellLocation[1] = z;
            startCell = false;
            finishCell = false;
        }

        /// <summary>
        /// Get and set method for cellLocationX
        /// </summary>
        public int cellLocationX
        {
            get
            {
                return cellLocation[0];
            }
            set
            {
                cellLocation[0] = cellLocationX;
            }
        }

        /// <summary>
        /// Get and set method for cellLocationZ
        /// </summary>
        public int cellLocationZ
        {
            get
            {
                return cellLocation[1];
            }
            set
            {
                cellLocation[1] = cellLocationZ;
            }
        }

        /// <summary>
        /// Get and set method for StartCell
        /// </summary>
        public bool StartCell
        {
            get
            {
                return startCell;
            }
            set
            {
                startCell = StartCell;
            }
        }

        public bool FinishCell
        {
            get
            {
                return startCell;
            }
            set
            {
                finishCell = FinishCell;
            }

        }

        /// <summary>
        /// Get and set method for SouthPath
        /// </summary>
        public bool SouthPath
        {
            get
            {
                return southPath;
            }
            set
            {
                southPath = SouthPath;
            }

        }

        /// <summary>
        /// Get and set method for EastPath
        /// </summary>
        public bool EastPath
        {
            get
            {
                return eastPath;
            }
            set
            {
                eastPath = EastPath;
            }

        }
    }
}
