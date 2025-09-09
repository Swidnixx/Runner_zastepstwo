using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.CoinCollect();
            Destroy(gameObject);
        }
    }
}
