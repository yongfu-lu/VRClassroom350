using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ForceTableData : MonoBehaviour
{

    public static ForceTableData ftd;

    public TextMeshPro redAngle;
    public TextMeshPro blackAngle;
    public TextMeshPro purpleAngle;

    public TextMeshPro redMass;
    public TextMeshPro blackMass;
    public TextMeshPro purpleMass;

    public GameObject redPivot;
    public GameObject blackPivot;
    public GameObject purplePivot;

    // Start is called before the first frame update
    void Start()
    {
        if (ForceTableData.ftd == null)
            ForceTableData.ftd = this;

        float rAngle, bAngle, pAngle;
        if (redPivot.transform.eulerAngles.y <= 180)
            rAngle = 180 - redPivot.transform.eulerAngles.y;
        else
            rAngle = (360f - redPivot.transform.eulerAngles.y) + 180f;
        redAngle.text = rAngle.ToString("F0");

        if (blackPivot.transform.eulerAngles.y > 90)
            bAngle = (360f - blackPivot.transform.eulerAngles.y) + 90f;
        else
            bAngle = 90f - blackPivot.transform.eulerAngles.y;
        blackAngle.text = bAngle.ToString("F0");

        pAngle = (360f - purplePivot.transform.eulerAngles.y) % 360f;
        purpleAngle.text = pAngle.ToString("F0");
        redMass.text = "300";

    }

    // Update is called once per frame
    void Update()
    {
        float rAngle, bAngle, pAngle;

        if (redPivot.transform.eulerAngles.y <= 180)
            rAngle = 180 - redPivot.transform.eulerAngles.y;
        else
            rAngle = (360f - redPivot.transform.eulerAngles.y) + 180f;
        redAngle.text = rAngle.ToString("F0");

        if (blackPivot.transform.eulerAngles.y > 90)
            bAngle = (360f - blackPivot.transform.eulerAngles.y) + 90f;
        else
            bAngle = 90f - blackPivot.transform.eulerAngles.y;
        blackAngle.text = bAngle.ToString("F0");

        pAngle = (360f - purplePivot.transform.eulerAngles.y) % 360f;
        purpleAngle.text = pAngle.ToString("F0");
    }

    public void OnAddRedMassButtonClick()
    {
        redMass.text = (Int32.Parse(redMass.text) + 1).ToString();
    }

    public void OnAddBlackMassButtonClick()
    {
        blackMass.text = (Int32.Parse(blackMass.text) + 1).ToString();
    }

    public void OnAddPurpleMassButtonClick()
    {
        purpleMass.text = (Int32.Parse(purpleMass.text) + 1).ToString();
    }

    public void OnSubRedMassButtonClick()
    {
        redMass.text = (Int32.Parse(redMass.text) - 1).ToString();
    }

    public void OnSubBlackMassButtonClick()
    {
        blackMass.text = (Int32.Parse(blackMass.text) - 1).ToString();
    }

    public void OnSubPurpleMassButtonClick()
    {
        purpleMass.text = (Int32.Parse(purpleMass.text) - 1).ToString();
    }
}
