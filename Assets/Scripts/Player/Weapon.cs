using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // This script for destroy fire after shooting 

    public float speed;
    public float destroyDelay;
    
   

    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(this.gameObject);
       
    }


    //destroy enemy when hit fire 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        
        }
    }
}
