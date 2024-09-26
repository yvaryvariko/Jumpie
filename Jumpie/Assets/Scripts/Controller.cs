using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 jumpDir;
    [SerializeField] public float jumpForce, jumpForceMultiplier, maxJumpForce, minJumpForce;
   

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] private bool isGrounded;


    void Start()
    {
        jumpForce = 0;
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        Restart();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundCheckLayerMask);
        Debug.DrawRay(groundCheck.position, Vector3.up * -1, Color.yellow); //Draw Ground Check Radius

        //Increase Jump Force While Pressed, After Certain Time Release Automatically
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            jumpForce += jumpForceMultiplier * Time.deltaTime;
            
            if(jumpForce >= maxJumpForce)
            {
                Jump();
            }
        }


        //When Press Is Released
        if (Input.GetKeyUp(KeyCode.W)) if (isGrounded) Jump();
      
    }

    private void Jump()
    {
        if (jumpForce > maxJumpForce) jumpForce = maxJumpForce;
        if (jumpForce < minJumpForce) jumpForce = minJumpForce;

        rb.velocity = Vector3.zero;
        rb.AddForce(jumpDir * jumpForce, ForceMode.Impulse);
        jumpDir.x *= -1f;
        jumpForce = 0f;
       
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(0);

        }

    }
}
