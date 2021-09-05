using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{

    public Text nameText;
    public Text question;
    public Animator animator;
    public GameObject[] quizzes;
    private int quizIndex = 0;

    

    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        
        sentences = new Queue<string>();
    }

    public void StartQuiz(Quiz quiz)
    {
        
        quiz.gameObject.GetComponent<Animator>().SetBool("IsOpen", true);

        
        FindObjectOfType<AudioManager>().Play("Typing");

        
        //DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //EndQuiz();
            return;
        }
        FindObjectOfType<AudioManager>().Play("Typing");
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        question.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(0.1f);
            FindObjectOfType<AudioManager>().Play("Jumping");
            question.text += letter;
            FindObjectOfType<AudioManager>().Play("Typing");
            yield return null;
        }
        FindObjectOfType<AudioManager>().Play("Typing");
    }

    IEnumerator Wait(Quiz quiz)
    {
        yield return new WaitForSeconds(1f);
        quiz.gameObject.GetComponent<Animator>().SetBool("IsOpen", false);
    }

    IEnumerator WaitWrong(Quiz quiz)
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("IsOpen", true);
    }

    public void WrongAnswer(Quiz quiz)
    {
        FindObjectOfType<AudioManager>().Play("AnswerWrong");
        StartCoroutine(WaitWrong(quiz));
    }

    public void EndQuiz(Quiz quiz)
    {
        GameObject questionCollider = GameObject.Find("Q1");
        FindObjectOfType<AudioManager>().Play("AnswerCorrect");
        StartCoroutine(Wait(quiz));
        Destroy(GameObject.FindWithTag("Quiz"));
    }

}
