using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UserMovement : MonoBehaviour
{

    private PhotonView PV;
    private CharacterController cc;
    public GameObject myCamera;

    public Transform vrCamera;
    float speed = 5.0f;
    float toggleAngle = 20.0f;
    bool moveForward;

    public TextMeshPro userName;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        cc = GetComponent<CharacterController>();
        if(PV.IsMine)
        {
            myCamera.SetActive(true);
        }

        //set user nick name
       PhotonNetwork.NickName = databaseManager.DM.userName;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            BasicMovement();
        }

        //display user nick name on top of user
        userName.text = PV.Owner.NickName;
        
    }


    void BasicMovement()
    {
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90)
        {
            moveForward = true;

        }
        else
        {
            moveForward = false;
        }

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }

}
