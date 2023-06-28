using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class NPC : MonoBehaviour //BehaviorTree
//{
//    BehaviorTree Tree;
//    void Start()
//    {
//        Tree = new BehaviorTree();            
//    }

//    void Update() //원래 스크립트에 필요할 경우
//    {
//        Tree.Evaluate();
//    }
//    //    //NPC로써 원래 있던 기능~~~

//    //    protected override Node SetupBehaviorTree() //반드시 구현필요
//    //    {
//    //        //전체적으로 판별 = OR상태
//    //        Node root = new SelectorNode(new List<Node>
//    //        {
//    //            //내부적으로 플레이어가 가까운상태인지=> 기다리기 는 AND조건으로 묶음. 
//    //            new SequenceNode(new List<Node>
//    //            {
//    //                new CheckPlayerIsNear(pet),
//    //                new StayNearPlayer(pet)
//    //            }),
//    //            new GoToPlayer(player, pet)
//    //        });
//    //        return root; //반드시 루트 노드 반환.
//    //    }
//}

public class FollowingPlayerPetBT : BehaviorTree
{
    [SerializeField]
    private Transform player;//플레이어정보
    [SerializeField]
    private Transform pet; // = 내정보

    protected override Node SetupBehaviorTree()
    {
        //전체적으로 판별 = OR상태
        Node root = new SelectorNode(new List<Node>
        {
            //내부적으로 플레이어가 가까운상태인지=> 기다리기 는 AND조건으로 묶음. 
            new SequenceNode(new List<Node>
            {
                new CheckPlayerIsNear(pet),
                new StayNearPlayer(pet)
            }),
            new GoToPlayer(player, pet)
        });
        return root;
    }
}
