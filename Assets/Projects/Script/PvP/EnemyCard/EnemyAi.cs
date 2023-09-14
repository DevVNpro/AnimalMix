using System;
using System.Collections;
using Projects.Script.Manager;
using Projects.Script.PvP.PlayerScript;
using UnityEngine;

namespace Projects.Script.PvP.EnemyCard
{
    public class EnemyAi : MonoBehaviour
    {
        public Transform[] cardSlots;
        private Transform _transform;
        [Header("BlockSpam")] 
        [SerializeField] private GameObject blockSpam;
        private void Start()
        {
            _transform = this.transform;
        }
        
        [Header("Animaiton background Turn")] [SerializeField]
        private GameObject enemyTurn;
        [SerializeField]
        private GameObject playerTurn;

        public void StartAttackLoop()
        {
            foreach (Transform slot in cardSlots)
            {
                if (slot.childCount > 0)
                {
                    StartCoroutine(AttackPlayer(slot));
                    break;
                }
            }
        }

        IEnumerator AttackPlayer(Transform slot)
        {
            Enemyattack.isEnemeTurn = true;
            //attack player with no damage
            /*Transform parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            Debug.Log(Enemyattack.isEnemeTurn);
            transform.LeanMove(new Vector3(slot.position.x, slot.position.y), 1.7f).setEasePunch();*/
            Transform parentAfterDrag= transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            //move Player Position
            transform.transform.LeanMove(new Vector3(slot.position.x, slot.position.y), 0.5f).setEase(LeanTweenType.easeInBack);
            
            SoundManager.Instance.PlayVfxMuSic("Attack1");
            /*yield return new WaitForSeconds(1.8f);
            transform.LeanMove(new Vector3(_transform.position.x, _transform.position.y), 1f);
            transform.SetParent(parentAfterDrag);
            yield return new WaitForSeconds(1f);*/
            yield return  new WaitForSeconds(0.5f);
            transform.transform.LeanMove(new Vector3(parentAfterDrag.position.x, parentAfterDrag.position.y), 0.5f).setEase(LeanTweenType.easeInQuad);
            yield return  new WaitForSeconds(0.5f);
            //return canvas position
            transform.SetParent(parentAfterDrag);

            //re-enable the player's damage condition, so as not to confuse damage when the player attacks or the enemy attacks
            yield return new WaitForSeconds(2f);
            PlayerAttack.isPlayerTurn = true;
            enemyTurn.SetActive(false);
            playerTurn.SetActive(true);
            blockSpam.SetActive(false);
        }
       
    } 
}

