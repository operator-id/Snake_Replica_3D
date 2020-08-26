using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle" || other.tag == "Food" || other.tag == "Coin")
        {
            Debug.Log("Other obstacle in place");
            Destroy(gameObject.transform.parent.gameObject);
            //spawn in another place to-do
            FindObjectOfType<CoinSpawner>().SpawnCoin();
        }
    }
}
