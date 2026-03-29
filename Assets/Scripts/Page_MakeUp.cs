using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Page_MakeUp : MonoBehaviour
{
    //Script for change page
    public List<Button> buttonsToHide;
    public List<Image> myStuffMakeUp;
    public List<Image> otherStuffMakeUp;
    private Button clickedButton;
    public void HideUnactiveButton()
    {
        //Find out 'Sender'
        clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        //Remove button header page from list
        buttonsToHide.Remove(clickedButton);
        //Off visible unuse another page
        foreach (Button btn in buttonsToHide)
        {
            bool flagPage = false;
            btn.image.color = new Color(255, 255, 255, 0.0f);
            //Off visible and collider unuse makeup stuff
            foreach (Image img in otherStuffMakeUp)
            {
                img.color = new Color(255, 255, 255, 0.0f);
                img.GetComponent<Collider2D>().enabled = false;
                if (flagPage == false)
                {
                    flagPage = true;
                }
                else
                {
                    img.enabled = false;
                }
            }

        }
        //On visible and collider needed sprite
        clickedButton.image.color = new Color(255, 255, 255, 1f);
        foreach (Image img in myStuffMakeUp)
        {
            img.color = new Color(255, 255, 255, 1f);
            img.GetComponent<Collider2D>().enabled = true;
            img.enabled = true;
        }
    }

}