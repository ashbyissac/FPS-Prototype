using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    bool isGameOver = false;

    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        FindObjectOfType<Weapon>().enabled = false;
        isGameOver = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
