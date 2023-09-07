using System;
using System.Collections.Generic;
using UnityEngine;

namespace Projects.Script.Manager
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager _instance;
        public static SoundManager Instance
        {
            get => _instance;
        }

        private void Start()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
            this.PlayThemeMuSic("TheMagic1");
        }

        public AudioSource themeSource;
        public AudioSource vfxSource;
        [SerializeField]private List<AudioClip> themes;
        [SerializeField] private List<AudioClip> vfxs;

        public void PlayThemeMuSic(String name)
        {
            foreach (AudioClip musicThemes in themes)
            {
                if (musicThemes.name == name)
                {
                    themeSource.clip = musicThemes;
                    themeSource.Play();
                    return;
                }
            }
        }

        public void PlayVfxMuSic(String name)
        {
            foreach (AudioClip musicVfxs in vfxs)
            {
                if (musicVfxs.name == name)
                {
                    vfxSource.clip = musicVfxs;
                    vfxSource.Play();
                    return;
                }

            }
        }

        public void TurnOffVfxSound()
        {
            vfxSource.Pause();
        }
        


    }
}
