using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    


    public class HUDMiniMap  
    {

        private Maze HMMM;
        GameObject HUDMiniMapGO, MainPlayerGO;
        GameObject Icon;
        GameObject collidingGO;
        Vector3 INTiconPOS;
        Vector3 INTmainplayerPOS;

        public HUDMiniMap(Maze MiniMapMaze)
        {
            GameObject.Find("MainPlayer").AddComponent<MainPlayerColliderInfo>();
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
            HUDMiniMapGO = (GameObject)GameObject.Instantiate(Resources.Load("HUDMiniMap"));
            HUDMiniMapGO.name = "HUDMiniMap";
            

            HMMM = MiniMapMaze;
            CreateIcon();
            HMMM.updateMazeGOProperties();
            INTiconPOS = Icon.transform.position;
            INTmainplayerPOS = GameObject.Find("MainPlayer").transform.position;
            Icon.transform.SetParent(HUDMiniMapGO.transform);
            HMMM.MazeGO.transform.SetParent(HUDMiniMapGO.transform);

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
         GameObject tempObject = GameObject.Find("MainPlayer").GetComponent<MainPlayerColliderInfo>().GetCollidingObject();
            //if(tempObject.gameObject != null)
            //{
            Debug.Log(tempObject);
              collidingGO = tempObject.gameObject;
         //}

            GameObject childGO = HMMM.MazeGO.transform.FindChild(collidingGO.name).gameObject;
            childGO.SetActive(true);
           foreach (Transform ChildGOT in collidingGO.transform)
           {
                childGO.transform.FindChild(ChildGOT.gameObject.name).gameObject.SetActive(true);
           }

            

            Debug.Log("Past Loop");
            MazeCell cell = HMMM.CellsInMaze.Find(x => (x.mazeCellGO.name == collidingGO.name));


            //Generates North Borders in maze
            if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ - 1) == true) )
            {
                //Debug.Log("North Wall");
                ActivateWall("North Wall", HMMM.CellsInMaze.Find(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ - 1)).mazeCellGO);
            }
              

            //Generates East Borders in maze
         if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX + 1) && (x.cellLocationZ == cell.cellLocationZ) == true) )
         {
               // Debug.Log("East Wall");
                ActivateWall("East Wall", HMMM.CellsInMaze.Find(x => (x.cellLocationX == cell.cellLocationX + 1) && (x.cellLocationZ == cell.cellLocationZ)).mazeCellGO);
         }      

            //Generates South Borders in maze
         if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ + 1) == true) )
         {
                //Debug.Log("South Wall");
                ActivateWall("South Wall", HMMM.CellsInMaze.Find(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ + 1)).mazeCellGO);
         }     

            //Generates West Borders in maze
         if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX - 1) && (x.cellLocationZ == cell.cellLocationZ) == true) )
         {
               // Debug.Log("West Wall");
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
    }
}
