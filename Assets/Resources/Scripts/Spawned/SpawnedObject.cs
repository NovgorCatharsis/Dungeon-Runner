using System;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    [SerializeField] private GameObject tableBlank;
    [SerializeField] private GameObject tableBook;
    [SerializeField] private GameObject column;
    [SerializeField] private GameObject cratesRight;
    [SerializeField] private GameObject cratesLeft;
    [SerializeField] private GameObject potion;

    private GameObject selectedObject;
    private int randomIndex;
    private int maxRandomIndexObjects = 3;
    private int maxRandomIndexBarriers = 5;
    private bool isBarrierChosen;
    private Quaternion rotation;

    private void Awake()
    {
        rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        randomIndex = UnityEngine.Random.Range(0, maxRandomIndexObjects);
        Debug.Log(randomIndex);
        switch (randomIndex) // Choosing object type
        {
            case 0:
                selectedObject = null;
                break; // No object will be spawned
            case 1:
                selectedObject = potion; // A potion will be spawned
                transform.position += new Vector3(0, 1f, 0);
                break;
            case 2:
                isBarrierChosen = true; // A barrier will be spawned
                break;
        }

        if (isBarrierChosen) // If a barrier is chosen, we need to determine which one
        {
            randomIndex = UnityEngine.Random.Range(0, maxRandomIndexBarriers); // gives a random number between 0 and maxRandomIndex (exclusive)
            switch (randomIndex)
            {
                case 0:
                    selectedObject = tableBlank;

                    randomIndex = UnityEngine.Random.Range(0, 2);
                    if (randomIndex == 1) rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case 1:
                    selectedObject = tableBook;

                    randomIndex = UnityEngine.Random.Range(0, 2);
                    if (randomIndex == 1) rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case 2: 
                    selectedObject = column;
                    break;
                case 3:
                    selectedObject = cratesRight;
                    break;
                case 4:
                    selectedObject = cratesLeft;
                    break;
            }
        }

        if (selectedObject != null) Instantiate(selectedObject, transform.position, rotation);
        Destroy(gameObject);
    }


}

