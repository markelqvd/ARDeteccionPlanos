using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    // Método que se llama cuando se hace clic en el botón
    public void LoadMainMenu()
    {
       
        SceneManager.LoadScene("Scene3");
    }
}
