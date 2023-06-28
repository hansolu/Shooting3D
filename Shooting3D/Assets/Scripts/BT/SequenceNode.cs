using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AND 조건. 하나라도 False면 False
/// </summary>
public class SequenceNode : Node
{    
    public SequenceNode() : base() { }

    public SequenceNode(List<Node> children) : base(children) { }

    public override NodeState Evaluate() //하나라도 실패라면 실패.
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
