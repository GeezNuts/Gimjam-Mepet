using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {   
        public string name;
        [TextArea(3,10)]
        public string sentences;
    }
    public  TMP_Text dialogueText;
    public Queue<string> nameOrder;
    public Queue<string> sentences;

    public Dialogue[] introDialogue;
    public Dialogue[] SuaraConstruct;
    public Dialogue[] kingDiedDialogue;
    // Start is called before the first frame update
    void Start()
    {
        nameOrder = new Queue<string>();
        sentences = new Queue<string>();
        StartDialogue(introDialogue);
    }
    public void TimerFinish(){
        StartDialogue(SuaraConstruct);
    }

    // public void TingDied(){
    //     StartDialogue(kingDiedDialogue);
    // }

    public void StartDialogue(Dialogue[] dialogues){
        Debug.Log("Starting conversation with " + dialogues[0].name);
        nameOrder.Clear();
        sentences.Clear();
        foreach(Dialogue dialog in dialogues){
            nameOrder.Enqueue(dialog.name);
            sentences.Enqueue(dialog.sentences);
        }
        DisplayNextSentence();
    }


    public void DisplayNextSentence(){
        dialogueText.text = "";
        if(sentences.Count == 0){
            return;
        }
        string name = nameOrder.Dequeue();
        string sentence = sentences.Dequeue();

        Debug.Log(sentence);
        //animator open dialogue box
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        yield return new WaitForSeconds(1f);
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.3f);
        dialogueText.text = "";
        yield return new WaitForSeconds(1f);
        DisplayNextSentence();
    }
}
