using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;




namespace Assets.Scripts
{
    public class HUDMiniMapGenerator : MazeGenerator
    {
        public Camera MiniMapCamera;
        private Maze mazeToDuplicate;
        private HUDMiniMapMaze HUDMMM;
        private GameObject Icon;
        

        public HUDMiniMapGenerator(Maze mazeToCreate)
        {
            HUDMMM = new HUDMiniMapMaze(mazeToCreate);
            this.mazeToDuplicate = mazeToCreate;
            createIcon();

            HUDMMM.updateMazeGOProperties();
        }

        public override Maze Generate()
        {
            return HUDMMM;
        }


        private void createIcon()
        {
            Icon = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            Icon.transform.name = "Icon";
            Icon.transform.position = new Vector3(0, 20, 0);
            Icon.transform.localScale = new Vector3(.1f, .001f, .1f);
           // Rigidbody rb = Icon.AddComponent<Rigidbody>();
            HUDMMM.AddSpawnGO(0, 0, Icon);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}