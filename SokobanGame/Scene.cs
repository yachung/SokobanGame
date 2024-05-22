using System;
using System.Numerics;

namespace SokobanGame
{
    // 씬(장면, 레벨) - 스테이지를 읽고 관리하는 클래스
    public class Scene
    {
        //private List<char> mapData = new List<char>();
        private List<GameObject> mapData = new List<GameObject>();

        public Scene(string mapFileName)
        {
            Load(mapFileName);
        }

        // 맵 파일을 읽고 분석하는 메소드.
        private void Load(string fileName)
        {
            int x = 0;
            int y = 0;

            // 맵 파일을 전체 문자열로 읽어서 저장
            //mapData = File.ReadAllText(fileName);
            //mapData = File.ReadAllLines(fileName);
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                //char[] lineChars = line.ToCharArray();

                foreach (char c in line)
                {
                    Vector2 position = new Vector2(x++, y++);

                    switch (c)
                    {
                        case '1':
                            mapData.Add(new Wall());
                            break;
                        case '.':
                            mapData.Add(new Ground());
                            break;
                        case 'p':
                            mapData.Add(new Player());
                            break;
                        case 't':
                            mapData.Add(new Target());
                            break;
                        case 'b':
                            mapData.Add(new Box());
                            break;
                        //default:
                        //    mapData.Add(c);
                        //    break;
                    }

                    mapData.Last().position = position;
                }

                //mapData.Add('\n');
            }
        }

        // Update 메소드
        public void Update(ConsoleKey key)
        {
            foreach (var gameObject in mapData)
            {
                gameObject.Update(key);
            }
        }

        // Draw 메소드
        public void Draw()
        {
            int index = 0;

            foreach (var gameObject in mapData)
            {
                gameObject.Draw();
                //Console.Write(line);
                index++;
                if (index % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
