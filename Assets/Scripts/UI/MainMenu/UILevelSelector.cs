using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
