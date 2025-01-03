using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("Monster/General")]
public class Monster_Idle : Action
{

    [SerializeField] SharedMonster Monster;
    [SerializeField] SharedNavmesh Nav;
    public override TaskStatus OnUpdate()
    {
        Vector3 ownerPos = Owner.transform.position;
        var targetTrans = Monster.Value.Player.transform;
        Vector3 targetPos = targetTrans.position;

        float distance = Vector3.Distance(ownerPos, targetPos);
        
        
        if (distance >= Monster.Value.Mon_Common_DetectArea)
        {
            Nav.Value.SetDestination(Owner.transform.position);
            return TaskStatus.Running;

        }
        return TaskStatus.Success;
    }
}
