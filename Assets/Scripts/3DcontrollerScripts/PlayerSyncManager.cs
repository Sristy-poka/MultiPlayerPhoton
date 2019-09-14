using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSyncManager : MonoBehaviourPun,IPunObservable
{
    public PhotonView pv;
    public Vector3 opponentCarPosition;
    

    public void transformPosition()
    {
        transform.position = opponentCarPosition;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //   throw new System.NotImplementedException();
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            //stream.SendNext(transform.rotation);
           

        }
        else if (stream.IsReading)
        {
            opponentCarPosition = (Vector3)stream.ReceiveNext();
            
            //  latestRot = (Quaternion)stream.ReceiveNext();
            //  inputFromOpponent = (Vector3)stream.ReceiveNext();

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // pv = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            GetComponent<PlayerControl>().enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
