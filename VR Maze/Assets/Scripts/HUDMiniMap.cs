using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Assets.Scripts
{
    public class HUDMiniMap : MonoBehaviour
    {
        
        private GameObject MiniMap;
        private Maze MiniMapMaze;

        public HUDMiniMap(Maze mazeToCreate)
        {
            createMiniMapMaze(mazeToCreate);
            createIcon();
            MiniMapMaze.updateMazeGOProperties();
        }


        private void createMiniMapMaze(Maze mazeToCreate)
        {
            MiniMapMaze = mazeToCreate; 
            MiniMapMaze.MazeGO = GameObject.Instantiate(mazeToCreate.MazeGO);
            MiniMapMaze.MazeGO.transform.name = "MiniMap Maze";
            MiniMapMaze.SetXYZPosition(0, 20, 0);
            MiniMapMaze.SetXYZScale(.05f,.01f,.05f);
            

            MiniMap = new GameObject("MiniMap");
            MiniMapMaze.MazeGO.transform.SetParent(MiniMap.transform);
            
        }

        private void createIcon()
        {
            GameObject Icon = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            Icon.transform.name = "Icon";
            Icon.transform.localScale = new Vector3(.1f, .001f, .1f);
            MiniMapMaze.AddSpawnGO(0, 0, Icon);
            



        }



        // Update is called once per frame
        void Update()
        {

        }
    }

}