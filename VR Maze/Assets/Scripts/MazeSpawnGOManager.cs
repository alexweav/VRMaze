using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class MazeSpawnGOManager
    {
        List<MazeSpawnGO> ListMazeSpawnGO;
        Maze m;
        private bool FirstTimeUpdate = true;
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
            if(m.GetType().Name != "HUDMiniMapMaze" && FirstTimeUpdate == true)
            {
                AddTeleportors();
                FirstTimeUpdate = false;
                Debug.Log(m.GetType().Name);
            }         
            foreach (MazeSpawnGO objectToSpawn in ListMazeSpawnGO)
            {
                float newYPOS;
                string CellGOtoFind = "Maze Cell (" + objectToSpawn.XCellposition + "," + objectToSpawn.ZCellposition + ")"; 
                Vector3 CellPosition = GameObject.Find(m.MazeGO.name).transform.FindChild(CellGOtoFind).FindChild("Cell Floor").transform.position;
                if (objectToSpawn.SpawnObject.name == "MainPlayer" || objectToSpawn.SpawnObject.name == "Icon")
                {
                    newYPOS = (CellPosition.y + objectToSpawn.SpawnObject.transform.localScale.y);
                }
                else
                {
                    newYPOS = 0;
                }
                objectToSpawn.SpawnObject.transform.position = new Vector3(CellPosition.x, newYPOS, CellPosition.z);
                //Debug.Log(objectToSpawn.SpawnObject.name + " " + new Vector3(CellPosition.x, (CellPosition.y + objectToSpawn.SpawnObject.transform.localScale.y), CellPosition.z));
                //Debug.Log(CellGOtoFind);
            }

            
        }

        private void AddTeleportors()
        {

            Pair<int, int> TeleportorAPos, TeleportorBPos;
            
            if (m.MazeSize.First > 3 && m.MazeSize.Second > 3)
            {
                GameObject TelA = (GameObject)GameObject.Instantiate(Resources.Load("Teleportor"));
                TelA.name = "TeleportorA";

                GameObject TelB = (GameObject)GameObject.Instantiate(Resources.Load("Teleportor"));
                TelB.name = "TeleportorB";

                if (m.MazeSize.First % 2 == 1 && m.MazeSize.Second % 2 == 1)
                {
                    TeleportorAPos = new Pair<int, int>(m.MazeSize.First - (m.MazeSize.First - 1), m.MazeSize.Second - 2);
                    TeleportorBPos = new Pair<int, int>(TeleportorAPos.Second, TeleportorAPos.First);



                    addObjectToSpawn(new MazeSpawnGO(TeleportorAPos.First, TeleportorAPos.Second, TelA));
                    addObjectToSpawn(new MazeSpawnGO(TeleportorBPos.First, TeleportorBPos.Second,TelB));
                }
                else
                {
                    TeleportorAPos = new Pair<int, int>(0, m.MazeSize.Second - 2);
                    TeleportorBPos = new Pair<int, int>(TeleportorAPos.First - 1 , 1);

                    addObjectToSpawn(new MazeSpawnGO(TeleportorAPos.First, TeleportorAPos.Second, TelA));
                    addObjectToSpawn(new MazeSpawnGO(TeleportorBPos.First, TeleportorBPos.Second, TelB));
                }
                

            }
        }


    }
}
