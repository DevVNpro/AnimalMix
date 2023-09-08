using System.Collections.Generic;
using UnityEngine;

namespace Projects.Script.ManagerGame
{
    public class SaveManager : MonoBehaviour
    {
        private static SaveManager instance;
        public static SaveManager Instance => instance;

        public List<AnimalSaveData> animalDataList = new List<AnimalSaveData>();

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(this);

        }

        public void AddNewAnimal(string name1, string imgname1, string key, int attack)
        {
            AnimalSaveData newAnimal = new AnimalSaveData(name1, imgname1, key,attack);
            animalDataList.Add(newAnimal);
        }

   

   
    }
}





