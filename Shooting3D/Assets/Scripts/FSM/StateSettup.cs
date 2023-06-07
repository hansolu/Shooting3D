using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSettup 
{    
   
    public static Dictionary<StateEnum, State> GetDefaultEnemyState(Enemy _enemy)
    {
        return new Dictionary<StateEnum, State>()
        {
        { StateEnum.Idle, new State_Idle(_enemy) },
        { StateEnum.Attack, new State_Attack(_enemy) },
        };
    }

}
