using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using Projects.Script.PvP.EnemyCard;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.PvP.PlayerScript
{
    public class CardOnClick : MonoBehaviour
    {
        [Header("ButtonEnemy")] 
        [SerializeField]
        private PositionEnemyClick positionEnemyClick;

        [Header("List slot")] [SerializeField] private List<GameObject> listSlot;

        [Header("Onclick Listcard")]
        [SerializeField]
        private Transform Slot1;
        [SerializeField]
        private Transform Slot2;
        [SerializeField]
        private Transform Slot3;
        
        //enemyList Position
        [Header("EnemyCard")]
        [SerializeField] private Transform[] EnemyCards;
        private Transform transformButton;
        public bool  isMoving = false;
        
        [Header("BlockSpam")] 
         public  GameObject blockSpam;

         [Header("Animaiton background Turn")]
         [SerializeField]
         private GameObject enemyTurn;
         [SerializeField]
         private GameObject playerTurn;

        private void Start()
        {
            CheckListSlot();
        }

        private void CheckListSlot()
        {
            foreach (GameObject slot in listSlot)
            {
                int slotIndex = listSlot.IndexOf(slot);

                if (slot.transform.childCount > 0)
                {

                    if (slotIndex == 0)
                    {
                        slot.GetComponentInChildren<Button>().onClick.AddListener(OnClickCard1);
                    }
                    else if (slotIndex == 1)
                    {
                        slot.GetComponentInChildren<Button>().onClick.AddListener(OnClickCard2);

                    }
                    else if (slotIndex == 2)
                    {
                        slot.GetComponentInChildren<Button>().onClick.AddListener(OnClickCard3);


                    }
                }
                
            }
            
            
        }

  

        public void OnClickCard1()
        {

            if (!isMoving && positionEnemyClick.transformEnemy != Vector3.zero && positionEnemyClick.targetEnemy.GetComponent<Card>().attack>0)
            {
                transformButton = Slot1.GetComponentInChildren<Button>().transform;
                blockSpam.SetActive(true);
                StartCoroutine(SetMoveAttack(transformButton));
                positionEnemyClick.SettranformEnemy();

            }
           
        }
        public void OnClickCard2()
        {

            if (!isMoving && positionEnemyClick.transformEnemy != Vector3.zero && positionEnemyClick.targetEnemy.GetComponent<Card>().attack>0)
            {
                transformButton = Slot2.GetComponentInChildren<Button>().transform;
                blockSpam.SetActive(true);
                StartCoroutine(SetMoveAttack(transformButton));
                positionEnemyClick.SettranformEnemy();
            }
           
        }
        public void OnClickCard3()
        {

            if (!isMoving && positionEnemyClick.transformEnemy != Vector3.zero && positionEnemyClick.targetEnemy.GetComponent<Card>().attack>0)
            {
                transformButton = Slot3.GetComponentInChildren<Button>().transform;
                blockSpam.SetActive(true);
                StartCoroutine(SetMoveAttack(transformButton));
                positionEnemyClick.SettranformEnemy();
            }
          
        }
        IEnumerator SetMoveAttack(Transform transformButton)
        {
            isMoving = true;
            Transform parentAfterDrag= transformButton.parent;
            transformButton.SetParent(transform.root);
            transformButton.SetAsLastSibling();
            transformButton.transform.LeanMove(new Vector3(positionEnemyClick.transformEnemy.x, positionEnemyClick.transformEnemy.y), 1.7f).setEasePunch();
            SoundManager.Instance.PlayVfxMuSic("Attack");
            yield return  new WaitForSeconds(1.8f);
            transformButton.transform.LeanMove(new Vector3(transformButton.position.x, transformButton.position.y), 1f);
            transformButton.SetParent(parentAfterDrag);
            isMoving = false;
            playerTurn.SetActive(false);
            enemyTurn.SetActive(true);
            yield return  new WaitForSeconds(2f);
            AttackPlayer.IsEnemeTurn = true;
  
            foreach (Transform slot in EnemyCards)
            {
                    if (slot.childCount > 0)
                    {
                        slot.GetComponentInChildren<EnemyAi>().StartAttackLoop();
                        break;
                    }
            }
            

        }
       

    }
}
