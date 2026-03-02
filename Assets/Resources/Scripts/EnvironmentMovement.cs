using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RemoveTrigger"))
        {
            Debug.Log("Section entered remove trigger");
            Destroy(gameObject);
        }
    }
}

