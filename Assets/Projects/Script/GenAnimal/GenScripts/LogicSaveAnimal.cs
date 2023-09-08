using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Projects.Script.GenAnimal.GenScripts;
using Projects.Script.ManagerGame;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.GenScripts
{
    public class LogicSaveAnimal : MonoBehaviour
    {
     

        [Header("ButtonSave")] [SerializeField]
        private Button _button;

        [Header("HeadText")] [SerializeField] private Text _text;
   
  
        public void SaveData()
        {
            Debug.Log("SaveWithContent");
            string path = Application.persistentDataPath + "AnimalJsonSave.json";
            if (File.Exists(path))
            {
                foreach (AnimalSaveData animmal in SaveManager.Instance.animalDataList)
                {
                    if (animmal.key == DataAnimal.Instance._keyData)
                    {
                        _button.image.color = Color.grey;
                        _button.enabled = false;
                        _text.fontSize = 60;
                        _text.text = "DUPLICATE";
                        DataAnimal.Instance.DeleteNamedata();
                        return;
                    }
                }
                SaveManager.Instance.AddNewAnimal(DataAnimal.Instance._nameData, DataAnimal.Instance._keyData,DataAnimal.Instance._keyData,SetAttackAnimal.attack);
                _button.image.color = Color.grey;
                _button.enabled = false;
                SaveToJsonWithContent(SaveManager.Instance.animalDataList);
                DataAnimal.Instance.DeleteNamedata();
            }
            else
            {
                SaveManager.Instance.AddNewAnimal(DataAnimal.Instance._nameData, DataAnimal.Instance._keyData,DataAnimal.Instance._keyData,SetAttackAnimal.attack);
                _button.image.color = Color.grey;
                _button.enabled = false;
                SaveToJsonWithContent(SaveManager.Instance.animalDataList);
                DataAnimal.Instance.DeleteNamedata();

            }
        }

        public void SaveToJsonWithContent(List<AnimalSaveData>  listAnimal)
        {
            Debug.Log("SaveWithContent");
            string path = Application.persistentDataPath + "AnimalJsonSave.json";
            using FileStream stream = File.Create(path);
            stream.Close();
            File.WriteAllText(path, JsonConvert.SerializeObject(listAnimal));
        }

   

    }
}
