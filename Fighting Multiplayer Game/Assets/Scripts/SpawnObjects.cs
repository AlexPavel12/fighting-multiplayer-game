using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SpawnObjects : MonoBehaviour
{
    public GameObject playerPrefab;

    public Vector3 playerSpawnPositionLeft, playerSpawnPositionRight;
    public Vector3 playerSpawnRotationLeft, playerSpawnRotationRight;

    private void Start()
    {
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, playerSpawnPositionLeft, Quaternion.Euler(playerSpawnRotationLeft));
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, playerSpawnPositionRight, Quaternion.Euler(playerSpawnRotationRight));
        }
    }
}
