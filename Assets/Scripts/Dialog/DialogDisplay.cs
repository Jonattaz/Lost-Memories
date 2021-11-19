using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{
    public Conversation conversation;

    public GameObject speakerLeft;

    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;

    private SpeakerUI speakerUIRight;

    private int activeLineIndex = 0;

    // Script player
    private Player playerScript;

    // GameObject player
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && GameManager.dialogMode) 
        {
            AdvanceConversation();
        
        }

    }


    void AdvanceConversation() 
    {
        if (activeLineIndex < conversation.lines.Length) 
        {
            playerScript.talking = true;
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            activeLineIndex = 0;
            playerScript.talking = false;
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUILeft.SpeakerIs(character)) 
        {
            SetDialog(speakerUILeft, speakerUIRight, line.text);

        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text);
        }
    }

    void SetDialog
    (
        SpeakerUI activeSpeakerUI,
        SpeakerUI inactiveSpeakerUI,
        string text) 
    {
        activeSpeakerUI.Dialog = text;
        activeSpeakerUI.Show();

        inactiveSpeakerUI.Dialog = text;
        inactiveSpeakerUI.Hide();
    
    }

}




















