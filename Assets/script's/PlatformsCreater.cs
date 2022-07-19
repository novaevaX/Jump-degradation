using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsCreater : MonoBehaviour
{
    [SerializeField] private GameObject platformStandart;
    [SerializeField] private GameObject platformBigJump;
    [SerializeField] private GameObject platformRemove;
    [SerializeField] private Transform cameraTransform;

    private Vector2 min;
    private Vector2 max;

    private float randomMaxRange = 1f;
    private float numberRandom;
    private void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));

        Instantiate(platformStandart, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), max.y), Quaternion.identity);
        Instantiate(platformStandart, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), max.y * .75f), Quaternion.identity);
        Instantiate(platformStandart, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), max.y * .5f), Quaternion.identity);
        Instantiate(platformStandart, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), max.y * .25f), Quaternion.identity);
        Instantiate(platformStandart, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), 0), Quaternion.identity);
        Instantiate(platformStandart, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), min.y * .25f), Quaternion.identity);
        Instantiate(platformStandart, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), min.y * .5f), Quaternion.identity);

    }

    private void Update()
    {
        CountStandartPlatform();
        wathingCameraPositionY();
    }

    private void CountStandartPlatform()
    {
        GameObject[] platformSt = GameObject.FindGameObjectsWithTag("platform");
        GameObject[] platformBJ = GameObject.FindGameObjectsWithTag("platformJump");
        if ((platformSt.Length + platformBJ.Length) < 8)
        {
            numberRandom = Random.Range(0f, randomMaxRange);
            if (numberRandom < .93f)
            {
                Instantiate(platformStandart, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), cameraTransform.position.y + max.y), Quaternion.identity);
            }
            else if (numberRandom >= .93f && numberRandom <= 1f)
            {
                Instantiate(platformBigJump, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), cameraTransform.position.y + max.y), Quaternion.identity);
            }
            else if (numberRandom > 1f && numberRandom >= 1.93f)
            {
                Instantiate(platformRemove, new Vector2(Random.Range(min.x + (max.x / 10), max.x - (max.x / 10)), cameraTransform.position.y + max.y), Quaternion.identity);
            }
        }
    }

    private void wathingCameraPositionY()
    {
        if (cameraTransform.position.y >= 50f)
        {
            randomMaxRange = 1.93f;
        }
    }
}
