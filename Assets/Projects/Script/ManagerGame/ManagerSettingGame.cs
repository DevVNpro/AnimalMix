using System;
using Projects.Script.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.MenuScripts
{
    public class ManagerSettingGame : MonoBehaviour
    {
        [Header("ImageOff")] 
        [SerializeField] private GameObject imageMusic;
        [SerializeField] private GameObject imageVfx;
        private bool isMusicOn;
        private bool isVfxOn;
        
        private void Awake()
        {
            CheckMusicOn();
            CheckVfxOn();
        }

        private void CheckMusicOn()
        {
            int checkMusic;
            checkMusic = PlayerPrefs.GetInt("isMusicOn", 1);
            if (checkMusic==1)
            {
                isMusicOn = true;
            }
            else if(checkMusic==0)
            {
                isMusicOn = false;
            }
        }

        private void CheckVfxOn()
        {
            int checkVfx;
            checkVfx = PlayerPrefs.GetInt("isVfxOn", 1);
            if (checkVfx==1)
            {
                isVfxOn = true;
            }
            else if (checkVfx == 0)
            {
                isVfxOn = false;
            }
        }

        void Update()
        {
            ShowImageMusic();
            ShowImageVfx();
        }
        private void ShowImageMusic()
        {
            if (isMusicOn)
            {
                SoundManager.Instance.themeSource.enabled = true;
                imageMusic.SetActive(false);
            }
            else if (!isMusicOn)
            {
                SoundManager.Instance.themeSource.enabled = false;
                imageMusic.SetActive(true);
            }
        }
        private void ShowImageVfx()
        {
            if (isVfxOn)
            {
                SoundManager.Instance.vfxSource.enabled = true;
                imageVfx.SetActive(false);
            }
            else if (!isVfxOn)
            {
                SoundManager.Instance.vfxSource.enabled = false;
                imageVfx.SetActive(true);
            }
        }
        public void ChangeMusicSetting()
        {
            if (SoundManager.Instance.themeSource.isActiveAndEnabled)
            {
                SoundManager.Instance.themeSource.enabled = false;
                isMusicOn = false;
                PlayerPrefs.SetInt("isMusicOn", isMusicOn ? 1 : 0);
                imageMusic.SetActive(true);
            }
            else
            {
                SoundManager.Instance.themeSource.enabled = true;
                isMusicOn = true;
                PlayerPrefs.SetInt("isMusicOn", isMusicOn ? 1 : 0);
                imageMusic.SetActive(false);
            }
        }
        public void ChangeVfxSetting()
        {
            if (SoundManager.Instance.vfxSource.isActiveAndEnabled)
            {
                SoundManager.Instance.vfxSource.enabled = false;
                isVfxOn = false;
                PlayerPrefs.SetInt("isVfxOn", isVfxOn ? 1:0);
                imageVfx.SetActive(true);
            }
            else
            {
                SoundManager.Instance.vfxSource.enabled = true;
                isVfxOn = true;
                PlayerPrefs.SetInt("isVfxOn", isVfxOn ? 1: 0);
                imageVfx.SetActive(false);
            }
        }
        
        


    }
}
