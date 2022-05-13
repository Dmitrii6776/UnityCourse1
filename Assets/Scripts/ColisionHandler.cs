using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionHandler : MonoBehaviour
{
    [Tooltip("in seconds")] [SerializeField]  float loadLevelDelay;

    [Tooltip("Explosion effect")] [SerializeField] private GameObject fxExplosion;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        StartGameOver();
        fxExplosion.SetActive(true);
        Invoke("RestartLevel", loadLevelDelay);
    }

    void StartGameOver()
    {
        SendMessage("OnPlayerGameOver");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}   

