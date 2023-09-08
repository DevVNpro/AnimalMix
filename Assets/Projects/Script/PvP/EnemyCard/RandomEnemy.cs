using Projects.Script.ScripableObject.GenAnimal;
using System.Collections;
using System.Collections.Generic;
using Projects.Script.ManagerGame;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEditor;
using Projects.Script.PvP;

public class RandomEnemy : MonoBehaviour
{
          [SerializeField] private List<Transform> enemyCards;

          public Sprite BorderLv1;
          public Sprite BorderLv2;
          public Sprite BorderLv3;
    
          public Sprite BackgroundLv1;
          public Sprite BackgroundLv2;
          public Sprite BackgroundLv3;
    [SerializeField]     public AnimalGen[] characterDataArray;

         [SerializeField] private string SpritePath = "Assets/Projects/Resources";
 

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
        
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomNumber = Random.Range(0, 3);
            int[] attacklv1 = { 100, 200, 300 };
            int[] attacklv2 = { 400, 500, 600 };
            int[] attacklv3 = { 700, 800, 900 };
            int randomAttackLv1 = attacklv1[randomNumber];
            int randomAttackLv2 = attacklv2[randomNumber];
            int randomAttackLv3 = attacklv3[randomNumber];




            int range = Random.Range(0, characterDataArray.Length);
        //    enemyCards[i].GetComponent<Image>().sprite = characterDataArray[range].CharacterImg;
            Transform boderTransform = enemyCards[i];
            Transform backgroundCard = boderTransform.transform.Find("BackgroundCard");
            Transform imageCard = backgroundCard.transform.Find("ImageCard");

            if (characterDataArray[range].Star ==2)
            {
                boderTransform.GetComponent<Image>().sprite = BorderLv1;
                backgroundCard.GetComponent<Image>().sprite = BackgroundLv1;
                imageCard.GetComponent<Image>().sprite = characterDataArray[range].CharacterImg;
                boderTransform.GetComponent<Card>().attack = randomAttackLv1;
            }
            else if (characterDataArray[range].Star == 4)
            {
                boderTransform.GetComponent<Image>().sprite = BorderLv2;
                backgroundCard.GetComponent<Image>().sprite = BackgroundLv2;
                imageCard.GetComponent<Image>().sprite = characterDataArray[range].CharacterImg;
                boderTransform.GetComponent<Card>().attack = randomAttackLv2;

            }
            else if (characterDataArray[range].Star == 6)
            {
                boderTransform.GetComponent<Image>().sprite = BorderLv3;
                backgroundCard.GetComponent<Image>().sprite = BackgroundLv3;
                imageCard.GetComponent<Image>().sprite = characterDataArray[range].CharacterImg;
                boderTransform.GetComponent<Card>().attack = randomAttackLv3;
            }
        }
            
    }

 
}
