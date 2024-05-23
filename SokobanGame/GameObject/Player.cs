using System;

namespace SokobanGame
{
    public class Player : GameObject
    {
        // 씬객체 : 플레이어가 이동을 시도할 때 이동이 가능한지 판단하기 위함
        private Scene scene;

        public Player(Point position, Scene scene) : base(position)
        {
            // 씬 객체 참조 저장
            this.scene = scene;
            color = ConsoleColor.White;
            name = 'P';
        }

        public override void Update(ConsoleKey key)
        {
            switch (key)
            {
                // 왼쪽 이동 처리
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    // 이동이 가능한 지확인
                    if (scene.CanMove(new Point(position.x - 1, position.y)))
                    {
                        position.x -= 1;
                    }
                    // 왼쪽으로의 이동은 x좌표를 하나 감소시키는 것과 같음
                    break;
                // 오른쪽 이동 처리    
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (scene.CanMove(new Point(position.x + 1, position.y)))
                    {
                        position.x += 1;
                    }
                    // 오른쪽으로의 이동은 x좌표를 하나 증가시키는 것과 같음
                    break;
                // 위쪽 이동 처리
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (scene.CanMove(new Point(position.x, position.y - 1)))
                    {
                        position.y -= 1;
                    }
                    // 위쪽으로의 이동은 y좌표를 하나 감소시키는 것과 같음
                    break;
                // 아래쪽 이동 처리
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    // 아래쪽으로의 이동은 y좌표를 증가시키는 것과 같음
                    if (scene.CanMove(new Point(position.x, position.y + 1)))
                    {
                        position.y += 1;
                    }
                    break;
            }
        }
    }
}
