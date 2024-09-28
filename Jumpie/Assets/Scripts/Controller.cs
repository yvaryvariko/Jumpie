using UnityEngine;


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
        Application.targetFrameRate = 60;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

    }



    private void Update()
    {
        HandleInput();

        Debug.DrawLine(groundCheck.position, groundCheck.position - new Vector3(0, groundCheckRadius, 0), Color.yellow);  //Draw Ground Check Radius
    }



    void FixedUpdate()
    {     

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundCheckLayerMask);
        
    }


    
    void HandleInput()
    {
        if (Input.GetMouseButton(0) && isGrounded)
        {

            Vector2 mousePositionOnScreen = Input.mousePosition; //get mouse position on screen

            if (mousePositionOnScreen.x < Screen.width / 2f)  //check on which side mouse was pressed and change Jump Direction Accordingly
            {
                jumpDir.x = -Mathf.Abs(jumpDir.x);
            }
            else
            {

                jumpDir.x = Mathf.Abs(jumpDir.x);
            }


            jumpForce = Mathf.Clamp(jumpForce + jumpForceMultiplier * Time.deltaTime, minJumpForce, maxJumpForce);  //calculate Jumpforce


            if (jumpForce >= maxJumpForce)
            {
                Jump();
            }
        }


        //When Press Is Released
        if (Input.GetMouseButtonUp(0) && isGrounded)
        {

            Jump();

        }


    }

    private void Jump()
    {



        rb.velocity = Vector3.zero;
        rb.AddForce(jumpDir * jumpForce, ForceMode.Impulse);
        jumpForce = 0f;

    }

}
