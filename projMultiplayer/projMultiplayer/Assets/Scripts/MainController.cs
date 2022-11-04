using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MainController : MonoBehaviour
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
        NetworkManager.Singleton.StartHost();
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
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
