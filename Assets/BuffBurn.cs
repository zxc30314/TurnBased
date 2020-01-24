using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu]
public class BuffBurn : Buff
{
 
    [Button]
    public override void SetBuffActions()
    {
        base.SetRound(3);
        AddDefense(-10);
        AddDamage(-5);
    }
}
