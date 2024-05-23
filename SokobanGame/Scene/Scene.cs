using System;

namespace SokobanGame
{
    // 씬(장면, 레벨) - 스테이지를 읽고 관리하는 클래스
    public class Scene
    {
        // 그릴 때 깊이(Depth) 조정을 위해 카테고리 별로 분리
        private List<GameObject> gameObjects = new List<GameObject>();
        private List<Box> boxes = new List<Box>();
        private List<Target> targets = new List<Target>(); // 타겟 게임 오브젝트 -> 그릴 때는 사용하지 않고, 점수 확인할 때 사용
        private Player player;

        GameManager gameManager;

        public Scene(string mapFileName)
        {
            // 레벨 로드
            Load(mapFileName);

            // 게임 관리자 객체 생성
            gameManager = new GameManager(targets.Count);
        }

        // 이동이 가능한지 판단
        public bool CanMove(Point newPosition)
        {
            return gameManager.CanMove(newPosition, player, gameObjects, boxes, targets);
        }

        // 맵 파일을 읽고 분석하는 메소드.
        private void Load(string fileName)
        {
            // 맵 파일을 전체 문자열로 읽어서 저장
            //mapData = File.ReadAllText(fileName);
            //mapData = File.ReadAllLines(fileName);
            string[] lines = File.ReadAllLines(fileName);

            //foreach (string line in lines)
            for (int y = 0; y < lines.Length; ++y)
            {
                char[] lineChars = lines[y].ToCharArray();
                //foreach (char c in line)
                for (int x = 0; x < lineChars.Length; ++x)
                {
                    char c = lineChars[x];

                    // 게임 오브젝트가 생성될 위치
                    Point position = new Point(x, y);
                    
                    switch (c)
                    {
                        case '1':
                            gameObjects.Add(new Wall(position));
                            break;
                        case '.':
                            gameObjects.Add(new Ground(position));
                            break;
                        case 'p':
                            // 플레이어 생성
                            player = new Player(position, this);

                            // 플레이어의 위치는 길도 같이 생성해줘야 함.
                            // 나중에 플레이어가 이동했을때 길이 그려질 수 있도록
                            gameObjects.Add(new Ground(position));
                            break;
                        case 't':
                            Target newTarget = new Target(position);
                            gameObjects.Add(newTarget);

                            // 점수 확인을 위해서 타겟을 얉은 복사로 따로 또 관리
                            targets.Add(newTarget);
                            break;
                        case 'b':
                            // 박스는 따로 그릴 수 있도록 처리.
                            boxes.Add(new Box(position));

                            // 박스의 위치는 길도 같이 생성해야 함
                            // 나중에 박스가 이동했을 때 길이 그려질 수 있도록
                            gameObjects.Add(new Ground(position));
                            break;
                        //default:
                        //    mapData.Add(c);
                        //    break;
                    }
                }
            }
        }

        // Update 메소드
        public void Update(ConsoleKey key)
        {
            // 물체 업데이트
            //foreach (var gameObject in gameObjects)
            //{
            //    gameObject.Update(key);
            //}

            // 게임이 클리어 됐는지 확인하고, 클리어라면 업데이트 진행 안함.
            if (gameManager.IsGameClear)
                return;

            // 플레이어 업데이트
            player.Update(key);
        }

        // Draw 메소드
        public void Draw()
        {
            // 레벨 그리기
            // 가장 먼저 그려져야 할 물체 그리기
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw();
            }

            // 박스 그리기
            foreach (var box in boxes)
            {
                box.Draw();
            }

            player.Draw();

            // 메뉴 그리기
            DrawMenu();

            // 게임 클리어인 경우, 화면에 클리어 메세지
            if (gameManager.IsGameClear)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(15, 7);
                Console.Write("!!!!!!!!!!게임 클리어!!!!!!!!!");
            }
        }

        private void DrawMenu()
        {
            // 메뉴 그리기
            Console.ForegroundColor = ConsoleColor.White;

            // x로 15칸, y로는 0칸 커서 이동
            Console.SetCursorPosition(15, 0);

            // 메뉴 문자 출력
            Console.Write("게임을 종료하려면 Q키(또는 ESC)를 누르세요.");
            
            Console.SetCursorPosition(15, 14);
            Console.Write($"targetScore : {gameManager.targetScore}");
            Console.SetCursorPosition(15, 15);
            Console.Write($"currentScore : {gameManager.currentScore}");
        }
    }
}
