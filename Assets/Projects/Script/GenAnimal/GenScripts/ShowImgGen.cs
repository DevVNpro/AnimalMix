using System.Collections;
using Projects.Script.Manager;
using UnityEngine;

namespace Projects.Script.GenScripts
{
   public class ShowImgGen : MonoBehaviour
   {
      private void Start()
      {
         StartCoroutine(ShowImg());
      }

      IEnumerator ShowImg()
      {
         transform.localScale = new Vector3(0f, 0f, 0f);
         transform.LeanScale(new Vector3(1.1f, 1.1f), 2.5f).setEaseOutBack();
         yield return  new WaitForSeconds(0.2f);
         SoundManager.Instance.PlayVfxMuSic("finish");
      }
   }
}
