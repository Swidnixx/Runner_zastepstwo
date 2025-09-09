using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        if(GameManager.Instance.Magnet.IsActive)
        {
            float distance = Vector2.Distance(player.position, transform.position);
            if( distance < GameManager.Instance.Magnet.Range)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    player.position,
                    GameManager.Instance.Magnet.Speed * Time.deltaTime);
            }
        }
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
