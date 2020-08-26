using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Time.time > PlayerBehaviour.invulnerabilityTime)
        {
            if (other.tag != "Food")
            {
                if (other.tag != "Coin")
                {
                    Debug.Log("Body collided with " + other.name);
                    FindObjectOfType<UIManager>().LoadDeathScreen();
                }
            }
        }
    }
}
