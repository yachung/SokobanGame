using System;

namespace SokobanGame
{
    public class Point
    {
        // 필드
        public int x { get; set; } = 0;
        public int y { get; set; } = 0;

        // 생성자
        public Point() { }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // 같은지 비교 함수
        public override bool Equals(object? obj)
        {
            // 현재 Point의 x와 y가 함수로 전달된 obj의 x와 y값과 같은지 비교
            // 비교를 위해서 obj를 Point로 형변환
            if (obj is not Point) return false;

            Point? other = obj as Point;

            // x와 y가 같은지 비교
            return (x == other.x && y == other.y);
        }
    }
}
