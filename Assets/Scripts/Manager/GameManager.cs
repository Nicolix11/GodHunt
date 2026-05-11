using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public event EventHandler OnRoundFinished;
    public event EventHandler OnRoundLost;


    private void Awake()
    {
        instance = this;
    }

    private void FinishedRound()
    {
        OnRoundFinished?.Invoke(this, EventArgs.Empty);
    }

    private void LostRound()
    {
        OnRoundLost?.Invoke(this, EventArgs.Empty);
    }
}
