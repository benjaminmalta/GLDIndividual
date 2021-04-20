using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    [Tooltip("Store Panel")]
    public GameObject ConversationPanel;
    public GameObject prompt;
    bool inRange = false;
    

    // Start is called before the first frame update
    void Start()
    {
        ConversationPanel = GameObject.Find("ConversationPanel");
        ConversationPanel.SetActive(false);

        prompt = GameObject.Find("Prompt");
        prompt.SetActive(false);
    }

    void Update()
    {
        if (inRange) {
            if (Input.GetKeyDown(KeyCode.E)) {
                prompt.SetActive(false);
                ConversationPanel.SetActive(true);
        
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        print("NPCharactre Zone");
        inRange = true;
        prompt.SetActive(true);

                   


    }

    private void OnTriggerExit(Collider other)
    {
        
        print("Exit NPCharacter Zone");        
        ConversationPanel.SetActive(false);
        prompt.SetActive(false);
        inRange = false;
    }



}
