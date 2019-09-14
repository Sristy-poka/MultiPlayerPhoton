using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviourPun,IPunObservable
{
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //   throw new System.NotImplementedException();

        if (stream.IsWriting)
        {
            stream.SendNext(transform.position.x);
            
       

        }
        else if (stream.IsReading)
        {

            xPosOpponent = (float)stream.ReceiveNext();
            Debug.Log("x pox opponent: " + xPosOpponent);
        }
    }

    public Vector3 OwnPlayerPosition;
    public Vector3 OtherPlayerPosition;

    public GameObject ownName;
    public GameObject opponentName;

    PhotonView pv;

    public string PlayerName;
    public float xPosOpponent;

    // Start is called before the first frame update
    void Start()
    {
        
        pv = GetComponent<PhotonView>();
        ownName = GameObject.Find("Player1Name");
        opponentName = GameObject.Find("Player2Name");
        if (photonView.IsMine)
        {
            Debug.Log("Local Player ID: " + pv.ViewID);
            transform.position = OwnPlayerPosition;
            ownName.GetComponent<Text>().text = PhotonNetwork.NickName;
        }
        else 
        {
            Debug.Log("Other Player ID: " + pv.ViewID);
            transform.position = OtherPlayerPosition;
            Debug.Log("other player name: " + pv.Owner.NickName);
            opponentName.GetComponent<Text>().text = pv.Owner.NickName;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (photonView.IsMine)
        {
            transform.position = new Vector3(transform.position.x + h,transform.position.y,transform.position.z);
        }
        else
        {
            transform.position = new Vector3(xPosOpponent, transform.position.y * -1f, transform.position.z);
        }
    }
}
