using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicPickAnimal : MonoBehaviour
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

    [Header("Scale Inout Content")] [SerializeField]
    private ScaleInOutContent scaleInOutContent;
    private void Start()
    {
        transform.gameObject.SetActive(false);
        buttonClick = transform.GetComponent<Button>();
        buttonClick.onClick.AddListener(() => StartCoroutine(Even1()));
    }

    IEnumerator Even1()
    {
        //addSoundVVFX
        SoundManager.Instance.PlayVfxMuSic("Next");
        //Save name Display
        DataAnimal.Instance.SetNameData(showUi.headText.text,showUi.keyText.text);
        //animation 
        showUi.MoveImgDad();
        showUi.SetImgMom();
        scaleInOutContent.ScaleOutContent();
        yield return new WaitForSeconds(2f);
        //random Buton
        randomButton.RandomButton();
        //delete selected button
        this.DeleteButton(showUi.headText.text);
        scaleInOutContent.ScaleIntContent();
        //change text
        showUi.ChangeHeadText("PICK A MOM");
        //delete button next
        transform.gameObject.SetActive(false);
        //change background
        backgroundMom.SetActive(true);
        fadeBackgroundMom.SetActive(true);
        fadeBackgroundDad.SetActive(false);
        //add new Event
        buttonClick.onClick.AddListener(Even2);
    }
    /*private void Even11()
    {
        //addSoundVVFX
        SoundManager.Instance.PlayVfxMuSic("Next");
        //Save name Display
        DataAnimal.Instance.SetNameData(showUi.headText.text,showUi.keyText.text);
        //animation 
        showUi.MoveImgDad();
        showUi.SetImgMom();
        scaleInOutContent.ScaleOutContent();
        //random Buton
        randomButton.RandomButton();
        //delete selected button
        this.DeleteButton(showUi.headText.text);
        //change text
        showUi.ChangeHeadText("PICK A MOM");
        //delete button next
        transform.gameObject.SetActive(false);
        //change background
        backgroundMom.SetActive(true);
        fadeBackgroundMom.SetActive(true);
        fadeBackgroundDad.SetActive(false);
        //add new Event
        buttonClick.onClick.RemoveListener(Even1);
        buttonClick.onClick.AddListener(Even2);
    }*/

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

    private void Even2()
    {
        fadeBackgroundMom.SetActive(false);
        backgroundGen.SetActive(true);
        
        //addSoundVVFX
        SoundManager.Instance.PlayVfxMuSic("Next");
        
        //Save name Display
        DataAnimal.Instance.SetNameData(showUi.headText.text,showUi.keyText.text);
        
        //disable text
        imageText.enabled = false;
        showUi.headText.gameObject.SetActive(false);
        
        //detele All Button
        this.DeActiveButton();
        
        //deactice
        buttonClick.enabled = false;
        imageButton.enabled = false;
        

        //animation Generation
        StartCoroutine(AnimationGeneration());
    }
    private void DeActiveButton()
    {
        foreach (var button in buttons)
        {
           button.gameObject.SetActive(false);
        }
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
