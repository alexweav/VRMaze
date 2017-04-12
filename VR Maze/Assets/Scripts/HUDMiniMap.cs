using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    


    public class HUDMiniMap 
    {

        private Maze HMMM;
        GameObject HUDMiniMapGO;
        GameObject Icon;
        Vector3 INTiconPOS;
        Vector3 INTmainplayerPOS;

        

   


        public HUDMiniMap(Maze MiniMapMaze)
        {
            IntializeHUDMiniMap(MiniMapMaze);
            


            //hideAllCellsParts();
        }

        // Use this for initialization
       
        // Update is called once per frame
        public void UpdateIconPOS()
        {
            Vector3 MPPosition = GameObject.Find("MainPlayer").transform.position;
            Icon.transform.position = INTiconPOS + new Vector3((MPPosition.x - INTmainplayerPOS.x)/10, 0, (MPPosition.z - INTmainplayerPOS.z)/10) ;
            OnIconCollisionEnter();      
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

        private void OnIconCollisionEnter()
        {
            CapsuleCollider IconCollision = Icon.GetComponent<CapsuleCollider>();
            bool f = IconCollision.isTrigger;
            Debug.Log(f);
        }



    }
}
