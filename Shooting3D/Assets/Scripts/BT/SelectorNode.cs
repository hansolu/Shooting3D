using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OR����. �ϳ��� �����̸� ������
/// </summary>
public class SelectorNode : Node
{
    public SelectorNode() : base() { }

    public SelectorNode(List<Node> children) : base(children) { }

    
    public override NodeState Evaluate() //�ϳ��� successȤ�� running�̸� ����
    {
        foreach (Node node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case NodeState.Failure:
                    continue;
                case NodeState.Success:
                    return state = NodeState.Success;
                case NodeState.Running:
                    return state = NodeState.Running;
                default:
                    continue;
            }
        }

        return state = NodeState.Failure;
    }
}