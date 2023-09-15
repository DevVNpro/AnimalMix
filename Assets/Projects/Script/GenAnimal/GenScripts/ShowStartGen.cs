using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.GenScripts
{
    public class ShowStartGen : MonoBehaviour
    {
        [SerializeField]  private List<GameObject> randomStarts;
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;
        static public int startNumber;
        void Start()
        {            
            this.SetScaleStart();
            StartCoroutine(RandomStar());
        }

        private void SetScaleStart()
        {
            foreach (var star in randomStarts)
            {
                star.transform.localScale = new Vector3(0f,0f);
            }
        }

        IEnumerator RandomStar() {
            yield return new WaitForSeconds(3f);
            int check = 0;
            float speedStart = 0;
            _image.enabled = true;
            if (startNumber == 2)
            {
                speedStart = 1.5f;
            }
            else if (startNumber == 4)
            {
                speedStart = 0.8f;
            }
            else
            {
                speedStart = 0.5f;
            }
            Debug.Log("Toc do start là:" + speedStart);
            foreach (var star in randomStarts)
            {
                check++;
                SoundManager.Instance.PlayVfxMuSic("star");
                star.gameObject.SetActive(true);
                star.transform.LeanScale(new Vector3(1f, 1f), speedStart).setEaseOutBack();
                yield return new WaitForSeconds(speedStart);
                if (check == startNumber)
                {
                    SoundManager.Instance.PlayVfxMuSic("stars_lock");
                    if (startNumber <= 3)
                    {
                        _text.text = "NORMAL";
                    }
                    else if(startNumber <=5)
                    {
                        _text.text = "RARE";
                    }
                    else if (startNumber == 6)
                    {
                        _text.text = "EPIC";

                    }
                    else if(startNumber == 7)
                    { 
                        _text.text = "LEGENDARY";
                    }
                    yield break;
                }
         
            }

 
        
        }
    }
}
