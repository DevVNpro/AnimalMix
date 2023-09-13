using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialAttack : MonoBehaviour
{
    [SerializeField] private Image image;
    // Start is called before the first frame update
    private float time;
    private float limidTime;

    private void Awake()
    {
        time = 0;
        limidTime = 4.3f;
        StartCoroutine(AnimationButton());
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= limidTime)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator AnimationButton()
    {
        while (true)
        {
            yield return  new WaitForSeconds(0.5f);
            image.transform.LeanScale(new Vector3(0.2f, 0.2f), 0.6f);
            yield return  new WaitForSeconds(0.7f);
            image.transform.LeanScale(new Vector3(0.3f, 0.3f), 0.6f);
            yield return  new WaitForSeconds(0.7f);
            image.rectTransform.LeanMove(new Vector3(20f,-550f), 0.6f);
            yield return  new WaitForSeconds(0.7f);
            image.transform.LeanScale(new Vector3(0.2f, 0.2f), 0.6f);
            yield return  new WaitForSeconds(0.7f);
            image.transform.LeanScale(new Vector3(0.3f, 0.3f), 0.6f);
            yield return  new WaitForSeconds(0.7f);


        }
    }
}
