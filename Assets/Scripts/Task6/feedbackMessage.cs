using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class feedbackMessage : MonoBehaviour
{

    public Text feedback;
    private double timeInactive;
    public int afkTimer;
    // Start is called before the first frame update
    void Start()
    {
        feedback = GameObject.Find("FeedbackMessage").GetComponent<Text>();
        feedback.gameObject.SetActive(false);

    }
    Vector3 mousePos = Vector3.zero;

    // Update is called once per frame
    void Update()
    {



        if (!Input.anyKey && mousePos == Input.mousePosition)
        {
            timeInactive += Time.deltaTime;
            if (timeInactive > afkTimer) 
            {
            feedback.gameObject.SetActive(true);
            }


        }
        else {

            timeInactive = 0f;
            feedback.gameObject.SetActive(false);
        }

        mousePos = Input.mousePosition;

    }
}
