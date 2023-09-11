using System.Collections;
using Coffee.UIEffects;
using Projects.Script.PvP.EnemyCard;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.PvP.PlayerScript
{
    public class PlayerAttack : DamageSender
    {
        public static bool isPlayerTurn;


        private void Start()
        {
            isPlayerTurn = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isPlayerTurn&& other.CompareTag("Enemy"))
            {
                isPlayerTurn = false;
                Settrigger(other);
            }
        }

        

    }
}
