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
            OnIconCollision();      
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

        private void OnIconCollision()
        {
           PlayerCollision tempObject = MainPlayerGO.GetComponentInChildren<PlayerCollision>();
           
           if(tempObject.GetCollidingObject() != null)
           {
              collidingGO = tempObject.GetCollidingObject();
              Debug.Log(collidingGO.name);
           }

            GameObject childGO = HMMM.MazeGO.transform.FindChild(collidingGO.name).gameObject;
            childGO.SetActive(true);
           foreach (Transform ChildGOT in collidingGO.transform)
           {
                childGO.transform.FindChild(ChildGOT.gameObject.name).gameObject.SetActive(true);
           }

            //Generates North Borders in maze
           // if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ - 1)) == false)
                //positionWall(cell.cellLocationX, cell.cellLocationZ, false, true, true, true, cell.mazeCellGO);

            //Generates East Borders in maze
            //if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX + 1) && (x.cellLocationZ == cell.cellLocationZ)) == false)
                //positionWall(cell.cellLocationX, cell.cellLocationZ, true, false, true, true, cell.mazeCellGO);

            //Generates South Borders in maze
            //if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX) && (x.cellLocationZ == cell.cellLocationZ + 1)) == false)
                //positionWall(cell.cellLocationX, cell.cellLocationZ, true, true, false, true, cell.mazeCellGO);

            //Generates West Borders in maze
            //if (HMMM.CellsInMaze.Exists(x => (x.cellLocationX == cell.cellLocationX - 1) && (x.cellLocationZ == cell.cellLocationZ)) == false)
               // positionWall(cell.cellLocationX, cell.cellLocationZ, true, true, true, false, cell.mazeCellGO);
            


        }



    }
}
