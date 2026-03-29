using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class SpongeClearMakeUp : MonoBehaviour
{
    public GameObject faceWithMakeUp;
    public Image[] Images; 
    public void Awake()
    {
        Images = faceWithMakeUp.GetComponentsInChildren<Image>();
    }

    private void OnMouseDown()
    {
        
        foreach (Image img in Images)
        {
            img.color= new Color(255, 255, 255, 0);
        }
    }
}
