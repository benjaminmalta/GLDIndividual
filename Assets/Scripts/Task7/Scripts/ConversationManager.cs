using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationManager : MonoBehaviour
{

    //Menu 1
    [Tooltip("The current active conversation")]
    public ScriptableObjects currentConversation;

    [Tooltip("Result")]
    public TMP_Text resultText;

    [Tooltip("Option 1")]
    public TMP_Text Option1;

    [Tooltip("Option 2")]
    public TMP_Text Option2;

    [Tooltip("Option 3")]
    public TMP_Text Option3;

    [Tooltip("Option 4")]
    public TMP_Text Option4;

    [Tooltip("NPC Text")]
    public TMP_Text NPCResponse;


    [Tooltip("Not Selected Option Colour")]
    public Color defaultOptionColor;

    [Tooltip("Selected Option Colour")]
    public Color selectedOptionColor;


    //converstaion menu index
    private int indexConversation;

    private bool timerStart = false;
    private double timer = 0f;

    public bool showOnce = true;
    int counter;

    void Start()
    {
        resultText.gameObject.SetActive(false);
        resetIndexConversation();
        renderConversation();
        counter = 0;
    }

    void randomResponseOnLoad() {
        
            if (currentConversation.NPC_Responses.Count != 0)
            {
                NPCResponse.gameObject.SetActive(true);
                NPCResponse.text = currentConversation.NPC_Responses[Random.Range(0, currentConversation.NPC_Responses.Count)];
                
            }
            else
            {
                NPCResponse.text = "";
                NPCResponse.gameObject.SetActive(true);
                
            }
        
        
    }


    void Update()
    {
      
        if (timerStart) {
            timer += Time.deltaTime;
        }

        if (timer > 2) {
            resultText.gameObject.SetActive(false);
            timerStart = false;
            timer = 0;
        }


        //check for mouse input
        float mouseScrollDirection = Input.GetAxis("Mouse ScrollWheel");
       


        if (mouseScrollDirection < 0f)
        {
            indexConversation += 1;
        }
        else if(mouseScrollDirection > 0f)
        {
            indexConversation -= 1;
        }


        if(indexConversation >= currentConversation.menuConversation.Count)
        {
            indexConversation = currentConversation.menuConversation.Count - 1;
        }

        if(indexConversation < 0)
        {
            indexConversation = 0;
        }

        if (counter > 0 && currentConversation.name == "Menu1")
        {
            if (indexConversation == 2 && mouseScrollDirection < 0f)
            {
                indexConversation += 2;                
            }

            if (indexConversation == 2 && mouseScrollDirection > 0f)
            {
                indexConversation -= 1;
            }
        }
               

        

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentConversation.menuConversation[indexConversation].cost == 0)
            {
                currentConversation = currentConversation.menuConversation[indexConversation].linkToConversation;
                resetIndexConversation();
            }
            else if (currentConversation.menuConversation[indexConversation].cost <= GameObject.Find("GameManager").GetComponent<GameManager>().coins)
            {
                timerStart = true;
                resultText.text = "Item Bought";
                resultText.gameObject.SetActive(true);
                GameObject.Find("GameManager").GetComponent<GameManager>().coins = GameObject.Find("GameManager").GetComponent<GameManager>().coins - currentConversation.menuConversation[indexConversation].cost;
                currentConversation = currentConversation.menuConversation[indexConversation].linkToConversation;
                resetIndexConversation();
            }
            else if (currentConversation.menuConversation[indexConversation].cost > GameObject.Find("GameManager").GetComponent<GameManager>().coins)
            {
                timerStart = true;
                resultText.text = "Not Enough Funds";
                resultText.gameObject.SetActive(true);
                currentConversation = currentConversation.menuConversation[indexConversation].linkToConversation;
                resetIndexConversation();
        
            }

            if (currentConversation.name == "section2") {
                counter++;
                resetIndexConversation();                
            }
            

            

        }




        renderConversation();
      
    }

    

    private void renderConversation()
    {

        
        Option1.gameObject.SetActive(false);
        Option2.gameObject.SetActive(false);
        Option3.gameObject.SetActive(false);
        Option4.gameObject.SetActive(false);


        Option1.color = defaultOptionColor;
        Option2.color = defaultOptionColor;
        Option3.color = defaultOptionColor;
        Option4.color = defaultOptionColor;

       



        for (int i = 0; i < currentConversation.menuConversation.Count; i++)
        {
            if(i == 0)
            {
                
                    //FirstOption
                    Option1.gameObject.SetActive(true);
                    Option1.text = currentConversation.menuConversation[0].title;
                    if (indexConversation == 0)
                    {
                        Option1.color = selectedOptionColor;
                    }
                    
                
            }
            else if(i == 1)
            {
                

                    //Second Optrion
                    Option2.gameObject.SetActive(true);
                    Option2.text = currentConversation.menuConversation[1].title;
                    if (indexConversation == 1)
                    {
                        Option2.color = selectedOptionColor;
                    }
                    

                
                
            }
            else if(i == 2)
            {

                //Third Option
                if (counter == 0)
                {

                    Option3.gameObject.SetActive(true);
                    Option3.text = currentConversation.menuConversation[2].title;
                    if (indexConversation == 2)
                    {
                        Option3.color = selectedOptionColor;
                    }

                }
                else {
                    Option3.gameObject.SetActive(false);
                }
                   

                
            }
            else if (i == 3)
            {
                
                    //Fourth Option
                    Option4.gameObject.SetActive(true);
                    Option4.text = currentConversation.menuConversation[3].title;
                    if (indexConversation == 3)
                    {
                        Option4.color = selectedOptionColor;
                    }

                if (currentConversation.name == "Menu1")
                {

                    if (GameObject.Find("GameManager").GetComponent<GameManager>().gameTime >= 0 && GameObject.Find("GameManager").GetComponent<GameManager>().gameTime < 12)
                    {
                        Option4.text = "Good Morning";
                    }

                    if (GameObject.Find("GameManager").GetComponent<GameManager>().gameTime >= 12 && GameObject.Find("GameManager").GetComponent<GameManager>().gameTime < 18)
                    {
                        Option4.text = "Good After Noon";
                    }

                    if (GameObject.Find("GameManager").GetComponent<GameManager>().gameTime >= 18 && GameObject.Find("GameManager").GetComponent<GameManager>().gameTime < 21)
                    {
                        Option4.text = "Good Evening";
                    }

                    if (GameObject.Find("GameManager").GetComponent<GameManager>().gameTime >= 21 && GameObject.Find("GameManager").GetComponent<GameManager>().gameTime < 24)
                    {
                        Option4.text = "Hello, hope you had a great day today";
                    }
                    
                }




            }
        }
        
    }

    private void resetIndexConversation()
    {
        randomResponseOnLoad();
        indexConversation = 0;


    }

    





}
