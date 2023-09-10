using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Projects.Script.ManagerGame;
using UnityEngine;
using  UnityEngine.UI;

namespace Projects.Script.MenuScripts
{
    public class LoadDataSave : MonoBehaviour
    {
        void Start()
        {
          
          string path = Application.persistentDataPath + "AnimalJsonSave.json";
          
          
          /*string content = File.ReadAllText(path);
          List<AnimalSaveData> a = JsonConvert.DeserializeObject<List<AnimalSaveData>>(content);
          a.RemoveAll(item => item.key == "EJ");
          string jsonSave = JsonConvert.SerializeObject(a);
          File.WriteAllText(path, jsonSave);
          Debug.Log(File.ReadAllText(path));*/
           
            if (File.Exists(path))
            {
                Debug.Log("1");
                LoadDataSave1(ref SaveManager.Instance.animalDataList);


            }
            else
            {
                Debug.Log("2");
                SaveManager.Instance.AddNewAnimal("DOGCAT", "AB", "AB", 100);
                string jsonSave = JsonConvert.SerializeObject(SaveManager.Instance.animalDataList);
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, jsonSave);

            }

        }

      
        public void LoadDataSave1(ref List<AnimalSaveData> savedAnimals)
        {
            string path = Application.persistentDataPath + "AnimalJsonSave.json";
            if (!File.Exists(path))
            {
                Debug.LogError($"Cannot load file at {path}. File does not exist!");
            }

            try
            {
                Debug.Log(File.ReadAllText(path));
                savedAnimals = JsonConvert.DeserializeObject<List<AnimalSaveData>>(File.ReadAllText(path));
                Debug.Log(savedAnimals);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load Data due to:  {e.Message} {e.StackTrace}");
            }
        }
        
    }
}
