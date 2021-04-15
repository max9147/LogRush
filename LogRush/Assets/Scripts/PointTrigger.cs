using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    public GameObject UIControls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Log"))
        {
            UIControls.GetComponent<ScoreSystem>().AddScore();
        }
    }
}
