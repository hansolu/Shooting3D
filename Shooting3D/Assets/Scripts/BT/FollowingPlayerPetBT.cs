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

//    void Update() //���� ��ũ��Ʈ�� �ʿ��� ���
//    {
//        Tree.Evaluate();
//    }
//    //    //NPC�ν� ���� �ִ� ���~~~

//    //    protected override Node SetupBehaviorTree() //�ݵ�� �����ʿ�
//    //    {
//    //        //��ü������ �Ǻ� = OR����
//    //        Node root = new SelectorNode(new List<Node>
//    //        {
//    //            //���������� �÷��̾ ������������=> ��ٸ��� �� AND�������� ����. 
//    //            new SequenceNode(new List<Node>
//    //            {
//    //                new CheckPlayerIsNear(pet),
//    //                new StayNearPlayer(pet)
//    //            }),
//    //            new GoToPlayer(player, pet)
//    //        });
//    //        return root; //�ݵ�� ��Ʈ ��� ��ȯ.
//    //    }
//}

public class FollowingPlayerPetBT : BehaviorTree
{
    [SerializeField]
    private Transform player;//�÷��̾�����
    [SerializeField]
    private Transform pet; // = ������

    protected override Node SetupBehaviorTree()
    {
        //��ü������ �Ǻ� = OR����
        Node root = new SelectorNode(new List<Node>
        {
            //���������� �÷��̾ ������������=> ��ٸ��� �� AND�������� ����. 
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
