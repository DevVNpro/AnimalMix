using Projects.Script.Manager;
using System.Collections.Generic;
using System.IO;
using Projects.Script.ManagerGame;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace Projects.Script.PvP.Manager
{
    public class LoadDataSavePvP : MonoBehaviour
    {
        [Header("PrefabsCard")] 
        [SerializeField] private GameObject card;

        [Header("Content")]
        [SerializeField] private Transform content;
        
        
        public Sprite BorderLv1;
        public Sprite BorderLv2;
        public Sprite BorderLv3;
        
        public Sprite BackgroundLv1;
        public Sprite BackgroundLv2;
        public Sprite BackgroundLv3;
        void Start()
        {
            string path = Application.persistentDataPath + "AnimalJsonSave.json";
            string jsonConten = File.ReadAllText(path);
            if (jsonConten != "")
            {
              LoadDataSave(SaveManager.Instance.animalDataList);        
                Debug.Log(" co du lieu");

            }
            else
            {
                Debug.Log("Khong co du lieu");
            }
        }

        private void LoadDataSave(List<AnimalSaveData> animalList)
        {
            foreach (AnimalSaveData animalData in animalList)
            {
                GameObject newAnimalPrefab = Instantiate(card, content);
                //do something with data
                
                
                Sprite loadedSprite = Resources.Load<Sprite>(animalData.imgname);
                if (loadedSprite == null)
                {
                    Debug.Log("Không thể tải ảnh cho: " + animalData.name);
                }
                else
                {
                    Transform childTransform = newAnimalPrefab.transform.Find("Deck1");
                    Transform backgroundCard = childTransform.transform.Find("BackgroundCard");
                    Transform  imageCard = backgroundCard.transform.Find("ImageCard");

                    if (animalData.attack <= 400)
                    {
                        childTransform.GetComponent<Image>().sprite = BorderLv1;
                        backgroundCard.GetComponent<Image>().sprite = BackgroundLv1;
                        imageCard.GetComponent<Image>().sprite = loadedSprite;
                    }
                    else if (animalData.attack <= 600)
                    {
                        childTransform.GetComponent<Image>().sprite = BorderLv2;
                        backgroundCard.GetComponent<Image>().sprite = BackgroundLv2;
                        imageCard.GetComponent<Image>().sprite = loadedSprite;
                    }
                    else if(animalData.attack <=900)
                    {
                        childTransform.GetComponent<Image>().sprite = BorderLv3;
                        backgroundCard.GetComponent<Image>().sprite = BackgroundLv3;
                        imageCard.GetComponent<Image>().sprite = loadedSprite;
                    }
                }

                newAnimalPrefab.name = animalData.name;
                newAnimalPrefab.GetComponentInChildren<Card>().attack = animalData.attack;
            }



        }

       
    }
}
