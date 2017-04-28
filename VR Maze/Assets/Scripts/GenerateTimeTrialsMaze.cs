using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GenerateTimeTrialsMaze : MonoBehaviour
    {
		public int height = 15;
		public int width = 15;
        HUDMiniMap HMM;
        // Use this for initialization
        void Start()
        {
            DrawTimeTrialsMaze();
        }

        // Update is called once per frame
        void Update()
        {
            HMM.UpdateCollisionInfo();
        }

        /// <summary>
        /// Draws a time trials maze
        /// </summary>
        void DrawTimeTrialsMaze()
        {
            MazeGenerator generator = new TimeTrialMazeGenerator();
            Maze maze = generator.Generate();
            maze.SetXYZScale(.5f, 6, .5f);
            maze.Draw();
            DrawMiniMapMaze(maze);
        }

        void DrawMiniMapMaze(Maze mazeToDuplicate)
        {
            MazeGenerator generator = new HUDMiniMapMazeGenerator(mazeToDuplicate);
            Maze maze = generator.Generate();
            HMM = new HUDMiniMap(maze);
        }

    }
}