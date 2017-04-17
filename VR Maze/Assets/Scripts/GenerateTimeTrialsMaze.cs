using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GenerateTimeTrialsMaze : MonoBehaviour
    {
		public int height = 15;
		public int width = 15;
        // Use this for initialization
        void Start()
        {
            DrawTimeTrialsMaze();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Draws a time trials maze
        /// </summary>
        void DrawTimeTrialsMaze()
        {
            MazeGenerator generator = new TimeTrialMazeGenerator();
            Maze maze = generator.Generate();
            maze.SetXYZScale(.5f, 6, .5f);
            maze.AddSpawnGO(0, 0, GameObject.Find("MainPlayer"));
            maze.Draw();
            DrawMiniMapMaze(maze);
        }

        void DrawMiniMapMaze(Maze mazeToDuplicate)
        {
            MazeGenerator generator = new HUDMiniMapGenerator(mazeToDuplicate);
            Maze maze = generator.Generate();
        }

    }
}