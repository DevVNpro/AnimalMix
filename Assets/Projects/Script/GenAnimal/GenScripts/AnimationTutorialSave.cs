using System.Collections;
using UnityEngine;

namespace Projects.Script.GenAnimal.GenScripts
{
    public class AnimationTutorialSave : MonoBehaviour
    {
        private void  Start()
        {
            transform.localScale = new Vector3(0f,0f);
            StartCoroutine(AnimationButtonn());
            
        }

        IEnumerator AnimationButtonn()
        {
            yield return new WaitForSeconds(7f);
            while (true)
            {
                transform.LeanScale(new Vector3(0.15f, 0.15f), 0.6f);
                yield return new WaitForSeconds(0.7f);
                transform.LeanScale(new Vector3(0.2f, 0.2f), 0.6f);
                yield return new WaitForSeconds(0.7f);

            }
        }
    }
}
