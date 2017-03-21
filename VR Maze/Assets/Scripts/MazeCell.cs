using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// A single cell of a maze
    /// </summary>
    public class MazeCell
    {
        public GameObject mazeCellGO;
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

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            MazeCell cell = other as MazeCell;
            if (cell == null)
            {
                return false;
            }
            return (this.startCell == cell.StartCell) && (this.finishCell == cell.finishCell)
                && (this.southPath == cell.southPath) && (this.eastPath == cell.eastPath)
                && (this.cellLocationX == cell.cellLocationX) && (this.cellLocationZ == cell.cellLocationZ);
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
