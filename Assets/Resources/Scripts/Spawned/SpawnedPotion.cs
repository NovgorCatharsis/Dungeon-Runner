using System;
using UnityEngine;

public class SpawnedPotion : MonoBehaviour
{
    [SerializeField] private GameObject potion;

    private int randomIndex;

    private void Awake()
    {
        randomIndex = UnityEngine.Random.Range(0, 2);
        if (randomIndex == 1) Instantiate(potion, new Vector3(transform.position.x,1.5f, transform.position.z), Quaternion.identity); //50% chance to spawn a potion
        Destroy(gameObject);
    }


}

