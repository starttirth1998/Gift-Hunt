using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public Animator anim;
    public Rigidbody rbody;

	public GameObject gift;

    //private float inputH;
    //private float inputV;

    private float runSpeed = 20f;
    private float walkspeed = 5f;
    private float turnSpeed = 50f;
    private float moveSpeed = 10f;
    private int runDirection;
    private bool jumping;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        runDirection = 0;
        jumping = false;	
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown("1"))
        {
            anim.Play("walk", -1, 0f);
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        float moveX = inputH * 500f * Time.deltaTime;
        float moveZ = inputV * 500f * Time.deltaTime;

        
        rbody.velocity = new Vector3(moveX, 0f, moveZ);*/

        anim.SetInteger("runDirection", runDirection);
        anim.SetBool("jumping", jumping);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            runDirection = 1;   
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * runSpeed * Time.deltaTime);
            runDirection = -1;
        }
        else
        {
            runDirection = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKeyUp("space"))
        {
            anim.Play("jump-up", -1);
            jumping = true;
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("jump-down"))
        {
            jumping = false;
        }

        if (Input.GetKey(KeyCode.P))
        {
            anim.Play("pickup", -1);
			Destroy (gift);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

    }
}
