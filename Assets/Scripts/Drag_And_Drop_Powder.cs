using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.WSA;

public class Drag_And_Drop_Powder : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Canvas mainCanvas;
    public Image brush;
    public Image hand;
    private bool brushAroundFace;
    public Animator anim;
    public List<Image> powderOnface;
    public static string typePowder;
    private Color col;

    private void Awake()
    {
        mainCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public static void saveTyprPowder(string str)
    {
        typePowder = str;
    }
    public void OnMouseDown()
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
        brush.rectTransform.anchoredPosition += eventData.delta * 1.78f;
        hand.rectTransform.anchoredPosition += eventData.delta * 1.78f;
        brush.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        brush.raycastTarget = true;
        if (brushAroundFace)
        {
            anim.GetComponent<Animator>().enabled = true;
            StartCoroutine(WaitForAnimationEnd());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        brushAroundFace = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        brushAroundFace = false;
    }

    IEnumerator WaitForAnimationEnd()
    {
        col = new Color (255, 255, 255, 0f);
        powderOnface[0].color = col;
        powderOnface[1].color = col;
        powderOnface[2].color = col;
        switch (typePowder)
        {
            case "Powder 1":
                anim.Play("Powder 1" + "_Use");
                col = powderOnface[0].color;
                do
                {
                    col.a += 0.001f;
                    powderOnface[0].color = col;
                } while (col.a < 1);
                yield return new WaitForSeconds(1);
                break;
            case "Powder 2":
                anim.Play("Powder 1" + "_Use");
                col = powderOnface[1].color;
                do
                {
                    col.a += 0.001f;
                    powderOnface[1].color = col;
                } while (col.a < 1);
                yield return new WaitForSeconds(1);
                break;
            case "Powder 3":
                anim.Play("Powder 1" + "_Use");
                col = powderOnface[2].color;
                do
                {
                    col.a += 0.001f;
                    powderOnface[2].color = col;
                } while (col.a < 1);
                yield return new WaitForSeconds(1);
                break;


        }
    }
}
