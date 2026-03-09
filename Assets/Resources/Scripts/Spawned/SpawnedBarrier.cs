using System;
using UnityEngine;

public class SpawnedBarrier : MonoBehaviour
{
    [SerializeField] private GameObject tableBlank;
    [SerializeField] private GameObject tableBook;
    [SerializeField] private GameObject column;
    [SerializeField] private GameObject cratesRight;
    [SerializeField] private GameObject cratesLeft;

    private GameObject selectedObject;
    private int randomIndex;
    private int maxRandomIndexObjects = 2;
    private int maxRandomIndexBarriers = 4;
    private bool isBarrierChosen;
    private Quaternion rotation;

    private void Awake()
    {
        rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        randomIndex = UnityEngine.Random.Range(0, maxRandomIndexObjects);
        switch (randomIndex) // Choosing object type
        {
            case 0:
                selectedObject = null;
                break; // No object will be spawned
            case 1:
                isBarrierChosen = true;
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

