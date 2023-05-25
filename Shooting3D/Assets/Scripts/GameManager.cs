using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class GameManager : SingletonMono<GameManager>
{
    //�Ŀ� �þ�� �� �ɰ������ϰ�
    //�ϴ� ���ӳ��� ��� ��ü�� �����ϴ� ���ӸŴ���
    //
    public GameObject bulletPrefab; //�Ѿ� ������    
    public Player Player { get; private set; }     //�÷��̾�
    Queue<Bullet> bulletPool = new Queue<Bullet>(); //�Ѿ� ������Ʈ Ǯ

    protected override void Init() //
    {
        base.Init();
        GameObject _obj = null;
        Bullet tempbullet =null;
        for (int i = 0; i < 20; i++) //ó�� ������ ���� ������
        {
            _obj = Instantiate(bulletPrefab);
            if (_obj.TryGetComponent<Bullet>(out tempbullet))
            {
                bulletPool.Enqueue(tempbullet);
                tempbullet.gameObject.SetActive(false); //�������ڸ��� �ϴ� ����.
            }            
        }        
    }

    
    public void Shoot()
    {
        Player.Shoot();
    }

    //�÷��̾ ��ϱ� �Ѿ��� ������ ��ġ�� �������ֱ�.
    public void CreateBullet(Transform _tr)
    {
        Bullet tempbullet = null;
        if (bulletPool.Count > 0) //������Ʈ Ǯ�� �Ѿ� ����
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
