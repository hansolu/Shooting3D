using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class SavePosition : MonoBehaviour
{
    //������ ���� ������ ��� ������ �ִٴ� �����Ͽ� => �� ������ ������ index�� ���ٰ���.

    //�κ��丮 => ���� ��ȣ, ������ ����(�ε���), ������ �������� / �׿� �������� ������...

    //Path.Combine(Application.dataPath, "dataPath.txt"); //������ �������� Data���� ��.... => ���⿡ �����ϴ°��� ���� ����        


    //��ư ���̽� ��ġ = ����Ƽ ��Ű�� �Ŵ������� ���� ��� �÷���(���ϱ� ǥ�� ) Ŭ���Ͽ� add package by name���� => com.unity.nuget.newtonsoft-json   �Է��Ͽ� ��ġ
    //��ġ �Ϸ��� using Newtonsoft.Json; ���ָ� ��밡��.

    void Start()
    {
        AAA aa = new AAA();
        aa.datas = new List<SlotData>() { new SlotData(1,1), new SlotData(2, 2) };
        string str = JsonConvert.SerializeObject(aa /*������ Ŭ����~*/, Formatting.Indented);
        Debug.Log(str);
    }
}

public class AAA
{
    public List<SlotData> datas = new List<SlotData>();
}
public class SlotData
{
    public int Index; //���� ��ȣ //���� ����Ʈ�� �ݵ�� ������� �ִٸ�. ���߰��� �� ������ ���ٸ�� ���� ��� �ǰ�����...
    public int ItemIndex;//������ �ε�����ȣ
    public int ItemCount; //�� ���Կ� ����ִ� ������ ����
    public SlotData(int index, int count)
    {
        Index = index;
        ItemCount = count;
    }
}
