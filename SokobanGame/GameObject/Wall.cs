using System;

namespace SokobanGame
{
    // 맵의 벽(Wall)을 담당하는 클래스.
    public class Wall : GameObject
    {
        // 생성자
        public Wall(Point position) : base(position) 
        {
            // 물체의 기본 색 지정.
            color = ConsoleColor.Yellow;
            name = 'W';
        }
    }
}
