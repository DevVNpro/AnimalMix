using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.PvP
{
    public class PositionEnemyClick : MonoBehaviour
    {
        [Header("ButtonEnemy")] [SerializeField]
        public Button buttonEnemy1;
        [SerializeField]
        public Button buttonEnemy2;
        [SerializeField]
        public Button buttonEnemy3;  
        public Vector3 transformEnemy;

        public void SetNullTranformEnemy()
        {
            transformEnemy = Vector3.zero;
        }
        public GameObject targetEnemy;

        void Awake()
        {
            transformEnemy = new Vector3( 0, 0 ,0);
            buttonEnemy1.onClick.AddListener(CardEnemyOnClick1);
            buttonEnemy2.onClick.AddListener(CardEnemyOnClick2);
            buttonEnemy3.onClick.AddListener(CardEnemyOnClick3);   
        }

    

        public void CardEnemyOnClick1()
        {
            targetEnemy = buttonEnemy1.gameObject;
            transformEnemy = buttonEnemy1.transform.position;
        }
        public void CardEnemyOnClick2()
        {
            targetEnemy = buttonEnemy2.gameObject;
            transformEnemy = buttonEnemy2.transform.position;
        }
        public void CardEnemyOnClick3()
        {
            targetEnemy = buttonEnemy3.gameObject;
            transformEnemy = buttonEnemy3.transform.position;
        }

    }
}
