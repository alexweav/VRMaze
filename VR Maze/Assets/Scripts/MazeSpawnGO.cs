using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class MazeSpawnGO
    {
        public GameObject SpawnObject;
        private int xCellposition;
        private int zCellposition;
        private bool isIcon;
        private bool isMazeGO;
        

        public MazeSpawnGO(int x, int z, GameObject ObjectToSpawn)
        {
            SpawnObject = ObjectToSpawn;
            xCellposition = x;
            zCellposition = z;
            IsIcon = false;
            IsMazeGO = false;
        }

        public int XCellposition
        {
            get
            {
                return xCellposition;
            }

            set
            {
                xCellposition = value;
            }
        }

        public int ZCellposition
        {
            get
            {
                return zCellposition;
            }

            set
            {
                zCellposition = value;
            }
        }

        public bool IsIcon
        {
            get
            {
                return isIcon;
            }

            set
            {
                isIcon = value;
            }
        }

        public bool IsMazeGO
        {
            get
            {
                return isMazeGO;
            }

            set
            {
                isMazeGO = value;
            }
        }
    }
}
