using UnityEngine;
using UnityEngine.EventSystems;

public class Facial_Reaction : MonoBehaviour, IDropHandler
{
    //Unuse script old architecture
    public void OnDrop (PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        otherItemTransform.SetParent(transform);
    }
}
