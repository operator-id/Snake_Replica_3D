using UnityEngine;

public class Head : MonoBehaviour
{

    private void OnTriggerEnter(Collider otherCollider)
    {
        PlayerBehaviour player = FindObjectOfType<PlayerBehaviour>();
        if (otherCollider.gameObject.tag == "Food")
        {
            player.AddBodyPart();
            player.IncreaseScore(1);
            Destroy(otherCollider.transform.parent.gameObject);

            FindObjectOfType<CoinSpawner>().SpawnCoin();
        }
        else
        {
            if (player.TimeSinceStart > PlayerBehaviour.invulnerabilityTime)
            {
                if (otherCollider.tag == "Coin")
                {
                    Debug.Log("Player collided with a body part BUT NOT DETECTED");
                    if (player.BodyParts.Count > 3)
                    {
                        
                        if (player.BodyParts[1].BodyTransform != otherCollider.transform)
                        {
                            Debug.Log("Player collided with a body");
                            FindObjectOfType<UIManager>().LoadDeathScreen();
                        }
                    }

                }
                else
                {
                    Debug.Log("Player collided with " + otherCollider.name);
                    FindObjectOfType<UIManager>().LoadDeathScreen();
                }
            }

        }
    }

}
