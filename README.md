# Graph
 그래프를 코드로 구현해봤다.
 2차원 배열 (행렬)로 구현하는 버전과
 리스트로 구현하는 버전 두가지로 진행했다.
 그래프를 구현한 다음, 그래프를 순회하는 여러가지 방법 중, 
 DFS와 BFS 에 대해 배웠다.
# DFS (Depth First Search) 
 무조건 보이는 대로 들어간다.
 최종 보스까지 달려간다.
 더이상 갈 곳이 없으면 되돌아간다.
 되돌아 가면서 안가봤던 길을 발견하면 거기로 간다.
 똑같은 로직으로 안 가본 곳까지 간다.
 # DFS 주요 알고리즘
 노드 (vertex)를 이전에 방문했는지 확인하는 배열 (visited[]) 을 bool 형식으로 셍성
 방문 표시 (visited[now] = true)
 노드끼리 연결되어 있지 않으면 스킵한다. (continue)
 이미 방문했으면 스킵한다. (continue)
 재귀함수로 똑같은 과정을 반복한다.
 
 # BFS (Breath First Search) 
 초기 시작점과 최대한 가까이 있는 정점 노드를 선택
 얕은 던전 난이도 대로 클리어
 구현하려면 [예약 시스템]이 필요하다.
 # BFS 주요 알고리즘
 [선입선출]예약시스템이 필요함 -> Queue 사용
 인접한 노드들중, 방문하지 않았던 노드들을 예약해놓는다.
 가장 먼저 예약한 노드를 방문한다.(now)
 
 
<img width="602" alt="graph1" src="https://user-images.githubusercontent.com/80138709/177958893-b0325a1a-5375-43d4-ab4e-21a880458b58.png">
<img width="602" alt="graph2" src="https://user-images.githubusercontent.com/80138709/177958903-7a91b0fa-f04e-4da6-b95a-e5b2d1d0d3ce.png">
<img width="602" alt="graph3" src="https://user-images.githubusercontent.com/80138709/177958907-52bc447a-a010-4c04-8d24-eb49352399ac.png">
<img width="602" alt="graph4" src="https://user-images.githubusercontent.com/80138709/177958915-5670bcf4-a689-40f9-a843-1d634a986f9b.png">
<img width="600" alt="graph5" src="https://user-images.githubusercontent.com/80138709/177958917-008d780e-091a-4f50-adf6-dbd1e667efbd.png">
<img width="430" alt="설명" src="https://user-images.githubusercontent.com/80138709/177958920-caacc740-40a3-454d-b4e6-8771dc33e658.png">

