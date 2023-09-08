using System;
using UnityEngine;

namespace Projects.Script.ManagerGame
{
    
    [Serializable]
    public class AnimalGen
    {
        [SerializeField] private string key;
        [SerializeField] private Sprite characterImg;
        [SerializeField] private int star;

        public AnimalGen(string key, Sprite img)
        {
            this.key = key;
            characterImg = img;    
        }
        
        public string Key
        {
            get => key;
        }

        public Sprite CharacterImg
        {
            get => characterImg;
        }

        public int Star => star;
    }
}
