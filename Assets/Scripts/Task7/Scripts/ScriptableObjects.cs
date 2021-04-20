using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ConvMenu", menuName ="Advanced Conversations/CreateMenu", order = 1)]

public class ScriptableObjects : ScriptableObject
{
    public List<string> NPC_Responses;    
    

    public List<Conversation> menuConversation;

    [System.Serializable]
    public class Conversation
    {

        public string title;
        public ScriptableObjects linkToConversation;
        public int cost;
        
    }
    
}
