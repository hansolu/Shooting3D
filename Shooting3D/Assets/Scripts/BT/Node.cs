using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState //����� ����
{
    Running, //����������
    Failure, //����
    Success //����
}

public abstract class Node //��� �θ� Ŭ����
{
    protected NodeState state; //�� ����� ���� ����
    public Node parentNode; //���� ���� ����. = ����ص�.. ��������. ���� �� �ڽĵ��� ��� ���°� �����߰ų� �������� ���ư����ϰų� �ٽ� �Ǻ��� �����ϰ� ������ ��...
    protected List<Node> childrenNode = new List<Node>(); //���� �Ǻ��� �ڽĵ�

    public Node() //�ʱ�ȭ
    {
        parentNode = null;
    }   

    public Node(List<Node> children) //�ʱ�ȭ
    {
        foreach (var child in children)
        {
            AttatchChild(child);
        }
    }

    public void AttatchChild(Node child) //�Ǻ��� �ڽĳ��� �߰�
    {
        childrenNode.Add(child); //�� �ڽĵ� ����.
        child.parentNode = this; //�ڽĵ��� ��������, �ڽĵ��� �θ�� ���� ��.
    }
    
    public abstract NodeState Evaluate();//���� �Ǻ�
}