using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : PlayerState
{
    public PlayerHit(Player player) : base(player) { }

    private float Pc_Stiff_Time = 1f;

    public override void StateEnter()
    {
        _player.StartCoroutine(KnockBack());
        _animator.SetFloat("Speed", 0f);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateExit()
    {
        
    }

    private IEnumerator KnockBack()
    {
        _rigidBody.velocity = Vector3.zero;

        yield return new WaitForSeconds(Pc_Stiff_Time);

        _rigidBody.velocity = Vector3.zero;

        _rigidBody.angularVelocity = Vector3.zero;
        _state.ChangeState(State.Idle);
    }

    public override void InputCheck()
    {
        if (_inputSystem.IsSkill)
        {
            _state.ChangeState(State.Skill);
        }
    }
}
