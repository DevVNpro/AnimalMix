using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using Projects.Script.PvP.PlayerScript;
using UnityEngine;

namespace Projects.Script.PvP.EnemyCard
{
    public class EnemyAi : MonoBehaviour
    {
        public Transform[] cardSlots;
        [Header("BlockSpam")] 
        [SerializeField] private GameObject blockSpam;
        [SerializeField] private List<Transform> cardTarget;
        private void Start()
        {
        }
        
        [Header("Animaiton background Turn")] [SerializeField]
        private GameObject enemyTurn;
        [SerializeField]
        private GameObject playerTurn;

        public void StartAttackLoop()
        {
            cardTarget = new List<Transform>();
            foreach (Transform slot in cardSlots)
            {
                if (slot.childCount > 0)
                {
                    //test ramdomattack
                    cardTarget.Add(slot);
                }
            }
            int randomNumber = UnityEngine.Random.Range(0, cardTarget.Count);
            StartCoroutine(AttackPlayer(cardTarget[randomNumber]));
            cardTarget.Clear();
        }

        IEnumerator AttackPlayer(Transform slot)
        {
            Enemyattack.isEnemeTurn = true;
            //attack player with no damage
            Transform parentAfterDrag= transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            //move Player Position
            transform.transform.LeanMove(new Vector3(slot.position.x, slot.position.y), 0.5f).setEase(LeanTweenType.easeInBack);
            
            SoundManager.Instance.PlayVfxMuSic("Attack1");
            yield return  new WaitForSeconds(0.5f);
            transform.transform.LeanMove(new Vector3(parentAfterDrag.position.x, parentAfterDrag.position.y), 0.5f).setEase(LeanTweenType.easeInQuad);
            yield return  new WaitForSeconds(0.5f);
            //return canvas position
            transform.SetParent(parentAfterDrag);
            yield return new WaitForSeconds(2f);
            PlayerAttack.isPlayerTurn = true;
            enemyTurn.SetActive(false);
            playerTurn.SetActive(true);
            blockSpam.SetActive(false);
        }
       
    } 
}

