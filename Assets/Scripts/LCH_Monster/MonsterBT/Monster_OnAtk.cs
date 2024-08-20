using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

[TaskCategory("Monster/General")]
public class Monster_OnAtk : Action
{
    [SerializeField] SharedMonster monster;
    // Start is called before the first frame update
    Animator anim;
    AnimatorStateInfo animinfo;
    public override void OnAwake()
    {
        anim = GetComponent<Animator>();
    }

    public override void OnStart()
    {
        anim.Play("Atk");
    }
    public override TaskStatus OnUpdate()
    {
        if (monster != null)
        {
           
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Atk") == true)
            {
                animinfo = anim.GetCurrentAnimatorStateInfo(0);
                if (animinfo.normalizedTime < 0.95f)
                {
                    return TaskStatus.Running;
                }
                else
                {
                    return TaskStatus.Success;
                }
            }
            else
            {
                return TaskStatus.Running;
            }
        }
        return TaskStatus.Failure;
    }
}
