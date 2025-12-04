using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float health = 100f;

    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("IsDead", true);
        // Destroy(gameObject);
        GetComponent<Collider>().enabled = false;
    }
}
