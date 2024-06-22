using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class NetworkHandler : MonoBehaviourPunCallbacks
{
    public GameObject loadingText, lobbyPanel;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        base.OnConnectedToMaster();
    }

    public override void OnJoinedLobby()
    {
        loadingText.SetActive(false);
        lobbyPanel.SetActive(true);
        base.OnJoinedLobby();
    }
}