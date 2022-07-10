using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Program_BFS
    {
        class Graph
        {
            // 2차원 배열 or 리스트

            // 행렬버전
            int[,] adj = new int[6, 6]
            {
                { 0, 1, 0, 1, 0, 0 },
                { 1, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 1, 0 },
            };

            // 리스트버전
            List<int>[] adj2 = new List<int>[]
            {
                new List<int>() { 1, 3},
                new List<int>() { 0, 2, 3},
                new List<int>() { 1},
                new List<int>() { 0, 1, 4},
                new List<int>() { 3, 5},
                new List<int>() { 4},
            };

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
                 graph.BFS(0);


            }


        
    }
}
