using UnityEngine;
using UnityEngine.SceneManagement;

class SceneLoading : MonoBehaviour
{
    public static void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreenScene");
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
