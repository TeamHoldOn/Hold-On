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
        if(GameStateManager.fled) 
        {
         finalMessage = this.GetComponent<Image>();
            finalMessage.sprite = fledImage;
        }
        if (GameStateManager.died)
        {
            finalMessage = this.GetComponent<Image>();
            finalMessage.sprite = diedImage;

        }
        if (GameStateManager.lost)
        {

            finalMessage = this.GetComponent<Image>();
            finalMessage.sprite = lostImage;
        }
        else {
            finalMessage = this.GetComponent<Image>();
            finalMessage.sprite = lostImage;
        }
    }

}