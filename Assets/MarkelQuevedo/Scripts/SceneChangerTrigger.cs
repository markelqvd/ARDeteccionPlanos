using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerTrigger : MonoBehaviour
{
    [SerializeField] private GameObject confirmationCanvas; // El Canvas de confirmación
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa el Canvas de confirmación al detectar la colisión
            confirmationCanvas.SetActive(true);
            // Pasa el nombre de la escena al Canvas para saber cuál cargar
            confirmationCanvas.GetComponent<ConfirmationCanvas>().SetSceneToLoad(sceneToLoad);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            confirmationCanvas.SetActive(false);

        }
    }
}