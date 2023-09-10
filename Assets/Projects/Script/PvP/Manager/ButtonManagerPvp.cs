using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using Projects.Script.PvP;
using UnityEngine;

public class ButtonManagerPvp : MonoBehaviour
{
    [Header("Setting")] [SerializeField] private GameObject setting;

    [Header("ManagerAnimation Buttion")] [SerializeField]
    private ManagerAnimationStartBattle _animationBattle;
    public void ResetBattle()
    {
        SoundManager.Instance.PlayVfxMuSic("Next");
        SceneControl.Instance.LoadScene(6);
    }

    public void CreateAnimal()
    {
        SoundManager.Instance.PlayVfxMuSic("Next");
        SceneControl.Instance.LoadScene(2);
    }

    public void LoadMenu()
    {
        SoundManager.Instance.PlayVfxMuSic("Next");
        if(SoundManager.Instance.themeSource.clip.name != "TheMagic1")
        {
        SoundManager.Instance.PlayThemeMuSic("TheMagic1");
        }
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

    public void StartAnimatonBattle()
    {
        _animationBattle.StartCoroutineBattle();
    }
    
    
}
