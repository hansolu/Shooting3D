using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public Enemy enemy;
    public State(Enemy _enemy)
    {
        enemy = _enemy;
    }
    public abstract void OnStateEnter();
    public abstract void OnStateStay();
    public abstract void/*bool*/ OnStateExit();
}
