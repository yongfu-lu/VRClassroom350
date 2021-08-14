using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine.SceneManagement;


public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //room info
    public static PhotonRoom room;
    private PhotonView PV;

    public int currentScene = 0;
    public int multiplayerScene = 1;
    public int ForceBalanceScene = 2;
    public int StringConstantScene = 3;

    

    private void Awake()
    {
        //set up singletom
        if (PhotonRoom.room == null)
        {
            PhotonRoom.room = this;
        }
        else
        {
            if (PhotonRoom.room != this)
            {
                Destroy(PhotonRoom.room.gameObject);
                PhotonRoom.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    void OnSceneFinishedLoading ( Scene scene, LoadSceneMode mode)
    {
        //called when multiplayer scene is loaded
        currentScene = scene.buildIndex;
        if (currentScene == 1 || currentScene == 2 || currentScene ==3)
        {
            CreatePlayer();
        }
    }


    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    // callback function after join a room
    public override void OnJoinedRoom()
    {
        Debug.Log("User is in a room now");
        base.OnJoinedRoom();

        Debug.Log("Next line is going to switch to VR mode");
        StartCoroutine(LoadDevice("cardboard"));
        StartGame();
    }

    //load scene of the chosen lab room
    void StartGame()
    {
        if (!PhotonNetwork.IsMasterClient)
            return;
        if (loginManager.LM.roomName == "Pendulum")
        {
            PhotonNetwork.LoadLevel(multiplayerScene);
        }
        else if (loginManager.LM.roomName == "Force Balance")
        {
            PhotonNetwork.LoadLevel(ForceBalanceScene);
        }
        else PhotonNetwork.LoadLevel(StringConstantScene);

    }

    //use the prefab to create player in the lab room
    private void CreatePlayer()
    {
        //creates player network controller
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
      
    }


    //switch to VR mode
    IEnumerator LoadDevice(string newDevice)
    {
        Debug.Log("Into function that switch VR mode");
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = true;
    }

    public void moveToRoom(int roomNumber)
    {
        PhotonNetwork.LoadLevel(roomNumber);
    }

}
