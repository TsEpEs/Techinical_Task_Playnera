using UnityEngine;
using UnityEngine.EventSystems;

public class Facial_Reaction : MonoBehaviour, IDropHandler
{
    public void OnDrop (PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        otherItemTransform.SetParent(transform);
    }
}
