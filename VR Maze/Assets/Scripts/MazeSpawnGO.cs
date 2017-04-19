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
        

        public MazeSpawnGO(int x, int z, GameObject ObjectToSpawn)
        {
            SpawnObject = ObjectToSpawn;
            xCellposition = x;
            zCellposition = z;
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
    }
}
