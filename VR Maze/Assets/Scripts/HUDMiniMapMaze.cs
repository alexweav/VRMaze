using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class HUDMiniMapMaze : Maze
    {


        public HUDMiniMapMaze(Maze mazeToDuplicate)
        {
            base.IntializeMaze("MiniMap Maze");
            createMiniMapMaze(mazeToDuplicate);
        }

        public Maze returnMaze()
        {
            return this;
        }

        private void createMiniMapMaze(Maze mazeToDuplicate)
        {
            base.MazeGO = GameObject.Instantiate(mazeToDuplicate.MazeGO);
            base.SetXYZPosition(0, 20, 0);
            base.SetXYZScale(.05f, .01f, .05f);
            base.updateMazeGOProperties();
        }

        
    }
}
