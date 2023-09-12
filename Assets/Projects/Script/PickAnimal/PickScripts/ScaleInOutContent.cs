using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleInOutContent : MonoBehaviour
{
   [SerializeField] private GameObject content;
   [SerializeField] private List<Transform> gameObjects;
   [SerializeField] private RectTransform rectTransformContent;

   private void Start()
   {
      for (int i = 0; i < 14; i++)
      {
         gameObjects.Add(content.transform.GetChild(i));
      }
   }

   public  void ScaleOutContent()
   {
      StartCoroutine(StartScaleOut());
   }
   
   public void ScaleIntContent()
   {
      StartCoroutine(StartScaleIn());
   }

   IEnumerator StartScaleOut()
   {
      foreach (Transform transform in gameObjects)
      {      
         transform.gameObject.GetComponent<Animator>().enabled = false;
         transform.gameObject.LeanScale(new Vector3(0f, 0f, 0f), 0.1f);
         yield return  new WaitForSeconds(0.1f);
      }
      
   }

   IEnumerator StartScaleIn()
   {
      gameObjects.Clear();
      for (int i = 0; i < 14; i++)
      {
         gameObjects.Add(content.transform.GetChild(i));
      }
      rectTransformContent.anchoredPosition = new Vector3(0f,0f,0f);
      foreach (Transform transform in gameObjects)
      {
        LeanTween.scale(transform.gameObject, new Vector3(1f, 1f, 1f), 0.1f);
         yield return  new WaitForSeconds(0.1f);
      }
      
   }
}
