using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class TakeLipstik : MonoBehaviour
{
    public Animator anim;
    private string nameAnim;
    static private bool react = true;

    public static void reactOnClick(bool willReact)
    {
        TakeLipstik.react = willReact;
    }
    private void OnMouseDown()
    {
        if (react)
        {
            nameAnim = gameObject.name;
            anim.Play(nameAnim + "_Take");
            StartCoroutine(WaitForAnimationEnd());
        }
    }
    IEnumerator WaitForAnimationEnd()
    {
        yield return new WaitForSeconds(1);
        anim.enabled = false;
        react = false;
        Drag_And_Drop_Lipstick.saveTypeLipstick(nameAnim);
    }
}
