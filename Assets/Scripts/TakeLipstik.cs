using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class TakeLipstik : MonoBehaviour
{
    //Script for take lipstick
    public Animator anim;
    private string nameAnim;
    static private bool react = true;

    public static void reactOnClick(bool willReact)
    {
        //Use because this animation 'enable' blcok another animation
        TakeLipstik.react = willReact;
    }
    private void OnMouseDown()
    {
        if (react)
        {
            //Play animation
            nameAnim = gameObject.name;
            anim.Play(nameAnim + "_Take");
            StartCoroutine(WaitForAnimationEnd());
        }
    }
    IEnumerator WaitForAnimationEnd()
    {
        //Off animation
        yield return new WaitForSeconds(1);
        anim.enabled = false;
        //Off react
        react = false;
        //Send info about color lipstick
        Drag_And_Drop_Lipstick.saveTypeLipstick(nameAnim);
    }
}
