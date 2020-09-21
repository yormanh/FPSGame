using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FPSGameManager : MonoBehaviour
{

    [SerializeField] GameObject _playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {

            if (_playerPrefab != null)
            {
                PhotonNetwork.Instantiate(_playerPrefab.name, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.Log("Error no encontrado el _playerPrefab");
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
