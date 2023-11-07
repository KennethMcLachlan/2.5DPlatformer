using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();

            if (player != null)
            {
                player.AddCoins();
            }
            Debug.Log("Player has collected a coin");
            Destroy(gameObject);
        }
        //give the Player a coin
        //Notify UI
        //Destory this object

    }
}
