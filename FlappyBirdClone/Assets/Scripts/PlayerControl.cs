using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // to fetch rigidbody2d object
    public Rigidbody2D rb;
    public LogicHandler logic;
    public Animator animator;
    public AudioSource boom;
    public AudioSource tick;
    public AudioSource backgroundmusic;
    public float jumpSpeed = 1.5f;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("Logic Handler").GetComponent<LogicHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && (alive))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CheckPoint") && alive)
        {
            tick.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone") && alive)
        {
            backgroundmusic.Stop();
            boom.Play();
            animator.Play("Player_Dead");
            alive = false;
            logic.GameOver();
        }
    }
}