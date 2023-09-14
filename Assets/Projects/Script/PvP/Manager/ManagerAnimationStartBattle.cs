using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using Projects.Script.PvP.PlayerScript;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.PvP
{
    public class ManagerAnimationStartBattle : MonoBehaviour
    {
        [Header("GameHandler")] 
        [SerializeField] private GameObject GameHandler;
        [Header("Background")]
        [SerializeField] private GameObject backgroundDeck; 
        [SerializeField] private RectTransform backgroundBattleYellow;
        [SerializeField] private GameObject parrtenYellow;
        [SerializeField] private GameObject parrtenBlue;
        [SerializeField] private RectTransform backgroundBattleBlue;
        [SerializeField] private GameObject whiteTriangle;
        [SerializeField] private GameObject textBackground1;
        [SerializeField] private GameObject textBackground2;
        [SerializeField] private GameObject ButtonNextPageRight;
        [SerializeField] private GameObject ButtonNextPageLeft;

        [Header("Turn Animation")] 
        [SerializeField] private GameObject playerTurn;
        
        [Header("ButtonFight")]
        [SerializeField] private Image imageButton;
        
        [Header("TeamGrid")]
        [SerializeField] private Image TeamGrid;

        [Header("DeckGrid")] 
        [SerializeField] private GameObject DeckGrid;
        
        [Header("EnemyGrid")]
        [SerializeField] private Image EnemyGrid;

        [Header("ActiveOnClickSlot")]
        [SerializeField] private CardTeamOnClick cardTeamOnClick;

        [Header("AnimationImgEnemy")] 
        [SerializeField] private List<RectTransform> enemys;

        [Header("Tutorial Attack")] [SerializeField]
        private GameObject tutorrialAttack;

        [Header("Loadding Text")] [SerializeField]
        private GameObject textLoading;

        [Header("List Slot")] [SerializeField] private List<GameObject> slotTeam;

        [Header("ButtonTop")]
        [SerializeField] private GameObject leftButton;
        [SerializeField] private GameObject rightButton;


        private void OnEnable()
        {
            StartCoroutine(AnimationButton());
        }

        IEnumerator AnimationButton()
        {
            while (true)
            {
                transform.LeanScale(new Vector3(1.1f, 1.1f), 0.6f);
                yield return new WaitForSeconds(0.7f);
                transform.LeanScale(new Vector3(1f, 1f), 0.6f);
                yield return new WaitForSeconds(0.7f);

            }
        }
        public void StartCoroutineBattle()
        {
            StartCoroutine(StartBattle());

        }
        IEnumerator StartBattle()
        {
            SoundManager.Instance.PlayThemeMuSic("TheMagic2");
            RemoveDrabItem();
            Animation1();
            yield return new WaitForSeconds(0.6f);
            //move background battle
            LeanTween.move(backgroundBattleBlue, new Vector3(backgroundBattleBlue.anchoredPosition.x, -1800f), 2f);
             LeanTween.move(backgroundBattleYellow, new Vector3(backgroundBattleYellow.anchoredPosition.x, -1914f), 1f);
            yield return new WaitForSeconds(1f);
            whiteTriangle.SetActive(true);
            Animation2();
            yield return new WaitForSeconds(1f);
            parrtenBlue.SetActive(true);
            parrtenYellow.SetActive(true);
            yield return new WaitForSeconds(1f);
            EnemyGrid.rectTransform.LeanScale(new Vector3(1f, 1f), 0.5f);
            
            
            //Animation enemt scale
            yield return new WaitForSeconds(0.6f);
            foreach (RectTransform enemy in enemys)
            {
                enemy.localScale = new Vector3(1,1,1);
                LeanTween.move(enemy, new Vector3(enemy.anchoredPosition.x, -185f), 0.8f);
                SoundManager.Instance.PlayVfxMuSic("EnemyMove");
                yield return new WaitForSeconds(0.4f);
            }
            
            textLoading.SetActive(false);
            
            yield return new WaitForSeconds(0.6f);
            GameHandler.SetActive(true);
            //animation text
            playerTurn.SetActive(true);
            tutorrialAttack.SetActive(true); 
           //cardOnClick.SetActive(true);
           cardTeamOnClick.enabled = true;

        }

        private void RemoveDrabItem()
        {
            foreach (GameObject slot in slotTeam)
            {
                DrapAbleItem drapAbleItem = slot.GetComponentInChildren<DrapAbleItem>();
                if (drapAbleItem)
                {
                    // Vô hiệu hóa script DrapAbleItem
                    drapAbleItem.enabled = false;
                    Debug.Log("Script is disabled for " + slot.name);
                }
                else
                {
                    Debug.Log("Script is not found in " + slot.name);
                }
            }
        }
    

        

        private void Animation1()
        {
            leftButton.SetActive(false);
            rightButton.SetActive(false);
            ButtonNextPageRight.SetActive(false);
            ButtonNextPageLeft.SetActive(false);
            backgroundDeck.SetActive(false);
            imageButton.enabled = false;
            //Turn On Click Slot Team
            
            //Change Method Sum heath
            TotalAttack.ChangeMethodSumDeck = false;
            
            //Set Animation
            DeckGrid.SetActive(false);
            TeamGrid.rectTransform.LeanMove(new Vector3(0f, -540f), 0.6f).setEase(LeanTweenType.linear);
        }

        private void Animation2()
        {
            textBackground1.SetActive(true);
            textBackground2.SetActive(true);
            textLoading.SetActive(true);
        }
      
    }
}
