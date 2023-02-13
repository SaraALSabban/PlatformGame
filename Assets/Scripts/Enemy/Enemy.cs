using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //This script when the enemy is hit by fire from the player it will die
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerFire")
        {
            //destroy enemy after hit fire from player in 0.1f  
            Destroy(this.gameObject, 0.1f);
        
        }
    }
}
