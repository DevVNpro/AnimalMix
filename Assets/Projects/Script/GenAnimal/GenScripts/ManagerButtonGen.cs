using System;
using System.Collections;
using Projects.Script.Manager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Projects.Script.GenScripts
{
    public class ManagerButtonGen : MonoBehaviour
    {

        [SerializeField] private GameObject setting;
        [SerializeField] private LogicSaveAnimal logicSaveAnimal;
    

        public void LoadSceneBattle()
        {
            SoundManager.Instance.PlayVfxMuSic("Next");
            DataAnimal.Instance.DeleteNamedata();
            SceneControl.Instance.LoadScene(6);
        }
        
        

        public void LoadCreateAnimal()
        {
            SoundManager.Instance.PlayVfxMuSic("Next");
            DataAnimal.Instance.DeleteNamedata();
            SceneControl.Instance.LoadScene(2);
        }

        public void BackMenuClick()
        {
            SoundManager.Instance.PlayVfxMuSic("Next");
            DataAnimal.Instance.DeleteNamedata();
            SceneControl.Instance.LoadScene(1);
        }

        public void OpenSetting()
        {
            SoundManager.Instance.PlayVfxMuSic("Next");
            setting.SetActive(true);
        }

        public void CloseSetting()
        {
            SoundManager.Instance.PlayVfxMuSic("Next");
            setting.SetActive(false);
        }
        public void SaveAnimal()
        {
            SoundManager.Instance.PlayVfxMuSic("save");
            logicSaveAnimal.SaveData();
        }
  

    }
}
