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
        else //이미 instance가 존재한다면
        {
            Destroy(this.gameObject);
        }        
    }              
}

//싱글톤 유의
public class Singletonn<T> : MonoBehaviour where T : Singletonn<T>
{
    public static Singletonn<T> Instance = null;

    void Awake() //유니티에서 정해둔 함수지만...
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
        //해야할거...
    }
}