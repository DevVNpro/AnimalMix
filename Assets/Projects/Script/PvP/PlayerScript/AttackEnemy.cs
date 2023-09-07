using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Script.PvP;
using Projects.Script.PvP.EnemyCard;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackEnemy : MonoBehaviour
{
    public static bool IsPlayerTurn;


    private void Start()
    {
        IsPlayerTurn = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPlayerTurn&& other.CompareTag("Enemy"))
        {
            IsPlayerTurn = false;
            Settrigger(other);
        }
    

        
    }

    public void Settrigger(Collider2D other)
    {
       
        int health = other.GetComponent<Card>().attack;
        int attack = transform.GetComponent<Card>().attack;
        if (attack >= health)
        {
            StartCoroutine(DeductAttack(other));
        }
        else
        {
            other.transform.Find("TextReceiver").GetComponentInChildren<ShowDamageReceiver>().StartShow(attack);
            health -= attack;
        }
 
        other.GetComponent<Card>().attack = health;
    }

    IEnumerator DeductAttack(Collider2D other)
    {
        other.transform.Find("TextReceiver").GetComponentInChildren<ShowDamageReceiver>().StartShow(other.GetComponent<Card>().attack);
        yield return new WaitForSeconds(0.2f);
        other.GetComponent<Card>().attack = 0;
        yield return new WaitForSeconds(1.5f);
        other.transform.LeanScale(new Vector3(0f, 0f), 2.3f).setEase((LeanTweenType.easeOutElastic));
        other.transform.SetParent(transform.root);
    }
}
