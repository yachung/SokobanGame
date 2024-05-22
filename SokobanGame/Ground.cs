using System;

namespace SokobanGame
{
    public class Ground : GameObject
    {
        public Ground() 
        {
            color = ConsoleColor.Green;
        }

        public override void Update(ConsoleKey key)
        {

        }

        public override void Draw()
        {
            Console.ForegroundColor = color;
            Console.Write('_');
        }
    }
}
