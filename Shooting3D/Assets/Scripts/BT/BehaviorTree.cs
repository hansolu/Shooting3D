using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorTree : MonoBehaviour
{    
    Node rootNode;//���� ���� �θ�. �� �����Ǻ����� ����
    protected void Start()
    //public void Init()
    {
        rootNode = SetupBehaviorTree();
    }

    protected void Update()
    //public void Evaluate()
    {
        if (rootNode == null)
        {
            return;
        }
        rootNode.Evaluate();
    }
    protected abstract Node SetupBehaviorTree();
}
