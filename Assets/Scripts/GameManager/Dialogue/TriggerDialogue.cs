﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour {

    public Dialogue dialogue;

    public void DialogueTrigger ()
    {
        FindObjectOfType<DialogueHandler>().StartDialogue(dialogue);
    }
}
