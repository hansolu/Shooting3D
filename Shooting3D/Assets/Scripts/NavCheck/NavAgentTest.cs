using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentTest : MonoBehaviour
{
    public Transform patrolParent; //�������� ��Ƶ� ������ �θ�
    Transform[] patrolPoints; //�������� �迭
    NavMeshAgent agent;
    int patrolNum = 0;
    int area_water = 3;
    float percent = 0;
    float time = 0; //ī��Ʈ�� Ÿ��
    
    Vector3 startpos, endpos = Vector3.zero;
    RaycastHit hit;
    Coroutine cor = null;

    //void Awake() //��ǲ�Ŵ��� ���ϴ� ����� ����.
    //{
    //    InputManager.Instance.AddFunction(KeyCode.Space, AA );
    //}
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolPoints = new Transform[patrolParent.childCount];
        for (int i = 0; i < patrolParent.childCount; i++)
        {
            patrolPoints[i] = patrolParent.GetChild(i); //�������� ����
        }
        agent.autoBraking = false;
        patrolNum = 0;
        cor = null;
        //GoToNextPoint();                
    }
    //public void AA() //��ǲ�Ŵ��� ���ϴ� ����� ����.
    //{
    //    StartCoroutine(MoveMeshLink());
    //}

    void GoToNextPoint() //����
    {
        //agent.SetDestination(patrolPoints[patrolNum].position);//���������� �������� ����.
        agent.destination =patrolPoints[patrolNum].position;//���������� �������� ����.
        //patrolNum++;
        //if (patrolNum >= patrolPoints.Length)
        //{
        //    patrolNum = 0;
        //}

        patrolNum = (patrolNum + 1) % patrolPoints.Length; //�� ����Ʈ�� 5�� �����ϸ�, 4��° ���迭���� 1�������� 5�� 5/5�� �������� 0�̴ϱ� �ٽ� 0������ ���� ��������.
        //agent.destination
    }

    void Update()
    {
        //if(agent.velocity.sqrMagnitude >= 0.5f && (agent.destination - transform.position).sqrMagnitude <= 0.5f ) //�������µ� 0
        //{
        //    GoToNextPoint();
        //}     

        if (Input.GetMouseButtonDown(0))  //���� Ŭ����
        {
            agent.isStopped = true;
            if (Physics.Raycast( //���̸� ����
                Camera.main.ScreenPointToRay(Input.mousePosition), //ī�޶��� ���콺�� Ŭ���� �������κ��� ���̰� ������ ���̸� ��
                out hit, float.PositiveInfinity))
            {
                agent.isStopped = false;//������ agent.isstopped�� ������ �ݵ�� false�� Ǯ����� ���ο� �̵�����
                agent.SetDestination(hit.point); //���̿� �ɸ��� ������ �� ����Ʈ�� agent�̵�.                
            }                                    
        }

        if (agent.isOnOffMeshLink)//���� �� ������Ʈ�� ��ġ�� OffMeshLink�� �ִ��� üũ.
        {
            if (cor !=null)
            {
                StopCoroutine(cor);
                cor = null;
            }
            cor = StartCoroutine(MoveMeshLink());
        }
    }    


    IEnumerator MoveMeshLink()
    {               
        OffMeshLinkData data = agent.currentOffMeshLinkData; //���� ��ġ�� �����޽ø�ũ ����Ÿ �޾ƿ�
        if (data.offMeshLink != null/*���� �������� ���� �����޽ø�ũ ���� üũ*/ 
            /*&& data.offMeshLink.area == locked && ���踦 ȹ���ߴ��� Ȥ�� ��ٸ��� ȹ���ߴ���...*/) 
        {
            startpos = data.startPos; //
            endpos = data.endPos;
            percent = 0;

            while (true)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(startpos, endpos, time);
                
                if ((endpos - transform.position).sqrMagnitude <= 0.1f)
                {
                    transform.position = endpos;
                    agent.CompleteOffMeshLink();//
                    agent.isStopped = false;
                    cor = null;
                    yield break;
                }
                yield return null;
            }
        }
    }
}
