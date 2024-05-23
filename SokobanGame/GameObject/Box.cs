using System;

namespace SokobanGame
{
    public class Box : GameObject
    {
        public Box(Point position) : base(position)
        {
            color = ConsoleColor.Cyan;
            name = 'B';
        }
    }
}
