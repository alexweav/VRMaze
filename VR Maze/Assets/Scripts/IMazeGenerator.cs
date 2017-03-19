using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    /// <summary>
    /// Interface for all maze generation classes
    /// </summary>
    interface IMazeGenerator
    {
        /// <summary>
        /// Generates a maze that is "width" cells wide and "height" cells tall
        /// </summary>
        /// <param name="width">Width in cells</param>
        /// <param name="height">Height in cells</param>
        /// <returns>The maze</returns>
        Maze generate(int width, int height);
    }
}
