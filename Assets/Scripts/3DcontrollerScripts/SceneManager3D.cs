using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SceneManager3D : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3 HostPlayerPos;
    public Vector3 JoinedPlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }
    void SpawnPlayer()
    {
        if (!SingletonMessage.SM.joinedPlayer)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, HostPlayerPos, playerPrefab.transform.rotation);
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, JoinedPlayerPos, playerPrefab.transform.rotation);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
