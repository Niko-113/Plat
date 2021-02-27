using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{   
    public int modifier = 6;
    private Animator animator;
    private bool jump = false;
    private Rigidbody rb;
    public float jumpForce = 1;
    private float y;
    private bool ground = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float turbo = Input.GetAxis("Fire3") + 1;
        float horizontal = Input.GetAxis("Horizontal") * (turbo);

        jump = (Input.GetKeyDown(KeyCode.Space)) ? true : false;

        animator.SetFloat("Jump", rb.velocity.y);
        animator.SetBool("isGrounded", IsGrounded());

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        // animator.SetFloat("Turbo", turbo);
        

        if (horizontal != 0) y = (horizontal < 0)? -90: 90; // checkback if necessary

        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);

        transform.rotation = newRotation;

        transform.Translate(transform.right * (horizontal * -1) * Time.deltaTime * modifier, Space.Self);

        if (jump && IsGrounded()){ 
            rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
            //ground = false;
        }
        //ground = false;
    }

    private bool IsGrounded(){
        // if (rb.velocity.y == 0){
        //     return true;
        // } else return false;
        //return ground;
        float distance = this.GetComponent<Collider>().bounds.extents.y;

        return Physics.Raycast(transform.position, Vector3.down, distance + 0.1f);
    
    }

    void OnCollisionStay(){
        ground = true;
    }

}
