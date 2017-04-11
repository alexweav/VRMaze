using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class MazeSpawnGOManager
    {
        List<MazeSpawnGO> ListMazeSpawnGO;

        public MazeSpawnGOManager()
        {
            ListMazeSpawnGO = new List<Scripts.MazeSpawnGO>();
        }

        public void addObjectToSpawn(MazeSpawnGO spawnGO)
        {
              ListMazeSpawnGO.Add(spawnGO);
        }

        public void SpawnAllGO()
        {
            foreach (MazeSpawnGO objectToSpawn in ListMazeSpawnGO)
            {
                string CellGOtoFind = "Maze Cell (" + objectToSpawn.XCellposition.ToString() + "," + objectToSpawn.ZCellposition.ToString() + ")";
                Vector3 CellPosition = GameObject.Find(CellGOtoFind).transform.GetChild(0).transform.position;
                GameObject.Find(objectToSpawn.SpawnObject.transform.name).transform.position = new Vector3(CellPosition.x, (CellPosition.y + 1f), CellPosition.z);
            }
        }


    }
}
