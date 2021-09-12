using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnObjects : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 spawnPosition;

    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, playerPrefab.transform.rotation);
    }
}
