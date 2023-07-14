using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 endPosition;



	
	// Update is called once per frame
	void Update () {
        if (!PlayerMovement.isEnd)
        {
            Vector3 pos = transform.position;
            pos.x = target.position.x;
            pos.y = target.position.y + 1;
            transform.position = pos;
        }
        else
        
            transform.position = endPosition;   
	}
}
