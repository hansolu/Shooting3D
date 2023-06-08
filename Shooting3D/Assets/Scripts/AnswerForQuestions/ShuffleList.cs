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
        //aaaa의 리스트를 안겹치게 랜덤으로 뽑아 섞어서 shuffle 리스트 만듦.
        List<int> aaaa = new List<int>() { 1,2,3,4,5,6}; 

        List<int> shuffle = new List<int>();

        int idx = 0;
        count = aaaa.Count;

        for (int i = 0; i < count; i++)
        {
            idx = Random.Range(0, aaaa.Count); //int기 떄문에 0에서 부터 aaaa.Count - 1 사이의 수를 추려낼 것임.
            shuffle.Add(aaaa[idx]); //순번을 추려내면 , aaaa의 idx번째 수를 Shuffle에 더함.
            aaaa.RemoveAt(idx); //그리고 이미 더했으니, 그 순번의 숫자를 없애줌.
        } //마지막에는 Random.Range지만, 무조건 0번쨰 친구를 더하게 됨.

        for (int i = 0; i < shuffle.Count; i++)
        {
            Debug.Log(shuffle[i]);
        }
    }
}
