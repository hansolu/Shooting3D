using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{ 
    public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        protected static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var obj = FindObjectOfType<T>(); //하이어라키상에 미리 만들어둔 게임매니저 객체가 이미 있을때.. 걔를 찾아라
                    if (obj != null)
                    {
                        _instance = obj;
                        _instance.Init();//
                        DontDestroyOnLoad(obj.gameObject);
                    }
                    else
                    {
                        var newObj = new GameObject(typeof(T).Name, typeof(T));
                        _instance = newObj.GetComponent<T>();
                        if (_instance == null)
                        {
                            _instance = newObj.AddComponent<T>();
                        }
                        _instance.Init();
                        DontDestroyOnLoad(newObj);
                    }
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        protected virtual void Init()
        {
        }
        public virtual void Release()
        {
        }
        public virtual void Regist() { }
    }

    public class Singleton<T> where T : Singleton<T>, new()
    {
        static T _instance = null; //static 나의 무언가 원하는 데이터형(클래스겠죠)                 

        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = new T();
                _instance.Init(); //매니저로써 필요한 뭔가 초기화
                return _instance;//나를 돌려줌
            }
        }

        //이하 선택 사항
        protected virtual void Init()
        {
        }
        public virtual void Release()
        {
        }
        public virtual void Regist()
        {
        }
    }

}