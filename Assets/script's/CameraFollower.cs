using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;

    void Update()
    {
        if(targetPlayer.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, targetPlayer.position.y, transform.position.z);
        }
    }
}
