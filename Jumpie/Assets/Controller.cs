using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 jumpDir;
    public float jumpForce, jumpForceMultiplier, maxJumpForce, minJumpForce;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Restart();

     
        if (Input.GetKey(KeyCode.W))
        {
            jumpForce += jumpForceMultiplier * Time.deltaTime;

           
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (jumpForce > maxJumpForce) jumpForce = maxJumpForce;
            if (jumpForce < minJumpForce) jumpForce = minJumpForce;
            
            rb.velocity = Vector3.zero;
            rb.AddForce(jumpDir * jumpForce, ForceMode.Impulse);
            jumpDir.x *= -1f;
            jumpForce = 0f;

        }
    }


    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(0);

        }

    }
}
