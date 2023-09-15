using System.Collections;
using UnityEngine;

namespace Projects.Script.GenAnimal.GenScripts
{
    public class ShowButton : MonoBehaviour
    {
        [SerializeField] private RectTransform anchorButton;
        void Start()
        {
            StartCoroutine(SetNewPosition());
        }
        IEnumerator SetNewPosition()
        {
            yield return new WaitForSeconds(6f);
            anchorButton.LeanMove(new Vector3(0f, 850f), 1f).setEaseLinear();
        }
    }
}
