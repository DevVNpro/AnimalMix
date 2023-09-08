using System.Collections;
using TMPro;
using UnityEngine;

namespace Projects.Script.PvP.EnemyCard
{
    public class ShowDamageReceiver : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI textDamageReceiver;

        public int positionX;
        public int positionUpY;
        public int positionDownY;

        // Start is called before the first frame update

        public void StartShow(int damage)
        {
            StartCoroutine(ShowText(damage));
        }
        
        IEnumerator ShowText(int damage)
        {            
            RectTransform rectTransform = GetComponent<RectTransform>();
            textDamageReceiver.text ="-"+damage;
            yield return  new WaitForSeconds(0.1f);
            TextMoveUp();
            yield return  new WaitForSeconds(2f);
            textDamageReceiver.text = "-";
            rectTransform.localScale = new Vector3(0,0,0);
            rectTransform.anchoredPosition = new Vector2(positionX,positionDownY);
        }

        public void TextMoveUp()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            LeanTween.move(rectTransform, new Vector3(positionX, positionUpY), 1f);
            rectTransform.LeanScale(new Vector3(1f, 1f), 1.2f);
            //leancolor
        }
    }
}
