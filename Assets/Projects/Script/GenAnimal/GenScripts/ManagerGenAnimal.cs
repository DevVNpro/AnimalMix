using System;
using System.Collections.Generic;
using Projects.Script.GenAnimal.GenScripts;
using Projects.Script.GenScripts;
using Projects.Script.ManagerGame;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
namespace Projects.Script.ScripableObject.GenAnimal
{
    public class ManagerGenAnimal : MonoBehaviour
    {
       
           [SerializeField]
          public AnimalGen[] characterDataArray;

         [SerializeField] private string SpritePath = "Assets/Projects/Resources";
            [SerializeField] private Image characterImage;

            private void Awake()
            {
                ChangeToArray();

            }

            private void Start()
            {
                ShowCharacterImage(DataAnimal.Instance._keyData);
            }

#if UNITY_EDITOR
            
            [Button]
            void GenData()
            {
                var listSpriteGUID = AssetDatabase.FindAssets("t:texture2D", new[] {SpritePath});
                var listSprite = new List<Sprite>();
                foreach (string s in listSpriteGUID)
                {
                    var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GUIDToAssetPath(s));
                    listSprite.Add(sprite);
                }

                characterDataArray = new AnimalGen[listSprite.Count];
                for (var i = 0; i < characterDataArray.Length; i++)
                {
                    characterDataArray[i] = new AnimalGen(listSprite[i].name, listSprite[i]);
                }
            }
#endif
        
            private void ShowCharacterImage(string key)
            {
                foreach (AnimalGen characterData in characterDataArray)
                {
                    if (characterData.Key == key)
                    {
                        characterImage.sprite = characterData.CharacterImg;
                        StartAnimal.startNumber = characterData.Star;
                        SetAttackAnimal.setAttack = characterData.Star;
                        return;
                    }
                }

                Debug.LogError("Không tìm thấy dữ liệu cho nhân vật " + key);
            }
            private void ChangeToArray()
            {
                char[] charArray = DataAnimal.Instance._keyData.ToCharArray();
                Array.Sort(charArray); // Sắp xếp mảng char theo thứ tự bảng chữ cái

                string sortedString = new string(charArray); // Chuyển mảng char thành chuỗi đã sắp xếp
                DataAnimal.Instance._keyData = sortedString;

            }
        
    }
}
