using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance
    {
        get { return s_Instance; }
    }

    protected static PlayerController s_Instance;




    public PlayerUI wetness;

    public float moveSpeed;
    public float vMoveSpeed;
    [HideInInspector]
    public float normalSpeed;
    [HideInInspector]
    public float vnormalSpeed;
    
    public float jumpSpeed;
    [HideInInspector]
    public float normalJumpSpeed;
    public float boosterSpeed;
    private Rigidbody2D myRidigBody;
    private Animator myAnim;
   
    public Transform waterCheck;
    public float waterCheckRadius;
    public Transform groundCheck;
    public float groundCheckRadius;
    public GameObject waterBall;
    public Transform waterBallPos;
    public Transform wetnessCheck;
    public float wetnessCheckRadius;
    
    public LayerMask whatIsGround;
    public LayerMask whatIsWater;

    int watergunPrefs;
    public bool inWater;
    public float waterTimerForSound;
    public bool isGrounded;
    public bool wetnessRefresh;
    public bool waterGun;
    public bool verticalWaterControl = true;
    Vector2 mousePos;

    //[SerializeField]
    //bool dontMoveHorizontally = false;
    

    void Start () {
		myRidigBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        waterGun = false;
        normalSpeed = moveSpeed;
        vnormalSpeed = vMoveSpeed;
        normalJumpSpeed = jumpSpeed;
        }

    private void Update()
    {

        if (Input.GetButtonDown("Jump") && isGrounded == true/* && inWater == false*/)
        {
            myRidigBody.velocity = new Vector2(myRidigBody.velocity.x, jumpSpeed);
            
            FindObjectOfType<AudioManager>().Play("Player Jump");
            
        }
       

        if (myRidigBody.velocity.y < 0 && inWater == false)
        {
            myRidigBody.velocity += Vector2.up * Physics2D.gravity.y * (1.75f - 1f) * Time.deltaTime;
        }

        
       


        
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);
        wetnessRefresh = Physics2D.OverlapCircle(wetnessCheck.position, wetnessCheckRadius, whatIsWater);
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        
        // if i want to prevent continuous horizontal movement
        ////if (mousePos.x>=.41f && mousePos.x <= .59f)
        ////{
        ////    dontMoveHorizontally = true;
        ////}
        ////else
        ////{
        ////    dontMoveHorizontally = false;
        ////}
        ////if (Input.GetKey(KeyCode.Mouse0) && waterGun == true && dontMoveHorizontally == true)
        ////{
        ////    wetness.wetness -= .5f;
        ////    WaterBalls();
        ////}



        // movment right
        if (Input.GetKey(KeyCode.Mouse0) && waterGun == true && mousePos.x <= .5f)
        {
            myRidigBody.AddForce(new Vector2(300,0));
            //myRidigBody.velocity += Vector2.up * Physics2D.gravity.y * (0.8f - 1f) * Time.deltaTime;
            wetness.wetness -= .5f;
            WaterBalls();

           
            //movement left
        }else if(Input.GetKey(KeyCode.Mouse0) && waterGun == true && mousePos.x >= .5f)
        {
            myRidigBody.AddForce(new Vector2(-300, 0));
            //myRidigBody.velocity += Vector2.up * Physics2D.gravity.y * (.8f - 1f) * Time.deltaTime;
            wetness.wetness -= .5f;
            WaterBalls();
        }
        
        //movement up
        if(Input.GetKey(KeyCode.Mouse0) && waterGun == true && mousePos.y <= .5f)
        {
            myRidigBody.AddForce(new Vector2(0, 10));
            myRidigBody.velocity += Vector2.up * Physics2D.gravity.y * (.8f - 1f) * Time.deltaTime;

        }
        // movement down
        else if(Input.GetKey(KeyCode.Mouse0) && waterGun == true && mousePos.y >= .5f)
        {
            myRidigBody.AddForce(new Vector2(0, -10));
            myRidigBody.velocity += Vector2.up * Physics2D.gravity.y * (1.75f - 1f) * Time.deltaTime;
        }


        Movement();

    }

    void WaterBalls()
    {

            GameObject projectile = Instantiate(waterBall, waterBallPos.position, Quaternion.identity);
       
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        myAnim.SetFloat("Speed", Mathf.Abs(myRidigBody.velocity.x));
        myAnim.SetBool("Grounded", isGrounded);
        myAnim.SetBool("Watered", inWater);


        if (Input.GetButtonDown("Interact"))
        {


            Debug.Log("interact pressed");
        }

        if (Input.GetAxis("Horizontal") > 0f)
        {
            myRidigBody.velocity = new Vector2((moveSpeed * horizontal * Time.deltaTime), myRidigBody.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
            
        }

        else if(Input.GetAxis("Horizontal") < 0f)
        {
            myRidigBody.velocity = new Vector2(moveSpeed * horizontal * Time.deltaTime, myRidigBody.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            
        }
        else
        {
            myRidigBody.velocity = new Vector2(0f, myRidigBody.velocity.y);
            
        }
  
        // water movement


        if (Input.GetAxis("Vertical") > 0f && inWater && verticalWaterControl == true)
        {
            myRidigBody.velocity = new Vector2(myRidigBody.velocity.x, vMoveSpeed * vertical * Time.deltaTime);
        }

        
        if (Input.GetAxis("Vertical") < 0f && inWater && verticalWaterControl == true)
        {
            myRidigBody.velocity = new Vector2(myRidigBody.velocity.x, (vMoveSpeed * vertical * Time.deltaTime));
        }
       


        
    }

    public void WaterEnterSound()
    {
        FindObjectOfType<AudioManager>().Play("Water Enter");
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Water")
        {
            WaterEnterSound();
        }
        if (inWater == true)
        {
            FindObjectOfType<AudioManager>().Stop("Water Enter");

        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {


        if (other.tag == "Water")
        {

            WaterEnterSound();
        }
        if (inWater == true)
        {
            FindObjectOfType<AudioManager>().Stop("Water Enter");
            return;
        }

    }

    public void UnSetBool()
    {
        myAnim.SetBool("Cloud", false);
    }


}
