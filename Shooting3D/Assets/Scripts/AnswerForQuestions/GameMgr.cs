using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private static GameMgr instance = null;    
    public static GameMgr Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = new GameMgr();                
                return null;
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else //�̹� instance�� �����Ѵٸ�
        {
            Destroy(this.gameObject);
        }        
    }              
}

//�̱��� ����
public class Singletonn<T> : MonoBehaviour where T : Singletonn<T>
{
    public static Singletonn<T> Instance = null;

    void Awake() //����Ƽ���� ���ص� �Լ�����...
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        Init();
    }

    public virtual void Init()
    {
    }
}

public class AA2 : Singletonn<AA2>
{
    public override void Init()
    {
        //�ؾ��Ұ�...
    }
}