using UnityEngine;

public class SpawnSection : MonoBehaviour
{
    //[SerializeField] private GameObject DungeonSectionLit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player entered spawn trigger");
            GameObject dungeonSectionLit = Resources.Load<GameObject>("Prefabs/Dungeon_Section_Lit");
            Instantiate(dungeonSectionLit, new Vector3 (transform.position.x+51, 0, 0), Quaternion.identity);
        }
    }
}

