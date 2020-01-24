using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine.UI;
public class Character : MonoBehaviour
{

    public Image UI_Health;

    GameManager manager;
      public void SetGameManager(GameManager gameManager) {
        manager = gameManager;
    }
    public int SkillSelectID;
    public float OriginDamage, Damage, OriginDefense, Defense;
    public float MaxHealth, Health;
    public float OriginSpeed, Speed;

    public Skill[] Skills;
    public Dictionary<string, Buff> buffs = new Dictionary<string, Buff>();

    private void Start()
    {
        Damage = OriginDamage;
        Defense = OriginDamage;
        Health = MaxHealth;
        Speed = OriginSpeed;
    }


  
    [Button]
    public void AddBuff(Buff buff)
    {
        if (buff.GetRound() <= 0) { return; }
        buffs.Add(buff.GetBuffName(), buff);
    }
    public void UI_HealthUpdate() { 
    //DoTween 血量動畫
    }
    public void Hit(float damage) {
        Health -= damage;
        Health= Mathf.Max(0, Health);
        UI_HealthUpdate();
        if (Health == 0) {
            Dead();
        }
    }
    public void Dead() {
        //死亡動畫
        
    }
    [Button]
    public void DoBuffsAction()
    {
        //狀態回合數結束
        List<(string, float)> tempList = new List<(string, float)>();

        var zeroRoundBuffs= buffs.Where(x=>x.Value.GetRound()<=0).ToDictionary(x => x.Key, x => x.Value);
        for (int i = 0; i < zeroRoundBuffs.Count; i++)
        {
            tempList = buffs.ElementAt(i).Value.GetBuffList();
         
            for (int j = 0; j < tempList.Count; j++)
            {
            
                Type t = this.GetType();
                MethodInfo method = t.GetMethod(tempList[j].Item1, BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic);
                print(method.Name);
                method.Invoke(this, new object[] {0});
            }
        }

     
        //獲得新狀態
        buffs = buffs.Where(x => x.Value.GetRound() > 0).ToDictionary(x => x.Key, x => x.Value);    
      
        for (int i = 0; i < buffs.Count; i++)
        {
            tempList = buffs.ElementAt(i).Value.GetBuffList();
            for (int j = 0; j < tempList.Count; j++)
            {
                Type t = this.GetType();
                MethodInfo method = t.GetMethod(tempList[j].Item1,BindingFlags.Instance| BindingFlags.DeclaredOnly|BindingFlags.NonPublic);
                print(method.Name);
                method.Invoke(this, new object[] { tempList[j].Item2});
            }

            buffs.ElementAt(i).Value.SubtractionRound();
        }

    }
   
    public void BuffsIconUpdate()
    {
        //狀態ICON更新


    }

    public void SkillIconUpdate() {
        //技能ICON更新
    }

    public void Attack(Character character) {
        Skills[SkillSelectID].DoSkill(character);
        
    }

    public 
  
    void AddDamage(float value) => Damage = OriginDamage + value;
    void AddDefense(float value) => Defense = OriginDefense + value;
    void AddSeppd(float value) => Speed = OriginSpeed + value;

    public void MyTurn() {
        BuffsIconUpdate();
        SkillIconUpdate();
    }
    //玩家手動按下結束回合
    public void NextRound()
    {
       // DoBuffsAction();
        manager.NextCharacter();
    }
}

