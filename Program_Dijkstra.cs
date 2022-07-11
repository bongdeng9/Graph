using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Program_Dijkstra
    {
        class Graph
        {
            // 2차원 배열 or 리스트

            // 행렬버전 [가중치 입력]
            int[,] adj = new int[6, 6]
            {
                { -1, 15, -1, 35, -1, -1 },
                { 15, -1, 05, 10, -1, -1 },
                { -1, 05, -1, -1, -1, -1 },
                { 35, 10, -1, -1, 05, -1 },
                { -1, -1, -1, 05, -1, 05 },
                { -1, -1, -1, -1, 05, -1 },
            };
            public void Dijkstra(int start)
            {
                bool[] visited = new bool[6]; // 찾은거보다 방문한게 중요함.
                int[] distance = new int[6]; // 가중치 거리
                int[] parent = new int[6];

                for (int i = 0; i < distance.Length; i++)
                    distance[i] = Int32.MaxValue; // 초기값인지, 방문을안해서 0인지 모르니까 초기값을 최대로 바꿈.

                distance[start] = 0;
                parent[start] = start;
                // BFS 는 예약목록을 Queue로 작성했지만, 다익스트라는 선입선출이 아니고, 예약한 애가 언제든지 뒤집힐 수 있다.
                // 상황에 따라 더 나은 길이 바뀔 수 있음
                // 그래서 distance로 예약이 한번이라도 됐는지 안됐는지 파악.


                /*[자주 나오는 패턴]. 어떤 배열에서 가장 큰 값을 찾고 싶었을 때, 실시간으로 서칭하면서, 중간중간에 now값을 이용해,
                  그동안 찾은 가장 좋은 후보를 now에 저장하고 있다가, 최종 for 문에서 후보를 갱신해준다. */

                while (true)
                {
                    // 제일 좋은 후보를 찾는다. (가장 가까이 있는)

                    // 가장 유력한 후보의 거리와 번호를 저장한다.
                    int closest = Int32.MaxValue;
                    int now = -1;
                    for (int i = 0; i < 6; i++)
                    {
                        // 이미 방문한 정점은 스킵
                        if (visited[i])
                            continue;

                        // 아직 발견 (예약)된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                        if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                            continue;

                        // 여태껏 발견한 가장 좋은 후보라는 의미니까, 정보를 갱신
                        closest = distance[i];
                        now = i;
                        Console.WriteLine(now);

                    }
                    // 종료 조건 : 다음 후보가 하나도 없다. : 모든점을 다 찾았거나, 연결이 단절되어 있다.
                    if (now == -1)
                        break;

                    // 제일 좋은 후보를 찾았으므로, 방문한다.
                    visited[now] = true;

                    // 다음 지점을 예약 방문한 정점과 인접한 정점들을 조사해서,
                    // 상황에 따라 발견한 최단거리를 갱신한다.
                    for (int next = 0; next < 6; next++)
                    {
                        // 연결되지 않은 정점은 스킵
                        if (adj[now, next] == -1)
                            continue;
                        // 이미 방문한 정점은 스킵
                        if (visited[next])
                            continue;

                        // 여기까지 오면, next라는 정점에 대해 조사할 수 있음. 가중치가 몇인지 등등
                        // 한번도 방문하지 않았고 연결되어 있는 정점 보장
                        // 새로 조사된 정점임. 
                        // 최단거리를 다시 계산한다.

                        int nextDist = distance[now] + adj[now, next];

                        // 새로 발견 된 길이 최선인지 확인한다.
                        // 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면 정보를 갱신한다.
                        if (nextDist < distance[next]) // nextDist가 새로 조사된 최단거리, distance[next] 가 기존의 최단거리
                        {
                            distance[next] = nextDist;
                            parent[next] = now;
                        }
                    }
                }
            }

            public void BFS(int start)
            {
                bool[] found = new bool[6];
                int[] parent = new int[6];
                int[] distance = new int[6];

                Queue<int> q = new Queue<int>(); // 예약목록 대기열 생성
                q.Enqueue(start);

                found[start] = true; // 찾았다
                parent[start] = start;
                distance[start] = 0;

                while (q.Count > 0) // 예약목록에 노드 vertex 정점이 하나라도 있으면 루프를 계속돈다.
                {
                    int now = q.Dequeue(); // 예약목록에서 선입선출로 뽑아오기 [방문]
                    Console.WriteLine(now);
                    // 한번도 방문하지 않은 노드면 방문한다.

                    // 예약하는 코드
                    for (int next = 0; next < adj.GetLength(0); next++)
                    {
                        if (adj[now, next] == 0) // 인접하지 않았으면 스킵
                            continue;
                        if (found[next]) // 이미 발견했으면 스킵
                            continue;

                        q.Enqueue(next);
                        found[next] = true;
                        parent[next] = now;
                        distance[next] = distance[now] + 1;
                    }
                }
            }
        }

            static void Main(string[] args)
            {
                // 그래프의 기준? 
                // 그래프를 순회하는 방법 1. DFS(깊이 우선 탐색) 
                //                        2. BFS(너비 우선 탐색)

                // 던전을 생각한다.

                // [BFS] 
                // 위험을 감수하기 싫은 용서
                // 초기 시작점과 최대한 가까이 있는 정점 노드 를 선택
                // 얕은 던전 난이도 대로 클리어

                // 구현하려면, [예약 시스템]이 필요하다.

                // 예약만 하고 방문하지 않음.
                // 다음 턴에서 예약한 목록중 가장 오래된 노드를 방문한다.
                // 가장 인접한 노드들중 아직 한번도 방문하지 않은 노드를 예약해놓고 턴을 끝낸다.
                // 방문 --> 예약 --> 가장 먼저 예약된 노드 방문 --> 예약 --> 방문
                // 가장 먼저 들어간 것을 꺼낸다? 선입선출 -> [Queue] 를 사용하면 된다!
                 Graph graph = new Graph();
                 graph.Dijkstra(0);
            }


        
    }
}
