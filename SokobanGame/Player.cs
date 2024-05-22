using System;

namespace SokobanGame
{
    public class Player : GameObject
    {
        public Player()
        {
            color = ConsoleColor.White;
        }

        public override void Update(ConsoleKey key)
        {

        }

        public override void Draw()
        {
            base.Draw();
            Console.Write('P');
        }
    }
}
