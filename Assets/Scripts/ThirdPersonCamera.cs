using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    [Range (0,1)]public float lerpValue;
    public float sensitivity;

    void Start(){
        target = GameObject.Find("Player").transform;

    }

    void Update(){

        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X")* sensitivity, Vector3.up)* offset;
        
        transform.LookAt(target);

    }
    
}
