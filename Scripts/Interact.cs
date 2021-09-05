using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Board")
        {
            //GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        if (other.transform.tag == "Water")
        {
            other.GetComponent<PlayerHealth>().Die();
        }

        if (other.transform.tag == "Quiz")
        {
            
            int index = int.Parse(other.name[1].ToString())-1;
            //other.GetComponent<QuizTrigger>().TriggerQuiz();
            Quiz quiz = GameObject.FindGameObjectsWithTag("QuizQuestion")[index].GetComponent<Quiz>();
            Debug.Log(quiz);
            GameObject.Find("QuizManager").GetComponent<QuizManager>().StartQuiz(quiz);
        }

        
    }
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.transform.tag == "Quiz")
    //    {
    //        int index = int.Parse(other.name[1].ToString()) - 1;
    //        //other.GetComponent<QuizTrigger>().TriggerQuiz();
    //        Quiz quiz = GameObject.FindGameObjectsWithTag("QuizQuestion")[index].GetComponent<Quiz>();
    //        Debug.Log(quiz);
    //        GameObject.Find("QuizManager").GetComponent<QuizManager>().EndQuiz(quiz);
    //    }
    //}
}
