using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTableController : MonoBehaviour
{
    public void OnAddRedAngleButtonClick()
    {
        ForceTableStrings.fts.OnAddRedAngleButtonClick();
    }

    public void OnAddBlackAngleButtonClick()
    {
        ForceTableStrings.fts.OnAddBlackAngleButtonClick();
    }

    public void OnAddPurpleAngleButtonClick()
    {
        ForceTableStrings.fts.OnAddPurpleAngleButtonClick();
    }

    public void OnSubRedAngleButtonClick()
    {
        ForceTableStrings.fts.OnSubRedAngleButtonClick();
    }

    public void OnSubBlackAngleButtonClick()
    {
        ForceTableStrings.fts.OnSubBlackAngleButtonClick();
    }

    public void OnSubPurpleAngleButtonClick()
    {
        ForceTableStrings.fts.OnSubPurpleAngleButtonClick();
    }

    public void OnAddRedMassButtonClick()
    {
        ForceTableData.ftd.OnAddRedMassButtonClick();
    }

    public void OnAddBlackMassButtonClick()
    {
        ForceTableData.ftd.OnAddBlackMassButtonClick();
    }

    public void OnAddPurpleMassButtonClick()
    {
        ForceTableData.ftd.OnAddPurpleMassButtonClick();
    }

    public void OnSubRedMassButtonClick()
    {
        ForceTableData.ftd.OnSubRedMassButtonClick();
    }

    public void OnSubBlackMassButtonClick()
    {
        ForceTableData.ftd.OnSubBlackMassButtonClick();
    }

    public void OnSubPurpleMassButtonClick()
    {
        ForceTableData.ftd.OnSubPurpleMassButtonClick();
    }

    public void OnResetButtonClick()
    {
        ForceTableStrings.fts.OnResetButtonClick();
    }
}
