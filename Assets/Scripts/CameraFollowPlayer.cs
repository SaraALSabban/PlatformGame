using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
   // This script is to make the camera follow the player


    public Transform target;   // The target the camera follows is the player
    public float offsetX, offsetY; //offset distance from X and Y;

    void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x +offsetX, offsetY , this.transform.position.z);


    }
}
