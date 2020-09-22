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
                int randomPointZ = Random.Range(-10, 0);
                int randomPointX = Random.Range(-5, 0);

                PhotonNetwork.Instantiate(_playerPrefab.name, new Vector3(randomPointX, 0, randomPointZ), Quaternion.identity);
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
