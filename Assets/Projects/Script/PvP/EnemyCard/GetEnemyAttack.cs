using Projects.Script.PvP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemyAttack : MonoBehaviour
{
    public List<Transform> enemyList;
  
     public void NewListEnemy()
    {
        enemyList.Clear();
        enemyList = new List<Transform>();
    }
    public void AddEnemyToList(Transform newEnemy)
    {
        enemyList.Add(newEnemy);
    }

    public Transform GetEnemyAttackMax()
    {
        int maxAttack = 0;
        for(int i = 0; i< enemyList.Count; i++)
        {
            if(enemyList[i].GetComponentInChildren<Card>().attack > maxAttack)
            {
                maxAttack = enemyList[i].GetComponentInChildren<Card>().attack;
            }
        }
        for(int i = 0; i< enemyList.Count; i++)
        {
            if (enemyList[i].GetComponentInChildren<Card>().attack == maxAttack)
            {
                return enemyList[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
