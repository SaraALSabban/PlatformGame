using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //This script for player controller

    public float speed; 
    public float forceJump;
    Animator animPlayer;
   public bool isMove;
    public bool isJump;
    SpriteRenderer spriteRen;
    public GameObject weaponR, weaponL;
    Rigidbody2D rigid;
    public Transform weaponRPos, weaponLPos; //weapon position
    public float delayReset;
    public int livePlayer;
    public bool isHurt;
    public int crystal;

    public static Player instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       

        Move();
        

        if (Input.GetButtonDown("Vertical") )
        {
            
            Jump();
        }


        if (Input.GetButtonDown("Fire3"))
        {
            animPlayer.SetInteger("anim", 5);
            Throw();

        }

        


    }




    //move player left and right
    private void Move()
    {
       

        float horizontal = Input.GetAxis("Horizontal") * speed;
        
        horizontal *= Time.deltaTime;

        if (horizontal > 0 ) 
        {
            
            spriteRen.flipX = false;
            animPlayer.SetInteger("anim", 1);
            
        }

        if (horizontal == 0)
        {
            
            animPlayer.SetInteger("anim", 0);
            

        }

        if (horizontal < 0)
        {
            
            spriteRen.flipX = true;
            animPlayer.SetInteger("anim", 1);
           

        }


        transform.Translate(horizontal, 0, 0);

        
       

    }

    //jump player
    private void Jump()
    {
        animPlayer.SetInteger("anim", 2);
        rigid.AddForce(Vector2.up*forceJump);


      


    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(delayReset);
        isJump = false;

       
    }

    private void Throw()
    {

        if (spriteRen.flipX == false)
        {
            Instantiate(weaponR, weaponRPos.position, Quaternion.identity);
        }

        if (spriteRen.flipX == true)
        {
            Instantiate(weaponL, weaponLPos.position, Quaternion.identity);
        }

    }

    IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(0.2f);
        speed = 0;


    }


    private void LivePlayer()
    {

        if (livePlayer == 0)
        {
            StartCoroutine("ResetSpeed");
            livePlayer = 0;
             animPlayer.SetTrigger("IsDeath");
            //animPlayer.SetBool("isdying", true);

        }

       
        //animPlayer.SetBool("isHurt", true);

        livePlayer--;

       



        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animPlayer.SetInteger("anim", 4);
            UIManager.instance.LoseLive();

            //  animPlayer.SetInteger("anim", 4);

            LivePlayer();

            

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            UIManager.instance.SetPlaneShow();
            speed = 0;
        
        }

        if (collision.gameObject.tag == "Crystal")
        {
            Destroy(collision.gameObject);
            crystal++;
            UIManager.instance.Crystal();
        }
    }

}
