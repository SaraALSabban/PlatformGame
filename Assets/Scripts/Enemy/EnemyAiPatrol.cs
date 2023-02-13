using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiPatrol : MonoBehaviour
{
    //This script for enemy portal ai

    public float speed,speedIdel; 
    Animator enemyAnim;
    SpriteRenderer spriteEnemy; 
    Rigidbody2D rigid;
    public GameObject posA, PosB;  //position a and position b
    private Transform currentPos; 
    public bool isStop;
    public GameObject fireR,fireL;  // fire right and fire left
    public Transform fireRPos, fireLPos;  //position fire from right and left
    public int live;  // number of lives enemy


    
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        spriteEnemy = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        currentPos = PosB.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Moveing();
    }


    //for draw between two point
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(posA.transform.position, new Vector3(1f, 1f, 0));
        Gizmos.DrawWireCube(PosB.transform.position, new Vector3(1f, 1f, 0));
        Gizmos.DrawLine(posA.transform.position, PosB.transform.position);
    }


    //moveing Enemy between two point
    void Moveing()
    {
        
        Vector2 pos = currentPos.position - transform.position;
        
        if (currentPos == PosB.transform)
        {

            if (isStop == false)
            {
                enemyAnim.SetInteger("Enemy", 1);
                rigid.velocity = new Vector2(speed, 0);
            }
               

        }


        else
        {
            
            if (isStop == false)
            {
                enemyAnim.SetInteger("Enemy", 1);
                rigid.velocity = new Vector2(-speed, 0);
            }
               

        }

        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == PosB.transform)
        {
            isStop = true;
            StartCoroutine("IdelStopMove");
            spriteEnemy.flipX = true;
            currentPos = posA.transform;
        
        }

        if (Vector2.Distance(transform.position, currentPos.position) < 0.5f && currentPos == posA.transform)
        {
            isStop = true;
            StartCoroutine("IdelStopMove");
            spriteEnemy.flipX = false;
            currentPos = PosB.transform;

        }
    }



    //for animation idle and stop a little  of time
    IEnumerator IdelStopMove()
    {
        if (isStop)
        {
            enemyAnim.SetInteger("Enemy", 0);
            rigid.velocity = new Vector2(speedIdel, 0);
            yield return new WaitForSeconds(2f);
            Fire();
            isStop = false;
        }
        
    }

    //for fire shooter
    private void Fire()
    {
        enemyAnim.SetInteger("Enemy", 2);

        if (spriteEnemy.flipX == false)
        {
            Instantiate(fireR, fireRPos.transform.position, Quaternion.identity);
        
        }

        if (spriteEnemy.flipX == true)
        {
            Instantiate(fireL, fireLPos.transform.position, Quaternion.identity);

        }
    }



    //for live enemy 
    private void LiveEnemy()
    {
       
        live--;

        if (live == 0)
        {
           enemyAnim.SetTrigger("IsDying");
            Destroy(this.gameObject,1f);
        
        }
    }


    //if hit by fire from player it will die
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerFire")
        {
            enemyAnim.SetInteger("Enemy", 3);

            LiveEnemy();
        }
    }
}
