using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MazeGenerate : MonoBehaviour
    {
		public int height = 15;
		public int width = 15;
        private HUDMiniMap HMM;
        // Use this for initialization
        void Start()
        {
            //DrawHardcodedMaze();
			DrawRandomMaze(width, height);
        }

        // Update is called once per frame
        void Update()
        {
           HMM.UpdateIconPOS();
           //GameObject.Find("Maze Particle System").GetComponent<ParticleSystem>().Simulate(1f, false, false);
        }

        /// <summary>
        /// Draws a randomly generated maze of the given size
        /// </summary>
        /// <param name="width">Width in cells</param>
        /// <param name="height">Height in cells</param>
        void DrawRandomMaze(int width, int height)
        {
            MazeGenerator generator = new RandomMazeGenerator(width, height);
            Maze maze = generator.Generate();
            maze.SetXYZScale(.5f, 6, .5f);
            maze.AddSpawnGO(0, 0, GameObject.Find("MainPlayer"));
    
            maze.Draw();
            DrawMiniMapMaze(maze);
            
        }

        /// <summary>
        /// Draws a hardcoded test maze.
        /// </summary>
        /// <param name="maze1">The maze object to draw</param>
        void DrawHardcodedMaze()
        {
            MazeGenerator generator = new TestMazeGenerator();
            Maze maze = generator.Generate();
            maze.SetXYZScale(.5f, 6, .5f);
            maze.Draw();
            maze.AddSpawnGO(0, 0, GameObject.Find("MainPlayer"));
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