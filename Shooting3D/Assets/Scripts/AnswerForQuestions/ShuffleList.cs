using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleList : MonoBehaviour
{
    int count = 0;
    void Start()
    {
        AA();
    }
    void AA()
    {
        //aaaa�� ����Ʈ�� �Ȱ�ġ�� �������� �̾� ��� shuffle ����Ʈ ����.
        List<int> aaaa = new List<int>() { 1,2,3,4,5,6}; 

        List<int> shuffle = new List<int>();

        int idx = 0;
        count = aaaa.Count;

        for (int i = 0; i < count; i++)
        {
            idx = Random.Range(0, aaaa.Count); //int�� ������ 0���� ���� aaaa.Count - 1 ������ ���� �߷��� ����.
            shuffle.Add(aaaa[idx]); //������ �߷����� , aaaa�� idx��° ���� Shuffle�� ����.
            aaaa.RemoveAt(idx); //�׸��� �̹� ��������, �� ������ ���ڸ� ������.
        } //���������� Random.Range����, ������ 0���� ģ���� ���ϰ� ��.

        for (int i = 0; i < shuffle.Count; i++)
        {
            Debug.Log(shuffle[i]);
        }
    }
}
