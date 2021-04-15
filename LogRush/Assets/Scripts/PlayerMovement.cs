using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public GameObject logSpawner;
    public GameObject loseScreen;
    public GameObject startPlatform;
    public GameObject UIControls;
    public TextMeshProUGUI hpText;

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
                transform.localScale = new Vector3(8, 8, 1);
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
        hpText.text = $"Жизни: {hp}";

        if (hp == 0)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            UIControls.GetComponent<UIControls>().FinalScore();
        }
        else
        {
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
        transform.localScale = new Vector3(5, 5, 1);
        if (!onLog && !safe)
        {
            TakeDamage();
        }
        isJumping = false;
    }
}
