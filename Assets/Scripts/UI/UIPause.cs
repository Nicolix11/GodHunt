using System;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;

    private bool isGamePaused;


    private void Start()
    {
        CharacterController.instance.PauseGame += CharacterController_OnPauseGame;

        isGamePaused = false;
    }

    private void CharacterController_OnPauseGame(object sender, EventArgs e)
    {
        Pause();
    }

    public void Pause()
    {
        if (!isGamePaused)
        {
            DisableUI(pauseButton);
            EnableUI(pauseMenu);
            isGamePaused = !isGamePaused;
        }
        else
        {
            DisableUI(pauseMenu);
            EnableUI(pauseButton);
            isGamePaused = !isGamePaused;
        }
    }

    private void EnableUI(GameObject inputObject)
    {
        inputObject.SetActive(true);
    }

    private void DisableUI(GameObject inputObject)
    {
        inputObject.SetActive(false);
    }
}
