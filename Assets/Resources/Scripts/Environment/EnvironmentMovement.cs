using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    //[SerializeField] private GameObject playerObject;
    private GameObject playerObject;
    private int environmentSpeed;
    private void Awake()
    {
        environmentSpeed = -4;

        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerObject.GetComponent<PlayerController>().BarrierCollision += StopMovement;
    }

    private void Update()
    {
        transform.position += new Vector3(environmentSpeed, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RemoveTrigger"))
        {
            //Debug.Log("Section entered remove trigger");
            Destroy(gameObject);
        }
    }

    private void StopMovement()
    {
        environmentSpeed = 0;
    }
}

