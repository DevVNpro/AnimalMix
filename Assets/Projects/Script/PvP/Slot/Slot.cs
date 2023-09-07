using UnityEngine;
using UnityEngine.EventSystems;

namespace Projects.Script.PvP.Slot
{
    public class Slot : MonoBehaviour,IDropHandler
    {
        public virtual void OnDrop(PointerEventData eventData)
        {
          
            if (eventData.pointerEnter.GetComponentInChildren<Card>() != null)
            {
               Debug.Log("Vitri da co the bai");
            }
            else if(eventData.pointerEnter.GetComponent<Slot>())
            {
                GameObject dropped = eventData.pointerDrag;
                DrapAbleItem drapAbleItem = dropped.GetComponent<DrapAbleItem>();
                drapAbleItem.parentAfterDrag =  this.transform;
            }
        }
    }
}
