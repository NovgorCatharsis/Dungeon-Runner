using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)  
    {
        if (collision.gameObject.CompareTag("Potion"))
        {
            Debug.Log("Potion consumed");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("Player collided with a barrier");
        }
        Debug.Log("collision");
    }
}

