using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform birdTransform;
	private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - birdTransform.position;
        transform.position = offset + birdTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + birdTransform.position;
        // if(transform.position.y <= 0){
        //     transform.position.y = 0;
        // }
    }
}
