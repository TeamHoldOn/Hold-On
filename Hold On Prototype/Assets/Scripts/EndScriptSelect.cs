using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScriptSelect : MonoBehaviour
{
    public Sprite diedImage;
    public Sprite fledImage;
    public Sprite lostImage;
    Image finalMessage; 

    // Use this for initialization
    void Start()
    {
        if(fled) 
        {
         finalMessage = this.GetComponent<Image>();
            finalMessage.sprite = fledImage;
        }
        if (died)
        {
            finalMessage = this.GetComponent<Image>();
            finalMessage.sprite = diedImage;

        }
        if (lost)
        {

            finalMessage = this.GetComponent<Image>();
            finalMessage.sprite = lostImage;
        }
    }

}