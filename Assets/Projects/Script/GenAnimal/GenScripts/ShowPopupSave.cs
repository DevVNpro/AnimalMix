using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using UnityEngine;

public class ShowPopupSave : MonoBehaviour
{
    [SerializeField] private GameObject PopupSave;
    void Start()
    {
        StartCoroutine(ShowPopUp());
    }

    IEnumerator ShowPopUp()
    {
        yield return  new  WaitForSeconds(12f);
        SoundManager.Instance.PlayVfxMuSic("Next");
        PopupSave.SetActive(true);
    }

    public void ClosePopup()
    {
        SoundManager.Instance.PlayVfxMuSic("Next");
        PopupSave.SetActive(false);
    }
}
