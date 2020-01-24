using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public Character[] Player;
    public Character[] Enemy;
     List<Character> AllSort;
    public int CharacterId;
    // Start is called before the first frame update
    void Start()
    {
        AllSort.AddRange(Player);
        AllSort.AddRange(Enemy);
        AllSort.GroupBy(x => x.Speed);
        foreach (var item in AllSort)
        {
            //對 Character Set 自己
            item.SetGameManager(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextCharacter() {
        if (CharacterId % AllSort.Count - 1 == 0) {
            //New Round
            foreach (var item in AllSort)
            {
                item.DoBuffsAction();
            }
        }
        AllSort[CharacterId % AllSort.Count-1].MyTurn();
    }
}
