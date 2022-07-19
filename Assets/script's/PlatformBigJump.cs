using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformBigJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyPlayer;

    private float jumpForce;
    private Vector2 min;
    private Vector2 max;

    private void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        max = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        jumpForce = (-min.y + max.y) * 2f;
        Debug.Log(jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbodyPlayer = collision.collider.GetComponent<Rigidbody2D>();

        if (collision.relativeVelocity.y <= 0) {
            if (collision.gameObject.CompareTag("Player"))
            {
                rigidbodyPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            } 
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
