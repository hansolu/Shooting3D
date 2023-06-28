using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState //노드의 상태
{
    Running, //실행중인지
    Failure, //실패
    Success //성공
}

public abstract class Node //노드 부모 클래스
{
    protected NodeState state; //이 노드의 지금 상태
    public Node parentNode; //나의 위의 상태. = 기록해둘.. 이전상태. 뭔가 내 자식들의 모든 상태가 실패했거나 이전으로 돌아가야하거나 다시 판별을 시작하고 싶을때 등...
    protected List<Node> childrenNode = new List<Node>(); //상태 판별할 자식들

    public Node() //초기화
    {
        parentNode = null;
    }   

    public Node(List<Node> children) //초기화
    {
        foreach (var child in children)
        {
            AttatchChild(child);
        }
    }

    public void AttatchChild(Node child) //판별할 자식노드들 추가
    {
        childrenNode.Add(child); //내 자식들 세팅.
        child.parentNode = this; //자식들이 생겼으니, 자식들의 부모는 내가 됨.
    }
    
    public abstract NodeState Evaluate();//상태 판별
}