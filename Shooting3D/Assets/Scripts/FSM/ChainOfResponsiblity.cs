using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChain
{
    IChain SetNext(IChain chain);
    object Handle(object request);
}

public class AbstractHandler : IChain
{
    IChain _nexthandler;
    public IChain SetNext(IChain chain)
    {
        this._nexthandler = chain;
        return chain;
    }
    public virtual object Handle(object request)
    {
        if (this._nexthandler !=null)
        {
            return this._nexthandler.Handle(request);
        }
        else
        {
            return null;
        }
    }                
}

public class AA/*���*/ : AbstractHandler
{
    public override object Handle(object request)
    {
        if (true/*request �Ǻ��ؼ� �� ���ǿ� ������*/)
        {
            //������ �ֱ�

            return true;//���ǿ� �¾����� �ൿ�ؾ��ϴ� ����;
        }
        else
            return base.Handle(request);
    }
}

public class BB/*�̵�*/ : AbstractHandler
{
    public override object Handle(object request)
    {
        if (true/*request �Ǻ��ؼ� �� ���ǿ� ������*/)
        {            
            //ĳ���Ͱ� ������
            //    �ȱ�...
            return true;//���ǿ� �¾����� �ൿ�ؾ��ϴ� ����;
        }
        else
            return base.Handle(request);
    }
}

public class CC/*����*/ : AbstractHandler
{
    public override object Handle(object request)
    {
        if (true/*request �Ǻ��ؼ� �� ���ǿ� ������*/)
        {
            return true;//���ǿ� �¾����� �ൿ�ؾ��ϴ� ����;
        }
        else
            return base.Handle(request);
    }
}

public class ChainOfResponsiblity : MonoBehaviour
{
    void Main()
    {
        var aa = new AA/*���*/();
        var bb = new BB/*�̵�*/();
        var cc = new CC/*����*/();
        //var dd = new DD/*����*/();

        aa.SetNext(bb).SetNext(cc);
    }    
}
