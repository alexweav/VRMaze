using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    


    public class HUDMiniMap  
    {
      
        public Maze HMMM;
        GameObject HUDMiniMapGO, MainPlayerGO;
        
        //GameObject collidingGO;
        GameObject winMen;
        

        public HUDMiniMap(Maze MiniMapMaze)
        {
            GameObject.Find("MainPlayer").AddComponent<MainPlayerColliderInfo>();
            winMen = GameObject.Find("MainPlayer").transform.FindChild("GvrMain").transform.FindChild("Head").transform.FindChild("Main Camera").transform.FindChild("WinMenu").gameObject;
            IntializeHUDMiniMap(MiniMapMaze);
            MainPlayerGO = GameObject.Find("MainPlayer");
            
        }

        // Use this for initialization
       
        // Update is called once per frame
        public void UpdateCollisionInfo()
        {        
            MainPlayerCollision();
            HMMM.UpdateMainPlayerIconPOS();
            
        }

        

        private void IntializeHUDMiniMap(Maze MiniMapMaze)
        {

           
            HUDMiniMapGO = (GameObject)GameObject.Instantiate(Resources.Load("HUDMiniMap"));
            HUDMiniMapGO.name = "HUDMiniMap";
            HMMM = MiniMapMaze;
            HMMM.MazeGO.transform.SetParent(HUDMiniMapGO.transform);         
            HMMM.updateMazeGOProperties();
            MiniMapMaze.SpawnAllGO();
            
        }

        
        public void MainPlayerCollision()
        {
            GameObject collidingGO = GameObject.Find("MainPlayer").GetComponent<MainPlayerColliderInfo>().GetCollidingObject();          
            MazeCell cell = HMMM.CellsInMaze.Find(x => (x.mazeCellGO.name == collidingGO.name));

            HUDMiniMapCellActivation(collidingGO, cell);
            InFinishCell(cell);

            
        }

        private void HUDMiniMapCellActivation(GameObject collidingGO, MazeCell cell)
        {

            GameObject childGO = HMMM.MazeGO.transform.FindChild(collidingGO.name).gameObject;
            childGO.SetActive(true);

            //Activates all MazeCell Children(Walls,Floor)
            foreach (Transform ChildGOT in childGO.transform)
            {
                childGO.transform.FindChild(ChildGOT.gameObject.name).gameObject.SetActive(true);
                
                //Debug.Log(ChildGOT.name);
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
                    //Debug.Log(wall);
                    //Debug.Log(MazeCellGO);
                    break;

                case "East Wall":
                    if (MazeCellGO.transform.FindChild("West Wall") != null)
                        MazeCellGO.transform.FindChild("West Wall").gameObject.SetActive(true);
                    //Debug.Log(wall);
                    //Debug.Log(MazeCellGO);
                    break;

                case "South Wall":
                    if (MazeCellGO.transform.FindChild("North Wall") != null)
                        MazeCellGO.transform.FindChild("North Wall").gameObject.SetActive(true);
                    //Debug.Log(wall);
                    //Debug.Log(MazeCellGO);
                    break;

                case "West Wall":
                    if (MazeCellGO.transform.FindChild("East Wall") != null)
                        MazeCellGO.transform.FindChild("East Wall").gameObject.SetActive(true);
                    //Debug.Log(wall);
                    //Debug.Log(MazeCellGO);
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
