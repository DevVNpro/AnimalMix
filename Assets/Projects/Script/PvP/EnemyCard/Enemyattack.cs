using Coffee.UIEffects;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.PvP.EnemyCard
{
   public class Enemyattack : DamageSender
   {
      public static bool isEnemeTurn;

      private void Start()
      {
         isEnemeTurn = false;
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
         if (isEnemeTurn)
         {
            isEnemeTurn = false; 
            Settrigger(other); 
         }
      }

    
   
   }
}
