using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScriptSelect : MonoBehaviour
{   //sets specific message depending on how game ended. Done through image rather than text because Unity doesn't easily support arabic text
    public Sprite diedImage;
    public Sprite fledImage;
    public Sprite lostImage;
    Image finalMessage;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Last Scene Started");

        if (GameStateManager.ending)
        {
            if (GameStateManager.fled)
            {
                finalMessage = this.GetComponent<Image>();
                finalMessage.sprite = fledImage;
                Debug.Log("Fled");

            }
            if (GameStateManager.died)
            {
                finalMessage = this.GetComponent<Image>();
                finalMessage.sprite = diedImage;
                Debug.Log("Died");

            }
            if (GameStateManager.lost)
            {

                finalMessage = this.GetComponent<Image>();
                finalMessage.sprite = lostImage;
                Debug.Log("Lost it all");

            }

            GameStateManager.fled = false;
            GameStateManager.died = false;
            GameStateManager.lost = false;
            GameStateManager.ending = false;
            OnEndGame.cameraPanned = false;
        }
        else {
            finalMessage = this.GetComponent<Image>();
            finalMessage.sprite = lostImage;
            Debug.Log("Nothing Happened");
        }
           
        
    }
}