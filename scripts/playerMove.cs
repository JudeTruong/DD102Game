using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float speed; //makes a editable speed in unity
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private void Awake()
    {
        //makes it so we can manipulate the attributes below 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //right is posutive left is negative
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,body.velocity.y); //speed of player on horixzontal axis
        
        //flips player
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(2,2,2);
        if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2,2,2);

        //jumps if space
        if (Input.GetKey(KeyCode.Space) && grounded==true)
            Jump();


        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);

    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed+3);
        grounded = false;
    }
    //detects collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground");
            grounded = true;
    }
}
