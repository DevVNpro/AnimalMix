using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using Projects.Script.PvP;
using Projects.Script.PvP.EnemyCard;
using  UnityEngine.UI;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
  public void Settrigger(Collider2D other)
        {

            int health = other.GetComponent<Card>().attack;
            int attack = transform.GetComponent<Card>().attack;
            if (attack >= health)
            {
                StartCoroutine(DeductAttack(other));
            }
            else
            {
                other.transform.Find("TextReceiver").GetComponentInChildren<ShowDamageReceiver>().StartShow(attack);
                health -= attack;
            }

            other.GetComponent<Card>().attack = health;
        }
        IEnumerator DissolveOverTime(float duration, UIDissolve dissolveComponent1, UIDissolve dissolveComponent2)
        {
            float elapsedTime = 0f;
            float startValue = 0f;
            float endValue = 1f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                float dissolveValue = Mathf.Lerp(startValue, endValue, t);
                dissolveComponent1.effectFactor = dissolveValue;
                dissolveComponent2.effectFactor = dissolveValue;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            dissolveComponent1.effectFactor = endValue;
            dissolveComponent2.effectFactor = endValue;
        }

        IEnumerator DeductAttack(Collider2D other)
        {
            other.transform.Find("TextReceiver").GetComponentInChildren<ShowDamageReceiver>().StartShow(other.GetComponent<Card>().attack);
            yield return new WaitForSeconds(0.2f);
            other.GetComponent<Card>().attack = 0;
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(DissolveOverTime(2.4f, other.GetComponent<UIDissolve>(), other.transform.Find("BackgroundCard").GetComponent<UIDissolve>()));
            other.GetComponent<Image>().raycastTarget = false;
            yield return new WaitForSeconds(2.4f);
            LeanTween.scale(other.gameObject, new Vector3(0f, 0f, 0f), 0.2f);
            other.transform.SetParent(transform.root);
        }
}
