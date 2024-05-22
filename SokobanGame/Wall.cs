using System;
using System.Numerics;

namespace SokobanGame
{
    // 맵의 벽(Wall)을 담당하는 클래스.
    public class Wall : GameObject
    {
        // 생성자
        public Wall() 
        {
            // 물체의 기본 색 지정.
            color = ConsoleColor.Yellow;
        }

        public override void Update(ConsoleKey key)
        {
        }

        public override void Draw()
        {
            // 콘솔 글자 색상 설정.
            Console.ForegroundColor = color;

            // 그리기.
            Console.Write('W');
        }
    }
}
