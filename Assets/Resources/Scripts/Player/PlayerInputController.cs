using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{

    private void OnDashLeft(InputValue inputValue)
    {
        gameObject.GetComponent<PlayerController>().DashLeft();
    }

    private void OnDashRight(InputValue inputValue)
    {
        gameObject.GetComponent<PlayerController>().DashRight();
    }

    private void OnRestart(InputValue inputValue)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

