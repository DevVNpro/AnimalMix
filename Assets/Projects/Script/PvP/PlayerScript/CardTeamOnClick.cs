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
    public class CardTeamOnClick : MonoBehaviour
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

        [SerializeField]
        private GetEnemyAttack getEnemyAttack;

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
                positionEnemyClick.SetNullTranformEnemy();

            }
           
        }
        public void OnClickCard2()
        {

            if (!isMoving && positionEnemyClick.transformEnemy != Vector3.zero && positionEnemyClick.targetEnemy.GetComponent<Card>().attack>0)
            {
                transformButton = Slot2.GetComponentInChildren<Button>().transform;
                blockSpam.SetActive(true);
                StartCoroutine(SetMoveAttack(transformButton));
                positionEnemyClick.SetNullTranformEnemy();
            }
           
        }
        public void OnClickCard3()
        {

            if (!isMoving && positionEnemyClick.transformEnemy != Vector3.zero && positionEnemyClick.targetEnemy.GetComponent<Card>().attack>0)
            {
                transformButton = Slot3.GetComponentInChildren<Button>().transform;
                blockSpam.SetActive(true);
                StartCoroutine(SetMoveAttack(transformButton));
                positionEnemyClick.SetNullTranformEnemy();
            }
          
        }
        IEnumerator SetMoveAttack(Transform transformButton)
        {
            isMoving = true;
            //Set lastCanvas
            Transform parentAfterDrag= transformButton.parent;
            transformButton.SetParent(transform.root);
            transformButton.SetAsLastSibling();
            //move Player Position
            transformButton.transform.LeanMove(new Vector3(positionEnemyClick.transformEnemy.x, positionEnemyClick.transformEnemy.y), 0.5f).setEase(LeanTweenType.easeInBack);
            SoundManager.Instance.PlayVfxMuSic("Attack");
            yield return  new WaitForSeconds(0.5f);
            transformButton.transform.LeanMove(new Vector3(parentAfterDrag.position.x, parentAfterDrag.position.y), 0.5f).setEase(LeanTweenType.easeInQuad);
            yield return  new WaitForSeconds(0.5f);
            //return canvas position
            transformButton.SetParent(parentAfterDrag);
            //block spam and animation background
            isMoving = false;
            playerTurn.SetActive(false);
            enemyTurn.SetActive(true);
            yield return  new WaitForSeconds(4f);
            int cnt = 0;
            foreach (Transform slot in EnemyCards)
            {
                    if (slot.childCount > 0)
                    {
                        cnt++;
                        getEnemyAttack.AddEnemyToList(slot);
                      //  slot.GetComponentInChildren<EnemyAi>().StartAttackLoop();
                       // break;
                    }
            }
            if(cnt != 0)
            {

            getEnemyAttack.GetEnemyAttackMax().GetComponentInChildren<EnemyAi>().StartAttackLoop();
            getEnemyAttack.NewListEnemy();

            }
        }
       

    }
}
