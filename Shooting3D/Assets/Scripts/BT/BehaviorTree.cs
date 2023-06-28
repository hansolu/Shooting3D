using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorTree : MonoBehaviour
{    
    Node rootNode;//가장 상위 부모. 내 상태판별기의 메인
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
