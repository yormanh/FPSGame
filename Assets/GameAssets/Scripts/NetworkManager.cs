using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    [Header("Login Panel")]
    [SerializeField] TMP_InputField _playerInput;
    [SerializeField] GameObject _loginPanel;


    [Header("Info Status")]
    [SerializeField] TextMeshProUGUI _connectionStatusText;
    [SerializeField] TextMeshProUGUI _pingRateText;


    [Header("Connection Panel")]
    [SerializeField] GameObject _connectionStatusPanel;


    [Header("Connection Option Panel")]
    [SerializeField] GameObject _connectionOptionsPanel;



    #region Unity Methods


    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();
        ActivatePanel(_loginPanel.name);
    }

    // Update is called once per frame
    void Update()
    {
        _connectionStatusText.text = "Connection Status: " + PhotonNetwork.NetworkClientState;
        _pingRateText.text = "Ping Rate: " + PhotonNetwork.GetPing();
    }

    #endregion Unity Methods





    #region Photon Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName + " conectado al servidor Photon");
        ActivatePanel(_connectionOptionsPanel.name);
    }


    public override void OnConnected()
    {
        Debug.Log("conectado a internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Error: " + message);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName +  " joined to " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " - " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion Photon Callbacks


    #region Private Methods
    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room" + Random.Range(100, 10000);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;


        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }


    #endregion Private Methods

    #region UI Callbacks

    public void OnLoginButtonClicked()
    {
        string playerName = _playerInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Guest" + Random.Range(100, 10000);
        }


        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
            ActivatePanel(_connectionStatusPanel.name);
        }
        else
        {
            Debug.Log("Error en el playerName");
        }

    }

    public void OnJoinRandomButtonClicked()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    #endregion UI Callbacks



    #region Public Methods

    public void ActivatePanel (string panelToBeActivated)
    {
        _loginPanel.SetActive(panelToBeActivated.Equals(_loginPanel.name));
        _connectionStatusPanel.SetActive(panelToBeActivated.Equals(_connectionStatusPanel.name));
        _connectionOptionsPanel.SetActive(panelToBeActivated.Equals(_connectionOptionsPanel.name));

    }


    #endregion Public Methods



}
