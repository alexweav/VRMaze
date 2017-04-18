using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;




namespace Assets.Scripts
{
    public class HUDMiniMapMazeGenerator : MazeGenerator
    {
        public Camera MiniMapCamera;
        private Maze mazeToDuplicate;
        private HUDMiniMapMaze HUDMMM;
    
        

        public HUDMiniMapMazeGenerator(Maze mazeToCreate)
        {
            HUDMMM = new HUDMiniMapMaze(mazeToCreate);
            this.mazeToDuplicate = mazeToCreate;
            HUDMMM.updateMazeGOProperties();
        }

        public override Maze Generate()
        {
            return HUDMMM;
        }

        



    }

}