using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public abstract class Buff : ScriptableObject
{
    public Sprite Icon;  
    public string Tooltip;
    public string Name;
    public int round;
    public string GetBuffName()
    {
        return Name;
    }
    [ShowInInspector]
    public List<(string, float)> BuffActions=new List<(string, float)>();
    protected void AddDamage( float value) => BuffActions.Add((MethodBase.GetCurrentMethod().Name, value));
    protected void AddDefense( float value) => BuffActions.Add((MethodBase.GetCurrentMethod().Name, value));
    protected void AddSeppd( float value) => BuffActions.Add((MethodBase.GetCurrentMethod().Name, value));  

    protected virtual void SetRound(int i) {
        round = i;
    }
    public int GetRound() {
      return round;
    }
    public void SubtractionRound() {
        round--;
    }

    public List<(string, float)> GetBuffList() {
        return new List<(string, float)>(BuffActions);
    }

    public abstract void SetBuffActions();

}
