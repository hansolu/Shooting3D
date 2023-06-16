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
