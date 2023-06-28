using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AND ����. �ϳ��� False�� False
/// </summary>
public class SequenceNode : Node
{    
    public SequenceNode() : base() { }

    public SequenceNode(List<Node> children) : base(children) { }

    public override NodeState Evaluate() //�ϳ��� ���ж�� ����.
    {
        bool bNowRunning = false;
        foreach (Node node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case NodeState.Failure:                    
                    return state = NodeState.Failure;
                
                case NodeState.Success:
                    continue;
                case NodeState.Running:
                    bNowRunning = true;
                    continue;
                default:
                    continue;
            }
        }

        return state = bNowRunning ? NodeState.Running : NodeState.Success;
    }
}
