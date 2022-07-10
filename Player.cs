using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm1
{
    class Pos
    {
        public Pos(int y, int x) { Y = y; X = x; }
        public int Y;
        public int X;
    }
    class Player
    {
        // 설계적 감 처음에는 누구나 없음 경험이 쌓이면 됨
        // 플레이어의 위치를 Board.Render 에서 접근
        public int PosY { get; private set; } // 외부에서 플레이어 위치를 get으로 질의(Read = get)는 할 수 있겠지만,  (Write = set)은 할 수 없다
        public int PosX { get; private set; } // private set : 플레이어의 좌표정보는 자기 자신만 바꿀것
        Random _random = new Random();
        Board _board;

        enum Dir
        {
            Up = 0,
            Left = 1,
            Down = 2,
            Right = 3 
        }

        int _dir = (int)Dir.Up;
        List<Pos> _points = new List<Pos>();

        public void Initialize(int posY, int posX, Board board)
        {
            // 현재 상태르 기반으로 한칸씩  / 모든 경로를 계산해놓은다음 하나씩 업데이트에서 꺼내쓰기
            PosY = posY;
            PosX = posX;
            _board = board;

            BFS();
        }

        void BFS()
        {
            int[] deltaY = new int[] { -1, 0, 1, 0};
            int[] deltaX = new int[] { 0, -1, 0, 1};

            // 인덱스보다 좌표를 이용하는게 직관적
            bool[,] found = new bool[_board.Size, _board.Size];
            Pos[,] parent = new Pos[_board.Size, _board.Size];

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(PosY, PosX));
            found[PosY, PosX] = true;
            parent[PosY, PosX] = new Pos(PosY, PosX); // 시작점의 부모는 자신이다. 

            while (q.Count > 0)
            {
                Pos pos = q.Dequeue();
                int nowY = pos.Y;
                int nowX = pos.X;

                for (int i = 0; i < 4; i++)
                {
                    // 위 왼 아래 오른 순서대로 서칭 
                    int nextY = nowY + deltaY[i];
                    int nextX = nowX + deltaX[i];


                    if (nextX < 0 || nextX >= _board.Size || nextY < 0 || nextY >= _board.Size)
                        continue;
                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall) // 배열을 접근하는 코드(Tile[])는 늘 범위를 조심해야한다.
                        continue;
                    if (found[nextY, nextX])
                        continue;

                    q.Enqueue(new Pos(nextY, nextX)); // 예약을 다시 한다.
                    found[nextY, nextX] = true;
                    parent[nextY, nextX] = new Pos(nowY, nowX);

                } // 이것 만으로 최단거리나 이동거리를 추출할 수 없음
                // 여기까지 한 건 BFS 를 한번 스캔한 것 뿐
                // 현재 관심사는 거리보다는 이동경로가 중요함 -> 부모 즉 어디서부터 왔는 지 기억하고 있으면 됨.
            }
            int y = _board.DestY;
            int x = _board.DestX; // 도착한 목적지에서 거꾸로 추적해서 처음시작점까지 거슬러 올라간다.
            while (parent[y, x].Y != y || parent[y, x].X != x) // 
            {
                _points.Add(new Pos(y, x));
                Pos pos = parent[y, x];
                y = pos.Y;
                x = pos.X;
            }
            _points.Add(new Pos(y, x));  // 시작점 더해줌
            _points.Reverse(); // 역 추적 했던 것을 뒤집어서 처음부터 찾아감

        } // BFS 를 이용해서 경로를 찾음 , 우수법과는 달리 최단경로를 찾음 , BFS 의 동작방식을 생각해보면, 시작점을 기준으로 무조건 깊이 들어가는 게 아니라, 시작 위치를
        // 기준으로 가장 가까운 노드부터 서칭을 했기 때문에 최단 경로를 이동함.

        void RightHand()
        {
            // 현재 바라보고 있는 방향을 기준으로 좌표 변화를 나타낸다.
            int[] frontY = new int[] { -1, 0, 1, 0 };
            int[] frontX = new int[] { 0, -1, 0, 1 };
            int[] rightY = new int[] { 0, -1, 0, 1 };
            int[] rightX = new int[] { 1, 0, -1, 0 }; // 인덱스 : {Up 0 , Left 1,  Down 2,  Right 3 } 일 때 y, x 좌표 변화를 나타냄.

            _points.Add(new Pos(PosY, PosX));
            // 목적지 도착하기 전에는 계속 실행
            while (PosY != _board.DestY || PosX != _board.DestX)
            {
                // 우수법 오른손 법칙 
                // 1. 현재 바라보는 방향을 기준으로 오른쪽으로 갈 수 있는 지 확인.
                if (_board.Tile[PosY + rightY[_dir], PosX + rightX[_dir]] == Board.TileType.Empty)
                {
                    // 오른쪽 방향으로 90도 회전
                    _dir = (_dir - 1 + 4) % 4; // -1 빼는거는 한 칸 위로 올리는 거 +4 더한거는 양수로 취급 %4 4로 나눈 나머지
                    // 앞으로 한 보 전진.
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _points.Add(new Pos(PosY, PosX));

                }
                // 2. 현재 바라보는 방향을 기준으로 전진할 수 있는 지 확인.
                else if (_board.Tile[PosY + frontY[_dir], PosX + frontX[_dir]] == Board.TileType.Empty)
                {
                    // 앞으로 한 보 전진
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _points.Add(new Pos(PosY, PosX));

                }
                else
                {
                    // 왼쪽으로 방향으로 90도 회전
                    _dir = (_dir + 1 + 4) % 4;
                    // 턴을 넘긴다.
                }
            }
        }

        const int MOVE_TICK = 10; // 0.1초
        int _sumTick = 0;
        int _lastIndex = 0;
        public void Update(int deltaTick) // 30분의 1초마다 업데이트가 실행되는건 너무 빠르니까 deltaTick 을 도입해서 업데이트를 실행할 지 , 넘길 지 결정.
        {
            if (_lastIndex >= _points.Count)
                return;

            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                // 여기다가 0.1초마다 실행될 로직을 넣어준다.
                PosY = _points[_lastIndex].Y;
                PosX = _points[_lastIndex].X;
                _lastIndex++;
                // 배열을 사용할 때는 인덱스가 범위를 초과하지 않는 지 잘 확인해야됨.
            }
        }
    }
}
