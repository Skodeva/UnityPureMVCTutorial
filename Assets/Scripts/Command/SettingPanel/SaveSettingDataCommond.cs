﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Core;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Facade;
using PureMVC.Patterns.Mediator;
using PureMVC.Patterns.Observer;
using PureMVC.Patterns.Proxy;
using Custom.Log;

namespace PureMVC.Tutorial
{
    public class SaveSettingDataCommond : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            SettingPanel settingPanelView = notification.Body as SettingPanel;
            if (settingPanelView == null)
            {
                this.LogError("settingPanelView为null，请检查");
                return;
            }
            GloalDataProxy gloalDataProxy = Facade.RetrieveProxy("GloalDataProxy") as GloalDataProxy;
            GloalData gloalData = gloalDataProxy.GetGloalData;
            gloalData.BoyOrGirl = settingPanelView.tempBoyOrGirl;
            gloalData.MusicVolume = settingPanelView.tempMusicVolume;
            gloalData.SoundVolume = settingPanelView.tempSoundVolume;
        }
    }
}
