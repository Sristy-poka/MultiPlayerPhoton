using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class UIHandler : MonoBehaviourPunCallbacks
{

    public InputField createRoomInputText;
    public InputField joinRoomInputText;
    public InputField giveYourName;

    public string PlayerName;

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomInputText.text,null);
    }

    public void OnClickCreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomInputText.text, new RoomOptions { MaxPlayers = 4 }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("room joined");
        SingletonMessage.SM.joinedPlayer = true;
        PhotonNetwork.LoadLevel(1);
       // base.OnJoinedRoom();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("error code: " + returnCode + " /n error message: " + message );
        //  base.OnJoinRoomFailed(returnCode, message);
    }

    public void SetPlayerName()
    {

        PlayerPrefs.SetString("PlayerName", giveYourName.text);
        yourNameObject.gameObject.SetActive(false);
        showName.gameObject.SetActive(true);
        showName.gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("PlayerName");
        PhotonNetwork.NickName = PlayerPrefs.GetString("PlayerName"); 
    }

    public GameObject yourNameObject;
    public GameObject showName;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("PlayerName") == "")
        {
            yourNameObject.gameObject.SetActive(true);
            showName.gameObject.SetActive(false);
        }
        else
        {
            yourNameObject.gameObject.SetActive(false);
            showName.gameObject.SetActive(true);
            showName.gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("PlayerName");
            PhotonNetwork.NickName = PlayerPrefs.GetString("PlayerName");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
