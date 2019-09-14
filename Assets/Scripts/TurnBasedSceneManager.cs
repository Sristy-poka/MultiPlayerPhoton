using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TurnBasedSceneManager : MonoBehaviour
{
    public GameObject PlayerGO;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(PlayerGO.name, PlayerGO.transform.position, PlayerGO.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
