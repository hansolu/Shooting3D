using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class GameManager : SingletonMono<GameManager>
{
    //후에 늘어나면 또 쪼개도록하고
    //일단 게임내의 모든 객체를 관리하는 게임매니저
    //
    public GameObject bulletPrefab; //총알 프리팹    
    public Player Player { get; private set; }     //플레이어
    Queue<Bullet> bulletPool = new Queue<Bullet>(); //총알 오브젝트 풀

    protected override void Init() //
    {
        base.Init();
        GameObject _obj = null;
        Bullet tempbullet =null;
        for (int i = 0; i < 20; i++) //처음 스무발 정도 만들어둠
        {
            _obj = Instantiate(bulletPrefab);
            if (_obj.TryGetComponent<Bullet>(out tempbullet))
            {
                bulletPool.Enqueue(tempbullet);
                tempbullet.gameObject.SetActive(false); //생성하자마자 일단 꺼둠.
            }            
        }        
    }

    
    public void Shoot()
    {
        Player.Shoot();
    }

    //플레이어만 쏘니까 총알이 생성될 위치만 전달해주기.
    public void CreateBullet(Transform _tr)
    {
        Bullet tempbullet = null;
        if (bulletPool.Count > 0) //오브젝트 풀에 총알 존재
        {
            tempbullet = bulletPool.Dequeue();
            tempbullet.gameObject.SetActive(true);
            tempbullet.SetInit(_tr);
        }
        else
        {
            GameObject _obj = Instantiate(bulletPrefab);
            if (_obj.TryGetComponent<Bullet>(out tempbullet))
            {
                tempbullet.SetInit(_tr);
            }
        }
    }
    public void ReturnBullet(Bullet _bullet)
    {
        bulletPool.Enqueue(_bullet);
        _bullet.gameObject.SetActive(false);
    }

    public void SetPlayer(Player player)
    {
        this.Player = player;
    }
        
}
