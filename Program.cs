using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Program
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
                { 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 1, 0 },
            };

            // 리스트버전
            List<int>[] adj2 = new List<int>[]
            {
                new List<int>() { 1, 3},
                new List<int>() { 0, 2, 3},
                new List<int>() { 1},
                new List<int>() { 0, 1},
                new List<int>() { 5},
                new List<int>() { 4},
            };

            // 1) 우선 now 부터 방문하고,
            // 2) now 와 연결된 정점들을 하나씩 확인해서, [아직 미방문 상태라면] 방문한다.
            bool[] visited = new bool[6];
            public void DFS(int now)
            {
                Console.WriteLine(now);
                visited[now] = true;

                for (int next = 0; next < adj.GetLength(0); next++)
                {
                    if (adj[now, next] == 0) // 연결 되어 있지 않으면 스킵
                        continue;
                    if (visited[next]) // 이미 방문했으면 스킵
                        continue;
                    DFS(next);
                    // now 클리어 표시 visited
                    // next 다음 정점을 기준으로 같은 행동을 반복한다.
                    // 오케이 찍고 타고 다음거로 간다. 이 행동이 반복됨.
                    // 재귀함수 사용

                }
            }
            public void DFS2(int now)
            {
                Console.WriteLine(now);
                visited[now] = true;

                foreach(int next in adj2[now]) // 애초에 연결된 놈들만 배열들이 리스트에 담겨있음 DFS 에서랑은 다르게 DFS2 는 연결되어 있는지 체크 안해도 됨.
                {
                    if (visited[next]) // 이미 방문했으면 스킵
                        continue;
                    DFS2(next);
                }
            }

            public void SearchAll() // edge가 끊겨있어도 모든 노드 서치하는 함수
            {
                visited = new bool[6];
                for (int now = 0; now < 6; now++)
                    if (visited[now] == false)
                        DFS(now); // DFS를 한번 실행 하는 순간, 끊기기전 부분은 모두 TRUE로 바뀜
            }
        }

            static void Main(string[] args)
            {
                // 그래프의 기준? 
                // 그래프를 순회하는 방법 1. DFS(깊이 우선 탐색) 
                //                        2. BFS(너비 우선 탐색)

                // 던전을 생각한다.

                // DFS 는 무모한 용사 보이는 대로 무조건 들어감.
                // 최종보스까지 달려감. 
                // 더이상 갈 곳이 없으면 되돌아감.
                // 왔던 길을 계속 돌아가다가 안 가봤던 길을 발견하면 거기로 간다.
                // 똑같은 로직으로 안 가본 곳까지 간다.

                 Graph graph = new Graph();
                 graph.SearchAll();



            }


        
    }
}
