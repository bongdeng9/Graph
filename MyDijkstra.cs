using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class MyDijkstra
    {
        // 가중치가 포함된 2차원 행렬
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 },
        };
        // 인접한 노드 예약
        // 가중치 고려
        // 가장 좋은 걸 선택한다.
        // 
        public void Dijkstra(int start)
        {
            bool[] visited = new bool[6]; // 방문했었는 지 표시
            int[] distance = new int[6]; // 가중치 합 표시 실제 거리
            int[] parent = new int[6]; // 어디서 왔는 지 표시

            for (int i = 0; i < distance.Length; i++)
                distance[i] = Int32.MaxValue;

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                int closest = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 6; i++) // [후보는 맞는 지 확인]
                {
                    if (visited[i]) // 이미 방문했으면 스킵
                        continue;
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest) // 거리가 maxvalue 라는 것은, 뒤에 나오겠지만, 아직 방문하지 않은 거임. 이거나, 
                        continue;                                                // 기존 후보보다 멀리 있으면 스킵

                    // 갱신
                    closest = distance[i];
                    now = i;       
                }

                if (now == -1) // 종료조건
                    break;

                visited[now] = true; // 방문 (now = i)

                for (int next = 0; next < 6; next++) // [후보중에서 제일 나은 후보 선별]
                {
                    // 연결되지 않은 정점은 스킵
                    if (adj[now, next] == -1)
                        continue;
                    // 이미 방문한 정점은 스킵
                    if (visited[next])
                        continue;

                    // 새로 조사된 정점의 최단거리를 다시 계산한다.
                    int nextDist = distance[now] + adj[now, next]; // [now : 0 - 1 = 15] + [adj : 1 - 3 = 10] = 25

                    if (nextDist < distance[next]) // [distance[next]] = 35 (새로 조사된 정점의 최단거리 < 기존의 최단거리) 작을수록 최단거리니까, 갱신해줘야됨.
                    {
                        distance[next] = nextDist; // 최단거리 갱신
                        parent[next] = now;
                    }
                }

            }
            
        }
    }
}
