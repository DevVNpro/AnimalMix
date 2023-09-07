using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Projects.Script.PvP
{
    public class TeamSlot : Slot.Slot
    {
        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);
            GameObject dropped = eventData.pointerDrag;
        }
  

    }
}
