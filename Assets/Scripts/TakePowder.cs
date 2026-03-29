using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TakePowder : MonoBehaviour
{
    public Animator anim;
    private string nameAnim;

    private void OnMouseDown()
    {
        nameAnim = gameObject.name;
        anim.Play(nameAnim + "_Take");
        StartCoroutine(WaitForAnimationEnd());
    }
    IEnumerator WaitForAnimationEnd()
    {
        yield return new WaitForSeconds(2);
        anim.enabled = false;
        Drag_And_Drop_Powder.saveTyprPowder(nameAnim);
    }
}

