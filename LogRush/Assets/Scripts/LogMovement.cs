using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    private float speed;
    private bool ready = false;
    private Vector3 targetPos;

    private void FixedUpdate()
    {
        if (!ready)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, 0f);

            if (transform.position.y >= 2.4f)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 3;
                targetPos = new Vector3(Random.Range(-2f, 2f), -8f, 0f);
                ready = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);

            if (transform.position.y <= -6f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void SetSpeed(float curSpeed)
    {
        speed = curSpeed;
    }
}
