using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{   
    public int modifier = 6;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        

        float y = (horizontal < 0)? -90: 90; // checkback if necessary

        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);

        transform.rotation = newRotation;

        transform.Translate(transform.right * (horizontal * -1) * Time.deltaTime * modifier, Space.Self);

        
    }
}
