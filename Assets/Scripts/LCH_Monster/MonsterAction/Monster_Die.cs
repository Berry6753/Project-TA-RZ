using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Monster/General")]
public class Monster_Die : Action
{
    public override TaskStatus OnUpdate()
    {
        
        return TaskStatus.Success;
    }
}