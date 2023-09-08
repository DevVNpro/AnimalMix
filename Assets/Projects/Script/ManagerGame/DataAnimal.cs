using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Script.PickScripts;
using UnityEngine;

public class DataAnimal : MonoBehaviour
{
    private static DataAnimal instance;
    
    public static DataAnimal Instance
    {
        get => instance;
    }


    public string _nameData;
    public string _keyData;

    private void Start()
    {
        this.GetInstance();
    }

    private void GetInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
    }


    public void SetNameData(string newName, string datakey)
    {
        _nameData += newName;
        _keyData += datakey;
    }

    public void DeleteNamedata()
    {
        _nameData = "";
        _keyData = "";
    }
    
    
    
    
}
