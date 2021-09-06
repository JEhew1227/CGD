using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        FindObjectOfType<AudioManager>().Play("EnemyHurt");
        animator.SetTrigger("Hurt");

        //Play hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator Wait()
    {
        GetComponent<EnemyAttack>().StopAttack();
        yield return new WaitForSeconds(1); 
        Destroy(this.gameObject);
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);
        StartCoroutine(Wait());

        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        

        //Die animation
    }


    }


