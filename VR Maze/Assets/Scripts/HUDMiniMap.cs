using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    


    public class HUDMiniMap  
    {
        private int count = 0;
        private Maze HMMM;
        GameObject HUDMiniMapGO, MainPlayerGO, cameraGO;
        GameObject Icon;
        //GameObject collidingGO;
        Vector3 INTiconPOS;
        Vector3 INTmainplayerPOS;
        GameObject winMen;
        bool cameraNeedsToMove;

        public HUDMiniMap(Maze MiniMapMaze)
        {
            GameObject.Find("MainPlayer").AddComponent<MainPlayerColliderInfo>();
            winMen = GameObject.Find("MainPlayer").transform.FindChild("GvrMain").transform.FindChild("WinMenu").gameObject;
            IntializeHUDMiniMap(MiniMapMaze);
            MainPlayerGO = GameObject.Find("MainPlayer");
            hideAllCellsParts();
        }

        // Use this for initialization
       
        // Update is called once per frame
        public void UpdateIconPOS()
        {
           Vector3 MPPosition = GameObject.Find("MainPlayer").transform.position;
            Icon.transform.position = INTiconPOS + new Vector3((MPPosition.x - INTmainplayerPOS.x)/10, 0, (MPPosition.z - INTmainplayerPOS.z)/10) ;
            MainPlayerCollision();      
        }

        private void IntializeHUDMiniMap(Maze MiniMapMaze)
        {

            count++;
            HUDMiniMapGO = (GameObject)GameObject.Instantiate(Resources.Load("HUDMiniMap"));
            HUDMiniMapGO.name = "HUDMiniMap";

            cameraGO = GameObject.Find("HUDMiniMap").transform.FindChild("Minimap Camera").gameObject;

            HMMM = MiniMapMaze;
            HMMM.MazeGO.transform.SetParent(HUDMiniMapGO.transform);
            CreateIcon();      
            
            HMMM.updateMazeGOProperties();
            Icon.transform.SetParent(HUDMiniMapGO.transform);
            INTiconPOS = Icon.transform.position;
            INTmainplayerPOS = GameObject.Find("MainPlayer").transform.position;

            DetermineCameraMotion();
            
        }

        private void DetermineCameraMotion()
        {
            if(HMMM.MazeSize.First > 5 || HMMM.MazeSize.Second > 5 )
            {
                cameraNeedsToMove = true;
            }
        }

        private void CreateIcon()
        {
            Icon = (GameObject)GameObject.Instantiate(Resources.Load("Icon"));
            Icon.name = "Icon";
            HMMM.AddSpawnGO(0, 0, Icon);
      
        }

        private void hideAllCellsParts()
        {
            foreach (Transform MazeCellChild in HMMM.MazeGO.transform)
            {
                foreach(Transform MazeCellPartChild in MazeCellChild.transform)
                {
                    MazeCellPartChild.gameObject.SetActive(false);
                }

                MazeCellChild.gameObject.SetActive(false);
            }
               
        }

        
        public void MainPlayerCollision()
        {
            GameObject collidingGO = GameObject.Find("MainPlayer").GetComponent<MainPlayerColliderInfo>().GetCollidingObject();          
            MazeCell cell = HMMM.CellsInMaze.Find(x => (x.mazeCellGO.name == collidingGO.name));

            HUDMiniMapCellActivation(collidingGO, cell);
            InFinishCell(cell);

            if(cameraNeedsToMove)
            {
                cameraGO.transform.position = new Vector3(Icon.transform.position.x, cameraGO.transform.position.y, Icon.transform.position.z);
            }
            
        }

        private void HUDMiniMapCellActivation(GameObject collidingGO, MazeCell cell)
        {

            GameObject childGO = HMMM.MazeGO.transform.FindChild(collidingGO.name).gameObject;
            childGO.SetActive(true);

            //Activates all MazeCell Children(Walls,Floor)
            foreach (Transform ChildGOT in collidingGO.transform)
            {
                childGO.transform.FindChild(ChildGOT.gameObject.name).gameObject.SetActive(true);
            }

            //Generates North Borders in maze
            if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ - 1) == true))
            {
                ActivateWall("North Wall", HMMM.CellsInMaze.Find(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ - 1)).mazeCellGO);
            }


            //Generates East Borders in maze
            if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX + 1) && (x.cellLocationZ == cell.cellLocationZ) == true))
            {
                ActivateWall("East Wall", HMMM.CellsInMaze.Find(x => (x.cellLocationX == cell.cellLocationX + 1) && (x.cellLocationZ == cell.cellLocationZ)).mazeCellGO);
            }

            //Generates South Borders in maze
            if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ + 1) == true))
            {
                ActivateWall("South Wall", HMMM.CellsInMaze.Find(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ + 1)).mazeCellGO);
            }

            //Generates West Borders in maze
            if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX - 1) && (x.cellLocationZ == cell.cellLocationZ) == true))
            {
                ActivateWall("West Wall", HMMM.CellsInMaze.Find(x => (x.cellLocationX == cell.cellLocationX - 1) && (x.cellLocationZ == cell.cellLocationZ)).mazeCellGO);
            }
        }

        private void ActivateWall(string wall, GameObject MazeCellGO)
        {
            MazeCellGO.SetActive(true);
            switch (wall)
            {
                case "North Wall" :
                    if(MazeCellGO.transform.FindChild("South Wall") != null )
                        MazeCellGO.transform.FindChild("South Wall").gameObject.SetActive(true);
                    Debug.Log(wall);
                    Debug.Log(MazeCellGO);
                    break;

                case "East Wall":
                    if (MazeCellGO.transform.FindChild("West Wall") != null)
                        MazeCellGO.transform.FindChild("West Wall").gameObject.SetActive(true);
                    Debug.Log(wall);
                    Debug.Log(MazeCellGO);
                    break;

                case "South Wall":
                    if (MazeCellGO.transform.FindChild("North Wall") != null)
                        MazeCellGO.transform.FindChild("North Wall").gameObject.SetActive(true);
                    Debug.Log(wall);
                    Debug.Log(MazeCellGO);
                    break;

                case "West Wall":
                    if (MazeCellGO.transform.FindChild("East Wall") != null)
                        MazeCellGO.transform.FindChild("East Wall").gameObject.SetActive(true);
                    Debug.Log(wall);
                    Debug.Log(MazeCellGO);
                    break;

                default: break;   
            }

            
        }

        private void InFinishCell(MazeCell cell)
        {
            if(cell.FinishCell == true)
            {
                GameObject.Find("MainPlayer").GetComponent<WalkingScript>().freezePlayer = true;
                winMen.SetActive(true);
            }
        }
    }
}
