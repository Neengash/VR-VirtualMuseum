﻿using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;

public class CardBoardSetup : MonoBehaviour
{

    void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        if (!Api.HasDeviceParams()) {
            Api.ScanDeviceParams();
        }       
    }

    void Update() {
        if (Api.IsGearButtonPressed) {
            Api.ScanDeviceParams();
        }

        if (Api.IsCloseButtonPressed) {
            Application.Quit();
        }

        if (Api.HasNewDeviceParams()) {
            Api.ReloadDeviceParams();
        }

        Api.UpdateScreenParams();
    }
}
