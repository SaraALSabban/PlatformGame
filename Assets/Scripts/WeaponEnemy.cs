using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    //This scrip for weapon enemy 

    public float speed; // speed of weapon
    public float destroyDelay;  //delay time
  

   
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
}
