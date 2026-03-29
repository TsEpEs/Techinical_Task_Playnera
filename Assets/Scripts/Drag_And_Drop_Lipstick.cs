using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.WSA;

public class Drag_And_Drop_Lipstick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Canvas mainCanvas;
    public Image lipstick;
    public Image hand;
    private bool lipstickAroundFace;
    public Animator anim;
    public List<Image> lipstikOnface;
    public static string typeLipstick;
    private Color col;

    private void Awake()
    {
        mainCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public static void saveTypeLipstick(string str)
    {
        typeLipstick = str;
    }
    public void OnMouseDown()
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
        lipstick.rectTransform.anchoredPosition += eventData.delta * 1.78f;
        hand.rectTransform.anchoredPosition += eventData.delta * 1.78f;
        lipstick.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lipstick.raycastTarget = true;
        if (lipstickAroundFace)
        {
            anim.GetComponent<Animator>().enabled = true;
            StartCoroutine(WaitForAnimationEnd());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        lipstickAroundFace = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        lipstickAroundFace = false;
    }

    IEnumerator WaitForAnimationEnd()
    {
        col = new Color(255, 255, 255, 0f);
        lipstikOnface[0].color = col;
        lipstikOnface[1].color = col;
        lipstikOnface[2].color = col;
        switch (typeLipstick)
        {
            case "Lipstik 1":
                anim.Play(typeLipstick + "_Use");
                col = lipstikOnface[0].color;
                do
                {
                    col.a += 0.001f;
                    lipstikOnface[0].color = col;
                } while (col.a < 1);
                break;
            case "Lipstik 2":
                anim.Play(typeLipstick + "_Use");
                col = lipstikOnface[1].color;
                do
                {
                    col.a += 0.001f;
                    lipstikOnface[1].color = col;
                } while (col.a < 1);
                break;
            case "Lipstik 3":
                anim.Play(typeLipstick + "_Use");
                col = lipstikOnface[2].color;
                do
                {
                    col.a += 0.001f;
                    lipstikOnface[2].color = col;
                } while (col.a < 1);
                break;
        }
        yield return new WaitForSeconds(2);
        TakeLipstik.reactOnClick(true);
    }
}
