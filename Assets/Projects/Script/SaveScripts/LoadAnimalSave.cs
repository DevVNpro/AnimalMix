using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Projects.Script.ManagerGame;

namespace Projects.Script.SaveScripts
{
    public class LoadAnimalSave : MonoBehaviour
    {
        public GameObject animalPrefab;
        public Transform scrollViewContent;

        public Sprite BorderLv1;
        public Sprite BorderLv2;
        public Sprite BorderLv3;
        
        public Sprite BackgroundLv1;
        public Sprite BackgroundLv2;
        public Sprite BackgroundLv3;
       
        public Sprite imageStartLv1;
        public Sprite imageStartLv2;
        public Sprite imageStartLv3;
        
        private void Start()
        {
           
            string path = Application.persistentDataPath + "AnimalJsonSave.json";
            if (File.Exists(path))
            {
                UpdateList(SaveManager.Instance.animalDataList);        
                Debug.Log(" Exists Data");

            }
            else
            {
                Debug.Log("Null Data");
            }
        }



        public void UpdateList(List<AnimalSaveData> animalList)
        {
            foreach (AnimalSaveData animalData in animalList)
            {
                GameObject newAnimalPrefab = Instantiate(animalPrefab, scrollViewContent);
            
                Sprite loadedSprite = Resources.Load<Sprite>(animalData.imgname);
                if (loadedSprite == null)
                {
                    Debug.Log("Không thể tải ảnh cho: " + animalData.name);
                }
                else
                {
                    Image boderImage = newAnimalPrefab.GetComponent<Image>();
                    Transform tranformBackgroundCard = newAnimalPrefab.transform.Find("BackgroundCard");
                    Transform  tranformImageCard = tranformBackgroundCard.Find("ImagedCard");
                    Transform tranformStart = newAnimalPrefab.transform.Find("ImageStart");
                    Image imageStart = tranformStart.GetComponent<Image>();
                    Image imageBackground =  tranformBackgroundCard.GetComponent<Image>();
                    Image imageCard  = tranformImageCard.GetComponent<Image>();
                    
                    if (animalData.attack <= 400)
                    {
                        boderImage.sprite = BorderLv1;
                         imageBackground.sprite  = BackgroundLv1;
                         imageStart.sprite = imageStartLv1;
                         imageStart.SetNativeSize();
                        imageCard.sprite = loadedSprite;
                        
                     
                    }
                    else if (animalData.attack <= 600)
                    {
                        boderImage.sprite = BorderLv2;
                        imageBackground.sprite  = BackgroundLv2;
                        imageStart.sprite = imageStartLv2;
                        imageStart.SetNativeSize();
                        imageCard.sprite = loadedSprite;
                    }
                    else if(animalData.attack <=900)
                    {
                        boderImage.sprite = BorderLv3;
                        imageBackground.sprite  = BackgroundLv3;
                        imageStart.sprite = imageStartLv3;
                        imageStart.SetNativeSize();
                        imageCard.sprite = loadedSprite;
                        
                    }
                }

                newAnimalPrefab.name = animalData.name;
            }
        }

    }
}
        
