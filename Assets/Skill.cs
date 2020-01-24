using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu]
[System.Serializable]
public class Skill : ScriptableObject
{
    public Sprite Icon;

    public float Damage;
    public Buff[] Buffs;
    public Animator animator;
    public virtual void DoSkill(Character character)
    {
        foreach (var item in Buffs)
        {
            character.Hit(Damage);
            character.AddBuff(item);
            //攻擊動畫
            //animator.SetTrigger()
            //dotween位移

        }
    }

}
public class FireBall : Skill { }
public class Meteorite : Skill { }