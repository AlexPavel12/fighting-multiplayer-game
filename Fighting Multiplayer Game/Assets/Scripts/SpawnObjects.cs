using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private Text HPTextLeft, HPTextRight;
    public GameObject playerPrefab;
    private GameObject playerOne, playerTwo;

    public Vector3 playerSpawnPositionLeft, playerSpawnPositionRight;
    public Vector3 playerSpawnRotationLeft, playerSpawnRotationRight;

    private void Start()
    {
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, playerSpawnPositionLeft, Quaternion.Euler(playerSpawnRotationLeft));
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, playerSpawnPositionRight, Quaternion.Euler(playerSpawnRotationRight));
        }
    }
}
