using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    


    public class HUDMiniMap {

        Maze HMMM;
        GameObject Icon;
        Vector3 INTiconPOS;
        Vector3 INTmainplayerPOS;


        public HUDMiniMap(Maze MiniMapMaze)
        {
            HMMM = MiniMapMaze;
            CreateIcon();
            HMMM.updateMazeGOProperties();
            INTiconPOS = Icon.transform.position;
            INTmainplayerPOS = GameObject.Find("MainPlayer").transform.position;
        }

        // Use this for initialization
       
        // Update is called once per frame
        public void UpdateIconPOS()
        {
            
            Vector3 MPPosition = GameObject.Find("MainPlayer").transform.position;
            Icon.transform.position = INTiconPOS + new Vector3((MPPosition.x - INTmainplayerPOS.x)/10, 0, (MPPosition.z - INTmainplayerPOS.z)/10) ;
            Debug.Log(Icon.transform.position);
        }

        private void CreateIcon()
        {
            Icon = (GameObject)GameObject.Instantiate(Resources.Load("Icon"));
            Icon.name = "Icon";
            HMMM.AddSpawnGO(0, 0, Icon);
      
        }
    }
}
