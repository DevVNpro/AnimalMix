using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerButtonSave : MonoBehaviour
{
    public void BackMenu()
    {
        SoundManager.Instance.PlayVfxMuSic("Click");
        SceneControl.Instance.LoadScene(1);
    }
}
