using System;

namespace SokobanGame
{
    public class Target : GameObject
    {
        public Target(Point position) : base(position)
        {
            color = ConsoleColor.Blue;
            name = 'T';
        }
    }
}
