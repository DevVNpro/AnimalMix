using System.Collections;
using System.Collections.Generic;
using Projects.Script.Manager;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowNameAnimalSave : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _gameObjecttext;

    void Start()
    {
        //get button
        _button = transform.GetComponent<Button>();
        _button.onClick.AddListener(ShowimgAndText);
        

        //get text
        _gameObjecttext = GameObject.FindGameObjectWithTag("text");

    }

    private void ShowimgAndText()
    {
        this.SetText();
        this.AddSoundVfx();
    }

    private void SetText()
    {
        _gameObjecttext.GetComponent<TextMeshProUGUI>().text = _button.name;
        
    }
    private void AddSoundVfx()
    {
        SoundManager.Instance.PlayVfxMuSic("Click");
    }
  



}
