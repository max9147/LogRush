using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public GameObject logSpawner;
    public GameObject loseScreen;
    public GameObject startPlatform;
    public GameObject UIControls;
    public Animator animator;
    public Image HP1;
    public Image HP2;
    public Image HP3;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    private int hp = 6;
    private float curPos;
    private bool isJumping = false;
    private bool onLog = false;
    private bool safe = true;
    private Touch touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (touch.phase == TouchPhase.Began && !isJumping)
            {
                animator.speed = 1 / logSpawner.GetComponent<LogSpawner>().GetSpawnDelay();
                animator.SetTrigger("Jump");
                isJumping = true;
                StartCoroutine(Jump());
            }

            touch = Input.GetTouch(0);
            Vector3 touchPos = cam.ScreenToWorldPoint(touch.position);
            curPos = touchPos.x;

            if (curPos > 1.4f)
            {
                curPos = 1.4f;
            }
            else if (curPos < -1.4f)
            {
                curPos = -1.4f;
            }

            Vector3 targetPos = new Vector3(curPos, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Log"))
        {
            onLog = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Log"))
        {
            if (!isJumping && !safe)
            {
                TakeDamage();
            }
            onLog = false;
        }

        if (collision.transform.CompareTag("Platform"))
        {
            safe = false;
            if (!onLog)
            {
                TakeDamage();
            }
        }
    }

    private void TakeDamage()
    {
        hp--;

        if (hp == 0)
        {
            HP1.sprite = heartEmpty;
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            UIControls.GetComponent<UIControls>().FinalScore();
        }
        else
        {
            switch (hp)
            {
                case 1:
                    HP1.sprite = heartHalf;
                    break;

                case 2:
                    HP2.sprite = heartEmpty;
                    break;

                case 3:
                    HP2.sprite = heartHalf;
                    break;

                case 4:
                    HP3.sprite = heartEmpty;
                    break;

                case 5:
                    HP3.sprite = heartHalf;
                    break;

                default:
                    break;
            }

            safe = true;
            onLog = false;
            GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("Log");
            foreach (var item in toDestroy)
            {
                Destroy(item);
            }
            Instantiate(startPlatform, new Vector3(0, -3.8f, 0), Quaternion.identity);
            gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(logSpawner.GetComponent<LogSpawner>().GetSpawnDelay() * 0.8f);
        if (!onLog && !safe)
        {
            TakeDamage();
        }
        isJumping = false;
    }
}