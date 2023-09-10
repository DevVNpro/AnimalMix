using Projects.Script.Manager;
using UnityEngine;

namespace Projects.Script.PickAnimal.PickScripts
{
    public class ManagerButtonPick : MonoBehaviour
    {
        [Header("Setting PopUp")] [SerializeField]
        private GameObject setting;
        
        public void LoadMenu()
        {
            DataAnimal.Instance.DeleteNamedata();
            SoundManager.Instance.PlayVfxMuSic("Next");
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
        
        
    }
}
