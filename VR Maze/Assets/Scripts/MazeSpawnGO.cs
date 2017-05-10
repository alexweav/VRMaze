using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class MazeSpawnGO
    {
        public GameObject SpawnObject;
        private float yOffsett;
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
            yOffsett = 0;
        }

        public MazeSpawnGO(int x, int z, float Y_offset, GameObject ObjectToSpawn)
        {
            SpawnObject = ObjectToSpawn;
            xCellposition = x;
            zCellposition = z;
            IsIcon = false;
            IsMazeGO = false;
            yOffsett = Y_offset;
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

        public float YOffsett
        {
            get
            {
                return yOffsett;
            }

            set
            {
                yOffsett = value;
            }
        }
    }
}
