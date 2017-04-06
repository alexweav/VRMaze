using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts
{
    /// <summary>
    /// Generates mazes for the Time Trials gamemode
    /// </summary>
    public class TimeTrialMazeGenerator : MazeGenerator
    {
        public override Maze Generate()
        {
            Random rng = new Random();
            int map = rng.Next(1, 3);
            int seed;
            switch (map)
            {
                case 1:
                    seed = 640;
                    break;
                case 2:
                    seed = 409;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The generator tried to generate map number " + map + ", which does not exist.");
            }
            MazeGenerator generator = new RandomMazeGenerator(15, 15, seed);
            return generator.Generate();
        }
    }
}