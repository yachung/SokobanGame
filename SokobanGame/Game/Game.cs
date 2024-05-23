using System;

namespace SokobanGame
{
    // 게임 클래스.
    // 게임을 관리하고 실행하는 책임을 담당.
    public class Game
    {
        // 메인 씬 변수
        private Scene scene;
        private string mainSceneName = "Map.txt";

        // 생성자
        public Game()
        {
            scene = new Scene(mainSceneName);
        }

        // 실행 메소드(인터페이스)
        public void Run()
        {
            // 커서 감추기
            Console.CursorVisible = false;
            Console.Title = "Sokoban Game";

            // 첫 프레임 그리기
            Draw();

            // 게임 실행은 무한 루프로
            // 패턴 - 게임 루프 패턴
            while (true)
            {
                // 화면 정리 (화면 지우기).
                ResetScreen();

                // 업데이트 (방향키 입력을 적용한 후에 데이터 처리)
                Update(Console.ReadKey().Key);
                
                // 그리기.
                Draw();
            }
        }

        // 화면 정리 메소드
        private void ResetScreen()
        {
            // 콘솔 화면에 출력되는 글자 색상을 초기화.
            Console.ForegroundColor = ConsoleColor.White;

            // 콘솔 화면의 커서 위치를 0, 0으로 설정
            Console.SetCursorPosition(0, 0);
        }

        // 업데이트 (입력을 전달받아서 데이터를 갱신)
        private void Update(ConsoleKey key)
        {
            // Q로 종료하는 기능
            if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
            {
                // 화면 지우기
                Console.Clear();

                Console.WriteLine("게임 종료.");

                // 프로그램 종료.
                Environment.Exit(0);
            }

            // R로 재시작하는 기능
            if (key == ConsoleKey.R)
            {
                scene = new Scene(mainSceneName);
            }

            // 씬 업데이트
            scene.Update(key);
        }

        // 장면 그리기 메소드.
        // 그리기 -> Draw / Render
        private void Draw()
        {
            scene.Draw();
        }
    }
}
