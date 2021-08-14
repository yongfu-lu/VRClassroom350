using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ForceTableStrings : MonoBehaviour
{

    public static ForceTableStrings fts;

    public Transform redPivot;
    public Transform blackPivot;
    public Transform purplePivot;

    public TextMeshPro redAngleTMP;
    public TextMeshPro blackAngleTMP;
    public TextMeshPro purpleAngleTMP;

    public Transform center;

    // used for resetting
    public Transform reset;

    public float redMass;
    public float blackMass;
    public float purpleMass;

    public float redAngle;
    public float blackAngle;
    public float purpleAngle;

    public TextMeshPro redMassTMP;
    public TextMeshPro blackMassTMP;
    public TextMeshPro purpleMassTMP;

    public GameObject addRedAngleButton;
    public GameObject addBlackAngleButton;
    public GameObject addPurpleAngleButton;
    public GameObject subRedAngleButton;
    public GameObject subBlackAngleButton;
    public GameObject subPurpleAngleButton;

    public GameObject addRedMassButton;
    public GameObject addBlackMassButton;
    public GameObject addPurpleMassButton;
    public GameObject subRedMassButton;
    public GameObject subBlackMassButton;
    public GameObject subPurpleMassButton;

    public GameObject startButton;
    public GameObject resetButton;

    public bool start = false;

    public float g = 9.8f;

    float xForce;
    float zForce;

    // Start is called before the first frame update
    void Start()
    {
        if (ForceTableStrings.fts == null)
            ForceTableStrings.fts = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {

        }
    }

    public void OnStartButtonClick()
    {
        start = true;

        redAngle = float.Parse(redAngleTMP.text);
        blackAngle = float.Parse(blackAngleTMP.text);
        purpleAngle = float.Parse(purpleAngleTMP.text);

        redMass = float.Parse(redMassTMP.text);
        blackMass = float.Parse(blackMassTMP.text);
        purpleMass = float.Parse(purpleMassTMP.text);




        startButton.SetActive(false);
        resetButton.SetActive(true);
        addRedAngleButton.SetActive(false);

    }

    public void OnResetButtonClick()
    {
        center.position = reset.position;
        Vector3 eulerAngles = redPivot.eulerAngles;
        eulerAngles.y = 320f;
        redPivot.eulerAngles = eulerAngles;
        eulerAngles = blackPivot.eulerAngles;
        eulerAngles.y = 0f;
        blackPivot.eulerAngles = eulerAngles;
        eulerAngles = purplePivot.eulerAngles;
        eulerAngles.y = 0f;
        purplePivot.eulerAngles = eulerAngles;

    }

    public void OnAddRedAngleButtonClick()
    {
        Vector3 eulerAngles = redPivot.eulerAngles;
        eulerAngles.y = redPivot.eulerAngles.y - 1f;
        redPivot.eulerAngles = eulerAngles;
    }

    public void OnAddBlackAngleButtonClick()
    {
        Vector3 eulerAngles = blackPivot.eulerAngles;
        eulerAngles.y = blackPivot.eulerAngles.y - 1f;
        blackPivot.eulerAngles = eulerAngles;
    }

    public void OnAddPurpleAngleButtonClick()
    {
        Vector3 eulerAngles = purplePivot.eulerAngles;
        eulerAngles.y = purplePivot.eulerAngles.y - 1f;
        purplePivot.eulerAngles = eulerAngles;
    }

    public void OnSubRedAngleButtonClick()
    {
        Vector3 eulerAngles = redPivot.eulerAngles;
        eulerAngles.y = redPivot.eulerAngles.y + 1f;
        redPivot.eulerAngles = eulerAngles;
    }

    public void OnSubBlackAngleButtonClick()
    {
        Vector3 eulerAngles = blackPivot.eulerAngles;
        eulerAngles.y = blackPivot.eulerAngles.y + 1f;
        blackPivot.eulerAngles = eulerAngles;
    }

    public void OnSubPurpleAngleButtonClick()
    {
        Vector3 eulerAngles = purplePivot.eulerAngles;
        eulerAngles.y = purplePivot.eulerAngles.y - 1f;
        purplePivot.eulerAngles = eulerAngles;
    }
}
