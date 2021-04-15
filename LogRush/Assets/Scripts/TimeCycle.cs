using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    public Sprite[] LandSprites;
    public Sprite[] SkySprites;
    public Sprite[] WaterSprites;
    public GameObject Land;
    public GameObject Sky;
    public GameObject Water;

    private int timeState = 0;
    private float timePassed = 0f;

    private void Update()
    {
        timePassed += Time.deltaTime;

        switch (timeState)
        {
            case 0:
                if (timePassed >= 30)
                {
                    Land.GetComponent<SpriteRenderer>().sprite = LandSprites[1];
                    Sky.GetComponent<SpriteRenderer>().sprite = SkySprites[1];
                    Water.GetComponent<SpriteRenderer>().sprite = WaterSprites[1];
                    
                    timeState = 1;
                }
                break;

            case 1:
                if (timePassed >= 60)
                {
                    Land.GetComponent<SpriteRenderer>().sprite = LandSprites[2];
                    Sky.GetComponent<SpriteRenderer>().sprite = SkySprites[2];
                    Water.GetComponent<SpriteRenderer>().sprite = WaterSprites[2];
                    timeState = 2;
                }
                break;

            case 2:
                if (timePassed >= 90)
                {
                    Land.GetComponent<SpriteRenderer>().sprite = LandSprites[0];
                    Sky.GetComponent<SpriteRenderer>().sprite = SkySprites[0];
                    Water.GetComponent<SpriteRenderer>().sprite = WaterSprites[0];
                    timeState = 0;
                    timePassed = 0;
                }
                break;

            default:
                break;
        }
    }
}
