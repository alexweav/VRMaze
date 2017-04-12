using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class MazeSpawnGOManager
    {
        List<MazeSpawnGO> ListMazeSpawnGO;
        private string MazeName;

        public MazeSpawnGOManager(string mazeName)
        {
            MazeName = mazeName;
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
                Vector3 CellPosition = GameObject.Find(MazeName).transform.FindChild(CellGOtoFind).FindChild("Cell Floor").transform.position;
                GameObject.Find(objectToSpawn.SpawnObject.transform.name).transform.position = new Vector3(CellPosition.x, (CellPosition.y + objectToSpawn.SpawnObject.transform.localScale.y), CellPosition.z);
                
            }
        }


    }
}
