using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmationCanvas : MonoBehaviour
{
    private string sceneToLoad;

    // Asigna el nombre de la escena al script
    public void SetSceneToLoad(string sceneName)
    {
        sceneToLoad = sceneName;
    }

    // Cambia la escena
    public void ConfirmChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    // Cierra el Canvas sin cambiar la escena
    public void CancelChangeScene()
    {
        gameObject.SetActive(false); // Oculta el Canvas de confirmación
    }
}
