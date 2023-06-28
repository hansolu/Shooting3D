using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OR역할. 하나라도 오케이면 오케이
/// </summary>
public class SelectorNode : Node
{
    public SelectorNode() : base() { }

    public SelectorNode(List<Node> children) : base(children) { }

    
    public override NodeState Evaluate() //하나라도 success혹은 running이면 진행
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