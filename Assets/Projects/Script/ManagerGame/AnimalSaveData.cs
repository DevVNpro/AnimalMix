using System;

namespace Projects.Script.ManagerGame
{
   [Serializable]
   public class AnimalSaveData
   {
      public string name;
      public string imgname;
      public string key;
      public int attack;


      public AnimalSaveData(string name1, string imgname1,string key1,int attack1)
      {
         name = name1;
         imgname = imgname1;
         key = key1;
         attack = attack1;
      }
   }
}
