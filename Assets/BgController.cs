using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BgController : MonoBehaviour
{
    public GameObject Bg;

    Vector3 InitLocation;

    public float speed = 0.5f;

    public float point = -6.7f;

    public bool isBegin = true;
    private void Start()
    {
        InitLocation = Bg.transform.position;
    }
    private void FixedUpdate()
    {
        if (!isBegin) return;
        if(Bg.transform.position.x <= point)
        {
            Bg.transform.position = InitLocation;
        }
        Bg.transform.Translate(new Vector3(-speed, 0, 0));
    }
}
