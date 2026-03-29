using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playCremAnimation : MonoBehaviour
{
    //Script for play animation take crem
    public Animator anim;
    public Image crem;
    private void OnMouseDown()
    {
        anim.Play("HandTakeCrem");
        GetComponent<BoxCollider>().enabled = false;
        crem.GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(WaitForAnimationEnd());
    }
    IEnumerator WaitForAnimationEnd()
    {
        //Wait end animation
        yield return new WaitForSeconds(1);
        anim.enabled = false;
    }
}
