using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TakePowder : MonoBehaviour
{
    //Script for take Powder
    public Animator anim;
    private string nameAnim;

    private void OnMouseDown()
    {
        //After click will found out 'Sender'
        nameAnim = gameObject.name;
        //Play animation
        anim.Play(nameAnim + "_Take");
        StartCoroutine(WaitForAnimationEnd());
    }
    IEnumerator WaitForAnimationEnd()
    {
        //Wait end of animation
        yield return new WaitForSeconds(2);
        //Off animation so that could move the object
        anim.enabled = false;
        //Send info about color/type powder
        Drag_And_Drop_Powder.saveTyprPowder(nameAnim);
    }
}

