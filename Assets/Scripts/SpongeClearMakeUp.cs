using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class SpongeClearMakeUp : MonoBehaviour
{
    //Script for clear make up
    public GameObject faceWithMakeUp;
    public Image[] Images; 
    public void Awake()
    {
        //Take all sprite off make up
        Images = faceWithMakeUp.GetComponentsInChildren<Image>();
    }

    private void OnMouseDown()
    {
        //Off visible
        foreach (Image img in Images)
        {
            img.color= new Color(255, 255, 255, 0);
        }
    }
}
