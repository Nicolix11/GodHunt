using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;

    private bool isGamePaused;


    private void Start()
    {
        PlayerController.instance.PauseGame += CharacterController_OnPauseGame;

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
            Time.timeScale = 0;
        }
        else
        {
            DisableUI(pauseMenu);
            EnableUI(pauseButton);
            isGamePaused = !isGamePaused;
            Time.timeScale = 1;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
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
