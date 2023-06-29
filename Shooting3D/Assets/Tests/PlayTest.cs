using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayTest
{    
    [UnityTest]
    public IEnumerator ShootCheck()
    {           
        var gameobj = new GameObject();
        var movesimple = gameobj.AddComponent<MoveSimple>();

        for (int i = 0; i < 100; i++)
        {            
            movesimple.vec = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            yield return new WaitForSeconds(0.2f);
        }       
        
    }
    
    [Test]
    public void TestEquals()
    {
        var gameobj = new GameObject();
        var probs = gameobj.AddComponent<Problems>();        
        Assert.AreEqual(probs.TestVal(3), 6); //같아서 True
    }
    [Test]
    public void TestNotEquals()
    {
        var gameobj = new GameObject();
        var probs = gameobj.AddComponent<Problems>();        
        Assert.AreNotEqual(probs.TestVal(3), 6
            ); //달라야 True인데 같은 값이기때문에
        //Falseㄹ를 반환함
        
    }

    [Test]
    public void MultiThreadCheck()
    {
        var gameobj = new GameObject();
        var multiCheck = gameobj.AddComponent<MultiThread>(); //실제 멀티스레드
        multiCheck.ForTestCheck();
    }
    [Test]
    public void NonMultiThreadCheck()
    {
        var gameobj = new GameObject();
        var multiCheck = gameobj.AddComponent<MultiThread_1>(); //멀티스레드 안쓴것.
        multiCheck.ForTestCheck();
    }
}
