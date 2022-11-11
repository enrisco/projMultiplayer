using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class MainController : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject btnHost;
    [SerializeField] GameObject btnClient;
    [SerializeField] GameObject btnExit;
    [SerializeField] GameObject pnlHost;
    [SerializeField] GameObject pnlClient;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHostButtonClicked()
    {
        btnHost.SetActive(false);
        btnClient.SetActive(false);
        btnExit.SetActive(false);
        pnlHost.SetActive(true);
    }

    public void OnClientButtonClicked()
    {
        NetworkManager.Singleton.StartClient();
        btnHost.SetActive(false);
        btnClient.SetActive(false);
        btnExit.SetActive(false);
        pnlClient.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnTwoPlayersButtonClicked() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        NetworkManager.Singleton.StartHost();
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
