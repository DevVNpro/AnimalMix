using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Projects.Script.PickAnimal.PickScripts
{
    public class NextButtonAnimation : MonoBehaviour
    {
        [Header("Button Next")] 
        [SerializeField] private Button buttonClick;
        [SerializeField]private Image imageButton;

        [Header("Class ShowUI")]
        [SerializeField] private ShowImageClick showUi;

        [Header("List Button")] [SerializeField]
        private List<Button> buttons;

        [Header("Random List Button")] [SerializeField]
        private RandomAnimal randomButton;

        [Header("Partical System")] [SerializeField]
        private GameObject particalSystem;

        [Header("ImgText")] [SerializeField] private Image imageText;
 
        [Header("BachgroundChange")]
        [SerializeField]
        private GameObject backgroundMom;
        [SerializeField]
        private GameObject fadeBackgroundMom;
        [SerializeField]
        private GameObject fadeBackgroundDad;
        [SerializeField]
        private GameObject backgroundGen;

        [Header("Button Top")] 
        [SerializeField]
        private GameObject leftButton;
        [SerializeField]
        private GameObject rightButton;

        [Header("Content")] 
        [SerializeField] private RectTransform content;
        private void Start()
        {
            buttonClick = transform.GetComponent<Button>();
            buttonClick.onClick.AddListener(SetEven1);
        }
        public void SetEven1()
        {
            //block spam
            DataAnimal.Instance.SetNameData(showUi.headText.text,showUi.keyText.text);
            SoundManager.Instance.PlayVfxMuSic("Next");
            // scaleInOutContent.ScaleOutContent();
            transform.GetComponent<Image>().enabled = false;
            content.anchoredPosition = new Vector2(0f,0f);
            randomButton.RandomButton();
            //delete selected button
            this.DeleteButton(showUi.headText.text);
            showUi.MoveImgDad();
            showUi.SetImgMom();
            //change text
            showUi.ChangeHeadText("PICK A MOM");
            //delete button next
            //change background
            backgroundMom.SetActive(true);
            fadeBackgroundMom.SetActive(true);
            fadeBackgroundDad.SetActive(false);
            //add new Event
            buttonClick.onClick.RemoveListener(SetEven1);
            buttonClick.onClick.AddListener(StartEven2);
        }
        private void DeleteButton(string name)
        {
            foreach (var button in buttons)
            {
                if (button.gameObject.name == name)
                {
                    button.gameObject.SetActive(false);
                }
            }
        }
        private void StartEven2()
        {
            content.gameObject.SetActive(false);
            transform.GetComponent<Image>().enabled = false;
            fadeBackgroundMom.SetActive(false);
            backgroundGen.SetActive(true);

            //addSoundVVFX
            SoundManager.Instance.PlayVfxMuSic("Next");

            //Save name Display
            DataAnimal.Instance.SetNameData(showUi.headText.text, showUi.keyText.text);

            //disable text
            imageText.enabled = false;
            showUi.headText.gameObject.SetActive(false);

            //deactice
            buttonClick.enabled = false;
            imageButton.enabled = false;
            //animation Generation
            StartCoroutine(AnimationGeneration());
        }
       
        IEnumerator AnimationGeneration()
        {
            //turn off button
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        
            showUi.imgDad.rectTransform.LeanMove(new Vector3(-241f, 241f),0.4f);
            showUi.imgMom.rectTransform.LeanMove(new Vector3(241f, 241f), 0.4f);
            showUi.imgDad.rectTransform.LeanScale(new Vector3(1f, 1f),0.4f);
            yield return new WaitForSeconds(1.5f);

            showUi.imgDad.rectTransform.LeanMove(new Vector3(0f, 241f), 0.9f);
            showUi.imgMom.rectTransform.LeanMove(new Vector3(0f, 241f), 0.9f);
            yield return new WaitForSeconds(1f);
            showUi.imgDad.gameObject.SetActive((false));
            showUi.imgMom.gameObject.SetActive((false));
            showUi.headText.gameObject.SetActive(true);
            imageText.enabled = true;
            showUi.ChangeHeadText("GENERATING RESULT");
            particalSystem.SetActive(true);
            //add Sound VFX
            SoundManager.Instance.PlayVfxMuSic("merge_loop");
            yield return new WaitForSeconds(6f);
            particalSystem.gameObject.LeanScale(new Vector3(0f, 0f), 0.8f);
            yield return new WaitForSeconds(0.8f);
            SoundManager.Instance.TurnOffVfxSound();
            SceneControl.Instance.LoadNextScene();
        }

    }
}
