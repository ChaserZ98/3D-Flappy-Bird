using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rigidbody2d;

    GameController gameController;

    public GameObject look;

    public float speed = 10f;

    public float rowBaiFen = 1f;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        look.transform.DORotateQuaternion(new Quaternion(0, 0, rigidbody2d.velocity.y * rowBaiFen, 1), 0.3f);
        if (!gameController.isGameStart) return;
        if (Input.GetMouseButtonDown(0))
        {
            Fly();
        }
    }
    public void toFly()
    {
        rigidbody2d.simulated = true;
        animator.applyRootMotion = true;
        animator.SetInteger("State", 1);
    }

    public void Death()
    {
        animator.speed = 0;
    }

    public void Fly()
    {
        if (!gameController.isGameStart) return;
        rigidbody2d.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameController.isGameStart) return;
        if (collision.gameObject.tag == "ZhuZi")
        {
            Fly();
            gameController.GameOver();
        }
        if (collision.gameObject.tag == "PointTrigger")
        {
            gameController.score++;
            gameController.SetScore(gameController.score);
        }
    }
}
