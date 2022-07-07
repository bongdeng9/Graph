using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Program
    {
        // 스택 : LIFO (Last In First Out) 후입선출
        // 큐 : FIFO (First In First Out) 선입선출
        // 동적 배열 / 연결리스트처럼 중간에 있는 놈은 나갈 수 없음
        // 스택과 큐를 만든 이유 : 추상적으로 사용할 때 편함.
        // 의사소통 / 정신건강에 좋음.
        // 기존에 배운 연결리스트 동적배열의 축소판.
        // 큐는 순환 버퍼를 사용해서 만든다.
        // 배열 동적배열을 사용해서 관리하는 건 맞음
        // 근데 실제로 이사를 시키는 게 아니라 시작 되는 지점을 추적하는데,
        // 그냥 시작되는 지점을 한칸 옮겨서 2번부터 시작하는 느낌적인 느낌
        // 자세한건 구글에 있습니다.

        static void Main(string[] args)
        {

            // 스택 : 
            // 팝업창 ! 
            // 중첩되서 팝업이 뜰 때, 후입선출 개념.
            // 마지막으로 띄운 ui 가 먼저 꺼져야됨.
            
            // 큐 : 네트워크 패킷을 보낼 때
            // 이용자가 옆에 있는 몬스터를 때리고 싶다고 서버에 요청
            // 수만명의 유저가 동시에 보내면,
            // 동시에 실행하기 어려울 때
            // 줄을 세워서 순차적으로 실행.
            // 이때 큐가 유용함.
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            stack.Push(101);
            stack.Push(102);
            stack.Push(103);
            stack.Push(104);
            stack.Push(105);

            int data = stack.Pop();
            int data2 = stack.Peek();

            queue.Enqueue(101);
            queue.Enqueue(102);
            queue.Enqueue(103);
            queue.Enqueue(104);
            queue.Enqueue(105);

            int data3 = queue.Dequeue();
            int data4 = queue.Peek();

        }
    }
}
