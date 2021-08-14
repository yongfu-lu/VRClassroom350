using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class databaseManager : MonoBehaviour
{
    public static databaseManager DM;

    DatabaseReference reference;

    public string userName;

    //window shows lab 1 data and the data 
    public string[] lab1Time = new string[6];
    public string[] lab1Length = new string[6];
    public string[] lab1Period = new string[6];

    public GameObject Lab1DataWindow;
    public Text[] showLength = new Text[6];
    public Text[] showTime = new Text[6];
    public Text[] showPeriod = new Text[6];

    //window shows lab 3 data and the data 
    public string[] lab3Weight = new string[3];
    public string[] lab3SpringLength = new string[3];

    public GameObject Lab3DataWindow;
    public Text[] showWeight = new Text[3];
    public Text[] showSpringLength = new Text[3];

    private void Awake()
    {
        DM = this;
    }


    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://physiclab1-18247.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        Lab1DataWindow.SetActive(false);
        Lab3DataWindow.SetActive(false);
    }

    //show lab 1 data 
    public void OnLab1DataButtonClick()
    {
        Lab1DataWindow.SetActive(true);
        loadLab1Data();
    }

    //close data 1 window 
    public void OnLab1DataCloseButtonClick()
    {
        Lab1DataWindow.SetActive(false);
    }

    //save user name 
    public void saveUserName(User user, string ID)
    {
        Debug.Log("Calling save user name function");
        reference.Child("Users").Child(ID).Child("Name").SetValueAsync(user.userName);
    }


    //Load user name function1
    public void loadUserName()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").ValueChanged += LoadUserName;
    }

    //Load user name function2
    private void LoadUserName(object sender, ValueChangedEventArgs e)
    {
        userName  = e.Snapshot.Child(loginManager.LM.user.UserId).Child("Name").GetValue(true).ToString();
        Debug.Log("user name is " + userName);
    }



    //save lab 1 length, time and peroid data into realtime database 
    public void saveLab1Data(string ID)
    {
        Debug.Log("Calling save lab1 data function");
        for (int i = 0; i < 6; i++)
        {
            reference.Child("Users").Child(ID).Child("Pendulum Lab").Child("Length").Child("Length "+ i.ToString()).SetValueAsync(PendulumData.penData.length[i]);
            reference.Child("Users").Child(ID).Child("Pendulum Lab").Child("Time").Child("Time " + i.ToString()).SetValueAsync(PendulumData.penData.totalTime[i]);
            reference.Child("Users").Child(ID).Child("Pendulum Lab").Child("Period").Child("Period " + i.ToString()).SetValueAsync(PendulumData.penData.period[i]);
        }

    }


    //load lab1 length, time and period data function1
    public void loadLab1Data()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").ValueChanged += loadPendulumData;
    }

    //load lab1 length, time and period data function2
    private void loadPendulumData(object sender, ValueChangedEventArgs e)
    {
        Debug.Log("calling load lab 1 data function");
     
        for (int i = 0; i<6; i++)
        {
            lab1Time[i] = e.Snapshot.Child(loginManager.LM.user.UserId).Child("Pendulum Lab").Child("Time").Child("Time " + i.ToString()).GetValue(true).ToString();
            lab1Length[i] = e.Snapshot.Child(loginManager.LM.user.UserId).Child("Pendulum Lab").Child("Length").Child("Length " + i.ToString()).GetValue(true).ToString();
            lab1Period[i] = e.Snapshot.Child(loginManager.LM.user.UserId).Child("Pendulum Lab").Child("Period").Child("Period " + i.ToString()).GetValue(true).ToString();
        }

        for (int i = 0; i<6; i++)
        {
            showLength[i].text = lab1Length[i];
            showTime[i].text = lab1Time[i];
            showPeriod[i].text = lab1Period[i];
        }
   
    }

    //show lab 3 data window 
    public void OnLab3DataButtonClick()
    {
        Lab3DataWindow.SetActive(true);
        loadLab3Data();
    }

    //close lab 3 data window 
    public void OnLab3DataCloseButtonClick()
    {
        Lab3DataWindow.SetActive(false);
    }

    //save lab 3 data into realtime database 
    public void saveLab3Data(string ID)
    {
        Debug.Log("Calling save lab3 data function");
        for (int i = 0; i < 3; i++)
        {
            reference.Child("Users").Child(ID).Child("Spring Constant Lab").Child("Weight").Child("Weight " + i.ToString()).SetValueAsync(SpringData.spData.weight[i]);
            reference.Child("Users").Child(ID).Child("Spring Constant Lab").Child("Length").Child("Length " + i.ToString()).SetValueAsync(SpringData.spData.length[i]);
        }
    }

    //load lab 3 data function 1
    public void loadLab3Data()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").ValueChanged += loadSpringData;
    }

    //load lab 3 data function 2
    private void loadSpringData(object sender, ValueChangedEventArgs e)
    {
        Debug.Log("calling load lab 3 data function");

        for (int i = 0; i < 3; i++)
        {
            lab3Weight[i] = e.Snapshot.Child(loginManager.LM.user.UserId).Child("Spring Constant Lab").Child("Weight").Child("Weight " + i.ToString()).GetValue(true).ToString();
            lab3SpringLength[i] = e.Snapshot.Child(loginManager.LM.user.UserId).Child("Spring Constant Lab").Child("Length").Child("Length " + i.ToString()).GetValue(true).ToString();
        }

        for (int i = 0; i < 3; i++)
        {
            showWeight[i].text = lab3Weight[i];
            showSpringLength[i].text = lab3SpringLength[i];
        }

    }

}