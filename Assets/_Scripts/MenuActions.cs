using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuActions : MonoBehaviour
{
    public GameObject endGameMenu;

    public void IniciaJogo()
    {
        GameControler.Init();
        SceneManager.LoadScene(1);

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
