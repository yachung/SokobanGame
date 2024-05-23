using System;

namespace SokobanGame
{
    // 게임의 기본 물체를 나타내는 게임 오브젝트 클래스
    public class GameObject
    {
        // 색상 값
        protected ConsoleColor color = ConsoleColor.Magenta;

        // 콘솔에 출력할 때 사용할 문자 값
        protected char name;

        // 위치 값
        public Point position { get; set; } = new Point();

        public GameObject (Point position)
        {
            // 깊은 복사
            this.position.x = position.x;
            this.position.y = position.y;
        }

        // 위치 설정 함수
        public void SetPosition(Point position)
        {
            // 전달된 위치 값을 복사
            this.position.x = position.x;
            this.position.y = position.y;
        }

        // 업데이트
        public virtual void Update(ConsoleKey key)
        {

        }

        // 그리기
        public virtual void Draw()
        {
            // 콘솔 글자 색상 변경
            Console.ForegroundColor = color;

            // 커서 위치 옮기기
            Console.SetCursorPosition(position.x, position.y);

            // 문자 출력
            Console.Write(name);
        }
    }
}
