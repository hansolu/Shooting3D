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

public class AA/*대기*/ : AbstractHandler
{
    public override object Handle(object request)
    {
        if (true/*request 판별해서 뭐 조건에 맞으면*/)
        {
            //가만히 있기

            return true;//조건에 맞았을때 행동해야하는 무언가;
        }
        else
            return base.Handle(request);
    }
}

public class BB/*이동*/ : AbstractHandler
{
    public override object Handle(object request)
    {
        if (true/*request 판별해서 뭐 조건에 맞으면*/)
        {            
            //캐릭터가 움직임
            //    걷기...
            return true;//조건에 맞았을때 행동해야하는 무언가;
        }
        else
            return base.Handle(request);
    }
}

public class CC/*전투*/ : AbstractHandler
{
    public override object Handle(object request)
    {
        if (true/*request 판별해서 뭐 조건에 맞으면*/)
        {
            return true;//조건에 맞았을때 행동해야하는 무언가;
        }
        else
            return base.Handle(request);
    }
}

public class ChainOfResponsiblity : MonoBehaviour
{
    void Main()
    {
        var aa = new AA/*대기*/();
        var bb = new BB/*이동*/();
        var cc = new CC/*공격*/();
        //var dd = new DD/*죽음*/();

        aa.SetNext(bb).SetNext(cc);
    }    
}
