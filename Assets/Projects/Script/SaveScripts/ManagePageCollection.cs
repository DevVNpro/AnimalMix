using System;
using Projects.Script.ManagerGame;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Projects.Script.SaveScripts
{
    public class ManagePageCollection : MonoBehaviour
    {
        [Header("ScollTranform")] [SerializeField]
        private RectTransform scollTranform;

        public Button periosPage;
        public Button nextPage;
        public Vector3 newPositonNext;
        public Vector3 newPositonPrerios;
        public int numberCardPage;
        public int maxPage;
        public int currentPage;

        private void Awake()
        {
            currentPage = 1;
            NumberPage();
            UpdateButton();
        }
        
        private void Update()
        {
            NumberPage();
            UpdateButton();
            Debug.Log("Số thẻ bài là:" + SaveManager.Instance.animalDataList.Count);
        }

     

        private void  UpdateButton()
        {
            if (SaveManager.Instance.animalDataList.Count <= numberCardPage)
            {
                periosPage.gameObject.SetActive(false);
                nextPage.gameObject.SetActive(false);
            }

            if (currentPage == 1) periosPage.gameObject.SetActive(false);
            else periosPage.gameObject.SetActive(true);
            if (currentPage == maxPage) nextPage.gameObject.SetActive(false);
            else nextPage.gameObject.SetActive(true);
        }

        private void NumberPage()
        {
            if (SaveManager.Instance.animalDataList.Count % numberCardPage > 0)
            {
                maxPage = SaveManager.Instance.animalDataList.Count / numberCardPage + 1;
            }
            else if(SaveManager.Instance.animalDataList.Count <=numberCardPage)
            {
                maxPage = 1;
            }
            else
            {
                maxPage = SaveManager.Instance.animalDataList.Count / numberCardPage;
            }
        }
        

        public void NextPage()
        {
            if (currentPage < maxPage)
            {
                currentPage+= 1;
                Vector3 currentPosition = scollTranform.anchoredPosition;
                Vector3 newPosition = currentPosition + newPositonNext;
                scollTranform.anchoredPosition = newPosition;
                UpdateButton();
            }
     
        }

        public void PeriosPage()
        {
            if (currentPage != 1)
            {
                currentPage-=1;
                Vector3 currentPosition = scollTranform.anchoredPosition;
                Vector3 newPosition = currentPosition + newPositonPrerios;
                scollTranform.anchoredPosition = newPosition;
                UpdateButton();  
                
            }
     
        }
        
    }
}
