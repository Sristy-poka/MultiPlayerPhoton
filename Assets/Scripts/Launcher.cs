using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject ConnectedPanel;
    public GameObject DisconnectedPanel;

    public Button ConnectToServerBtn;



    // Start is called before the first frame update
    private void Start()
    {
        OnClickConnectBtn();
    }


    public void OnClickConnectBtn()
    {
        PhotonNetwork.ConnectUsingSettings();
        //ConnectToServerBtn.GetComponentInChildren<Text>().text = "Connecting..";
    }

    public override void OnConnectedToMaster()
    {
        
        PhotonNetwork.JoinLobby();
        ConnectToServerBtn.GetComponentInChildren<Text>().text = "Connect to server";
        //        base.OnConnectedToMaster();
    }

    public override void OnJoinedLobby()
    {
        if (DisconnectedPanel.activeInHierarchy)
        {
            DisconnectedPanel.gameObject.SetActive(false);
        }
        ConnectedPanel.gameObject.SetActive(true);
        //  base.OnJoinedLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        DisconnectedPanel.gameObject.SetActive(true);
        ConnectedPanel.gameObject.SetActive(false);
        //   base.OnDisconnected(cause);
    }
}
