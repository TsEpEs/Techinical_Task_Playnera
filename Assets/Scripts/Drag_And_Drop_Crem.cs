using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_And_Drop_Crem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private Canvas mainCanvas;
    public Image crem;
    public Image hand;
    private bool cremAroundFace;
    public Animator anim;
    public Image face;

    private void Awake()
    {
        mainCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        crem.rectTransform.anchoredPosition += eventData.delta * 1.78f;
        hand.rectTransform.anchoredPosition += eventData.delta * 1.78f;
        crem.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        crem.raycastTarget = true;
        if (cremAroundFace)
        {
            anim.GetComponent<Animator>().enabled = true;
            StartCoroutine(WaitForAnimationEnd());
            Color col = face.color;
            do
            {
                col.a += 0.001f;
                face.color = col;
            } while (col.a < 1);
        }   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        cremAroundFace = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        cremAroundFace = false;
    }

    IEnumerator WaitForAnimationEnd()
    {
        anim.Play("UseCremOnFace");
        yield return new WaitForSeconds(1);
        crem.GetComponent<Collider2D>().enabled = false;
        //anim.enabled = false;
    }
}