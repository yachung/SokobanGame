using System;
using System.Numerics;

namespace SokobanGame
{
    // 게임의 기본 물체를 나타내는 게임 오브젝트 클래스
    public abstract class GameObject
    {
        // 색상 값
        protected ConsoleColor color = ConsoleColor.Magenta;

        // 위치 값
        public Vector2 position { get; set; }

        // 업데이트
        public abstract void Update(ConsoleKey key);

        // 그리기
        public virtual void Draw()
        {
            Console.ForegroundColor = color;
        }
    }
}
