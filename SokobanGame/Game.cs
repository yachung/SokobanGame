using System;

namespace SokobanGame
{
    // 게임 클래스.
    // 게임을 관리하고 실행하는 책임을 담당.
    public class Game
    {
        // 실행 메소드(인터페이스)
        public void Run()
        {
            // 게임 실행은 무한 루프로
            // 패턴 - 게임 루프 패턴
            while (true)
            {
                // 입력 처리 (방향키 입력을 처리)

                // 업데이트 (방향키 입력을 적용한 후에 데이터 처리)

                // 그리기.
                Console.WriteLine("그리기");
            }
        }
    }
}
