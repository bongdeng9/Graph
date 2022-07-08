using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class MyBFS
    {
        int[,] adj = new int[6, 6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0 },
        };

        public void BFS(int start)
        {
            // 방문일지 생성
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];

            // 예약목록 생성
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            // 방문한 시점에서 추가적인 정보를 잘 기입하면, 모든 방문이 끝났을 때, 다른 정보를 도출해 낼 수 있다.
            parent[start] = start;
            distance[start] = 0;

            // 예약
            while (q.Count > 0) //  마지막은 밑에 for loop 의 if 조건문에서 다 continue로 생략되면, q 에 들어가있는게 0 이 됨..!
            {
                // 방문
                int now = q.Dequeue(); //  now 가 for loop 끝날때마다 실시간으로 업데이트됨..!

                for (int next = 0; next < adj.GetLength(0); next++)
                {
                    // 인접해 있지 않으면 스킵
                    if (adj[now, next] == 0)
                        continue;
                    // 이미 찾았으면 스킵
                    if (found[next])
                        continue;
                    // 예약목록에 넣음
                    q.Enqueue(next);
                    found[next] = true;
                    parent[next] = now;
                    distance[next] = distance[now] + 1;

                }

            }
        }
    }
}
