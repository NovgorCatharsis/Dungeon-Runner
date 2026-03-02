using UnityEngine;

public class SpawnSection : MonoBehaviour
{
    [SerializeField] private GameObject DungeonSectionLit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered spawn trigger");
            Instantiate(DungeonSectionLit, new Vector3 (transform.position.x+51,0,0), Quaternion.identity);
        }
    }
}

