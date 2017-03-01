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
        Maze generate(int width, int height);
    }
}
