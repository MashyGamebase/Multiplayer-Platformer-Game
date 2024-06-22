using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WebSocketSharp;

public class JoinAndCreateRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    public void CreateRoom()
    {
        if (createInput.text.IsNullOrEmpty())
        {
            Debug.LogError("Room name must not be empty");
            return;
        }

        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        if (joinInput.text.IsNullOrEmpty())
        {
            Debug.LogError("Room name must not be empty");
            return;
        }

        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
        base.OnJoinedRoom();
    }
}