using UnityEngine;


public class Controller : MonoBehaviour
{


    public Vector3 jumpDir;
    public float jumpForce, jumpForceMultiplier, maxJumpForce, minJumpForce;
    

    [SerializeField] private Canvas forceIndicatorCanvas;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayerMask;
    [SerializeField] private bool isGrounded;



    private Rigidbody rb;


    void Start()
    {       
        jumpForce = 0;
        rb = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
        forceIndicatorCanvas.gameObject.SetActive(false);
        rb.interpolation = RigidbodyInterpolation.Interpolate;

    }



    private void Update()
    {
        HandleInput();      
    }



    void FixedUpdate()
    {     

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundCheckLayerMask);
        
    }


    
    void HandleInput()
    {
        if (Input.GetMouseButton(0) && isGrounded)
        {
            forceIndicatorCanvas.gameObject.SetActive(true);

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


        //When Finger Is Released
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
        forceIndicatorCanvas.gameObject.SetActive(false);

    }

}
