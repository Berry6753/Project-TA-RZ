using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonExplosionRedChip : BlueChip
{
    private Vector3 _forward;
    private Vector3 _additionalPosition;

    public override void InitializeBlueChip(BlueChipSystem blueChipSystem, PC_BlueChip data)
    {
        _blueChipSystem = blueChipSystem;

        _data = data;

        _currentPower = _data.Att_damage;

        _targetLayer = LayerMask.GetMask("Monster");

        _additionalPosition = new Vector3(0f, 1f, 0.5f);
    }
    public override void SetEffectObject(GameObject effectObject)
    {
        _effectObject = effectObject;
    }

    public override void ResetSystem()
    {
        _poolManager.AllDestroyObject(_effectObject);
    }
    
    public override void LevelUpBlueChip()
    {
        return;
    }

    public override void UseBlueChip(Transform transform, AttackType currentAttackType, bool isStart = true)
    {
        if(currentAttackType is AttackType.fourthAttack)
        {
            return;
        }

        PoisonExplosion(transform);
    }

    private void PoisonExplosion(Transform transform)
    {
        GameObject poisonObject = _poolManager.DequeueObject(_effectObject);

        PoisonObject objectComponent = poisonObject.GetComponent<PoisonObject>();

        objectComponent.SetObjectData(_data.Chip_AttackArea, _currentPower, _targetLayer);

        _forward = transform.forward;

        Vector3 objectPosition = transform.position + transform.TransformDirection(_additionalPosition) + _forward;

        poisonObject.transform.position = objectPosition;

        objectComponent.StartPoison(PoisonAttackType.Explosive);
    }
}
