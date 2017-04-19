using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class MazeSpawnGOManager
    {
        List<MazeSpawnGO> ListMazeSpawnGO;
        Maze m;
        public MazeSpawnGOManager(Maze currentMaze)
        {
            m = currentMaze;
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

                string CellGOtoFind = "Maze Cell (" + objectToSpawn.XCellposition + "," + objectToSpawn.ZCellposition + ")"; 
                Vector3 CellPosition = GameObject.Find(m.MazeGO.name).transform.FindChild(CellGOtoFind).FindChild("Cell Floor").transform.position;
                objectToSpawn.SpawnObject.transform.position = new Vector3(CellPosition.x, (CellPosition.y + objectToSpawn.SpawnObject.transform.localScale.y), CellPosition.z);
                Debug.Log(objectToSpawn.SpawnObject.name + " " + new Vector3(CellPosition.x, (CellPosition.y + objectToSpawn.SpawnObject.transform.localScale.y), CellPosition.z));
                Debug.Log(CellGOtoFind);
            }
        }


    }
}
