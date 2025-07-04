using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class DialogueData : ScriptableObject
{
    public DialogueLine[] dialogueLines;
}

[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string line;
    // You can add more variables here, like speaker name, portrait sprite, etc.
}