using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoad : MonoBehaviour
{
    [SerializeField] private Slider sliderLoading;
    void Start()
    {
        StartCoroutine(Loading(0));
    }

    IEnumerator Loading(int index)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(index);
        while (!loadOperation.isDone)
        {
           float progressValue =Mathf.Clamp01(loadOperation.progress / 0.9f);
            sliderLoading.value = progressValue;
            yield return null;
        }
        
    }

}
