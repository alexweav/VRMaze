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
            AssignGameObjectRef();
        }

       
        public Maze returnMaze()
        {
            return this;
        }

        private void createMiniMapMaze(Maze mazeToDuplicate)
        {
            base.MazeGO = GameObject.Instantiate(mazeToDuplicate.MazeGO);
            base.CellsInMaze = mazeToDuplicate.CellsInMaze;
            base.SetXYZPosition(0, 0, 0);
            base.SetXYZScale(.05f, .01f, .05f);
            base.updateMazeGOProperties();
        }

        private void AssignGameObjectRef()
        {
            for (int i = 0; i < base.CellsInMaze.Count; i++)
            {
                base.CellsInMaze[i].mazeCellGO = base.MazeGO.transform.GetChild(i).gameObject;
            }
        }


    }
}
