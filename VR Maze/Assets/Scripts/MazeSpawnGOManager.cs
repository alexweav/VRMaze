using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class MazeSpawnGOManager
    {
        List<MazeSpawnGO> ListMazeSpawnGO;
        Maze m;
        private GameObject Icon;
        private Vector3 INTiconPOS;
        private Vector3 INTmainplayerPOS;
        private bool FirstTimeMazeUpdate = true;
        private bool FirstTimeHUDUpdate = true;
        private bool CameraMotion;
        private GameObject cameraGO;
        

        public MazeSpawnGOManager(Maze currentMaze)
        {
            m = currentMaze;
            ListMazeSpawnGO = new List<Scripts.MazeSpawnGO>();
            

        }

        public void UpdateMainPlayerIconPOS()
        {
            GameObject.Find("HUDMiniMap").transform.FindChild("Icon").transform.rotation = Quaternion.Euler(0, GameObject.Find("MainPlayer").transform.FindChild("GvrMain").transform.FindChild("Head").rotation.eulerAngles.y + 143.25f, 0);

            Vector3 MPPosition = GameObject.Find("MainPlayer").transform.position;
            Icon.transform.position = INTiconPOS + new Vector3((MPPosition.x - INTmainplayerPOS.x) / 10, 0, (MPPosition.z - INTmainplayerPOS.z) / 10);
           
            //Debug.Log(MPPosition);

            if(CameraMotion)
            {
                cameraGO.transform.position = new Vector3(Icon.transform.position.x, cameraGO.transform.position.y, Icon.transform.position.z);
            }


           
        }

        public void addObjectToSpawn(MazeSpawnGO spawnGO)
        {
              ListMazeSpawnGO.Add(spawnGO);
            
        }

        public void SpawnAllGO()
        {
            if(m.GetType().Name != "HUDMiniMapMaze" && FirstTimeMazeUpdate == true)
            {
                AddMazeGameObjects();
                FirstTimeMazeUpdate = false;

                
                //Debug.Log(m.GetType().Name);
            }    
            
            if(m.GetType().Name == "HUDMiniMapMaze" && FirstTimeHUDUpdate == true)
            {
                
                AddHUDMapIcons();
                FirstTimeHUDUpdate = false;
                //Debug.Log(m.GetType().Name);
            }   

            foreach (MazeSpawnGO objectToSpawn in ListMazeSpawnGO)
            {
                float newYPOS;
                string CellGOtoFind = "Maze Cell (" + objectToSpawn.XCellposition + "," + objectToSpawn.ZCellposition + ")"; 
                Vector3 CellPosition = GameObject.Find(m.MazeGO.name).transform.FindChild(CellGOtoFind).FindChild("Cell Floor").transform.position;
                if (objectToSpawn.SpawnObject.name == "MainPlayer" || objectToSpawn.IsIcon == true)
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

            if (m.GetType().Name == "HUDMiniMapMaze")
            {
                INTiconPOS = Icon.transform.position;
                INTmainplayerPOS = GameObject.Find("MainPlayer").transform.position;
                m.hideAllCellsParts();
            }
        }

        private void DetermineCameraMotion()
        {
            if (m.MazeSize.First > 5 && m.MazeSize.Second > 5)
            {
                CameraMotion = true;
            }
        }

        private void IntializeMiniMapVars()
        {     
            cameraGO = GameObject.Find("HUDMiniMap").transform.FindChild("Minimap Camera").gameObject;
        }

        /**************************************************************************************************************************************************************************************/
        //Methods for Spawning Maze Game Object and HUD Minimap Icons
        /**************************************************************************************************************************************************************************************/
        /**************************************************************************************************************************************************************************************/
        /**************************************************************************************************************************************************************************************/

        private void AddMazeGameObjects()
        {
            AddMainPlayer();
            AddFinishCellMarker();
            AddTeleportors();

        }

        private void AddHUDMapIcons()
        {
            AddPlayerIcon();
            AddTeleportorIcons();
            AddIconsToMazeCellGO();
        }

        /**************************************************************************************************************************************************************************************/
        //Adding Maze Game Objects
        /**************************************************************************************************************************************************************************************/
        /**************************************************************************************************************************************************************************************/
        /**************************************************************************************************************************************************************************************/

        private void AddMainPlayer()
        {
            MazeSpawnGO tempSGO = new MazeSpawnGO(0, 0, GameObject.Find("MainPlayer"));
            addObjectToSpawn(tempSGO);
        }

        private void AddFinishCellMarker()
        {
            GameObject FinishMarkerGO = (GameObject)GameObject.Instantiate(Resources.Load("FinishCellMarker"));
            FinishMarkerGO.name = "Finish Cell Marker"; ;
            MazeSpawnGO tempSGO = new MazeSpawnGO(m.MazeSize.First - 1, m.MazeSize.Second - 1, FinishMarkerGO);
            addObjectToSpawn(tempSGO);
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
                    addObjectToSpawn(new MazeSpawnGO(TeleportorBPos.First, TeleportorBPos.Second, TelB));
                }
                else
                {
                    TeleportorAPos = new Pair<int, int>(0, m.MazeSize.Second - 2);
                    TeleportorBPos = new Pair<int, int>(TeleportorAPos.First - 1, 1);

                    addObjectToSpawn(new MazeSpawnGO(TeleportorAPos.First, TeleportorAPos.Second, TelA));
                    addObjectToSpawn(new MazeSpawnGO(TeleportorBPos.First, TeleportorBPos.Second, TelB));
                }


            }

            
        }

        /**************************************************************************************************************************************************************************************/
        //Adding HUD MiniMap Icons
        /**************************************************************************************************************************************************************************************/
        /**************************************************************************************************************************************************************************************/
        /**************************************************************************************************************************************************************************************/
        private void AddPlayerIcon()
        {
            DetermineCameraMotion();
            Icon = (GameObject)GameObject.Instantiate(Resources.Load("Icon"));
            Icon.name = "Icon";
            Icon.transform.SetParent(m.MazeGO.transform.parent);
            MazeSpawnGO tempSGO = new MazeSpawnGO(0, 0, Icon);
            tempSGO.IsIcon = true;
            addObjectToSpawn(tempSGO);
            IntializeMiniMapVars();


        }

        

        

        

        private void AddTeleportorIcons()
        {
            Pair<int, int> TeleportorAPos, TeleportorBPos;

            if (m.MazeSize.First % 2 == 1 && m.MazeSize.Second % 2 == 1)
            {
                TeleportorAPos = new Pair<int, int>(m.MazeSize.First - (m.MazeSize.First - 1), m.MazeSize.Second - 2);
                TeleportorBPos = new Pair<int, int>(TeleportorAPos.Second, TeleportorAPos.First);  
            }
            else
            {
                TeleportorAPos = new Pair<int, int>(0, m.MazeSize.Second - 2);
                TeleportorBPos = new Pair<int, int>(TeleportorAPos.First - 1, 1);
          
            }

            MazeSpawnGO TelA = new MazeSpawnGO(TeleportorAPos.First, TeleportorAPos.Second, (GameObject)GameObject.Instantiate(Resources.Load("TeleportorIcon")));
            MazeSpawnGO TelB = new MazeSpawnGO(TeleportorBPos.First, TeleportorBPos.Second, (GameObject)GameObject.Instantiate(Resources.Load("TeleportorIcon")));
            TelA.SpawnObject.name = "TeleportorA Icon";
            TelB.SpawnObject.name = "TeleportorB Icon";
            TelA.IsIcon = true;
            TelB.IsIcon = true;

            addObjectToSpawn(TelA);
            addObjectToSpawn(TelB);
        }

        
        private void AddIconsToMazeCellGO()
        {
            foreach (MazeSpawnGO MSGO in ListMazeSpawnGO)
            {
                if(MSGO.SpawnObject.name != "Icon")
                {
                    MSGO.SpawnObject.transform.SetParent((m.CellsInMaze.Find(x => ((x.cellLocationX == MSGO.XCellposition) && (x.cellLocationZ == MSGO.ZCellposition)))).mazeCellGO.transform);
                }
               
            }
        }

    }
}
