using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject[] _hands;
    [SerializeField] GameObject[] _soldier;

    [SerializeField] Camera _cameraPlayer;
    [SerializeField] Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            foreach (GameObject go in _hands)
                go.SetActive(true);
            foreach (GameObject go in _soldier)
                go.SetActive(false);

            _cameraPlayer.enabled = true;
            GetComponent<RigidbodyFirstPersonController>().enabled = true;
            _animator.SetBool("IsSoldier", false);

        }
        else
        {
            foreach (GameObject go in _hands)
                go.SetActive(false);
            foreach (GameObject go in _soldier)
                go.SetActive(true);

            _cameraPlayer.enabled = false;
            GetComponent<RigidbodyFirstPersonController>().enabled = false;
            _animator.SetBool("IsSoldier", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
