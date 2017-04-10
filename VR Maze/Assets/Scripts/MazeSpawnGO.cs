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
        

        public MazeSpawnGO(GameObject ObjectToSpawn)
        {
            SpawnObject = ObjectToSpawn;
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
