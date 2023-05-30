using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentTest : MonoBehaviour
{
    public Transform patrolParent; //정찰지점 모아둔 묶음의 부모
    Transform[] patrolPoints; //정찰지점 배열
    NavMeshAgent agent;
    int patrolNum = 0;
    int area_water = 3;
    float percent = 0;
    float time = 0; //카운트할 타임
    
    Vector3 startpos, endpos = Vector3.zero;
    RaycastHit hit;
    Coroutine cor = null;

    //void Awake() //인풋매니저 더하는 경우의 샘플.
    //{
    //    InputManager.Instance.AddFunction(KeyCode.Space, AA );
    //}
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolPoints = new Transform[patrolParent.childCount];
        for (int i = 0; i < patrolParent.childCount; i++)
        {
            patrolPoints[i] = patrolParent.GetChild(i); //정찰지점 세팅
        }
        agent.autoBraking = false;
        patrolNum = 0;
        cor = null;
        //GoToNextPoint();                
    }
    //public void AA() //인풋매니저 더하는 경우의 샘플.
    //{
    //    StartCoroutine(MoveMeshLink());
    //}

    void GoToNextPoint() //정찰
    {
        //agent.SetDestination(patrolPoints[patrolNum].position);//정찰지점을 목적지로 세팅.
        agent.destination =patrolPoints[patrolNum].position;//정찰지점을 목적지로 세팅.
        //patrolNum++;
        //if (patrolNum >= patrolPoints.Length)
        //{
        //    patrolNum = 0;
        //}

        patrolNum = (patrolNum + 1) % patrolPoints.Length; //총 포인트가 5개 존재하면, 4번째 ㅁ배열에서 1더했을때 5고 5/5의 나머지는 0이니까 다시 0번부터 순찰 가능해짐.
        //agent.destination
    }

    void Update()
    {
        //if(agent.velocity.sqrMagnitude >= 0.5f && (agent.destination - transform.position).sqrMagnitude <= 0.5f ) //정지상태도 0
        //{
        //    GoToNextPoint();
        //}     

        if (Input.GetMouseButtonDown(0))  //왼쪽 클릭시
        {
            agent.isStopped = true;
            if (Physics.Raycast( //레이를 쏴서
                Camera.main.ScreenPointToRay(Input.mousePosition), //카메라의 마우스가 클릭한 지점으로부터 길이가 무한인 레이를 쏨
                out hit, float.PositiveInfinity))
            {
                agent.isStopped = false;//이전에 agent.isstopped를 했으면 반드시 false로 풀어줘야 새로운 이동가능
                agent.SetDestination(hit.point); //레이에 걸린게 있으면 그 포인트로 agent이동.                
            }                                    
        }

        if (agent.isOnOffMeshLink)//현재 내 에이전트의 위치가 OffMeshLink에 있는지 체크.
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
        OffMeshLinkData data = agent.currentOffMeshLinkData; //현재 위치의 오프메시링크 데이타 받아옴
        if (data.offMeshLink != null/*내가 수동으로 만든 오프메시링크 인지 체크*/ 
            /*&& data.offMeshLink.area == locked && 열쇠를 획득했는지 혹은 사다리를 획득했는지...*/) 
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
