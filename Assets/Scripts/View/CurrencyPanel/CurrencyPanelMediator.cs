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
    public class CurrencyPanelMediator : Mediator
    {
        public static new string NAME = "CurrencyPanelMediator";
        public CurrencyPanelMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
        {
        }


        protected CurrencyPanel GetCurrencyPanel
        {
            get
            {
                return ViewComponent as CurrencyPanel;
            }
        }


        public override string[] ListNotificationInterests()
        {
            List<string> listNotificationInterests = new List<string>();
            listNotificationInterests.Add(Notification.ChangeGlodCup);
            listNotificationInterests.Add(Notification.ChangeSilverCup);
            listNotificationInterests.Add(Notification.ChangeBronzeCup);
            listNotificationInterests.Add(Notification.CloseCurrencyPanel);
            return listNotificationInterests.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            int tempNumber = -1;
            if (notification.Body is int)
            {
                tempNumber =(int) notification.Body;
            }
            switch (notification.Name)
            {
                case Notification.ChangeGlodCup:
                    {
                        GetCurrencyPanel.ChangeCup(CurrencyType.Gold, tempNumber);
                        break;
                    }
                case Notification.ChangeSilverCup:
                    {
                        GetCurrencyPanel.ChangeCup(CurrencyType.Silver, tempNumber);
                        break;
                    }
                case Notification.ChangeBronzeCup:
                    {
                        GetCurrencyPanel.ChangeCup(CurrencyType.Bronze, tempNumber);
                        break;
                    }
                case Notification.CloseCurrencyPanel:
                    {
                        GetCurrencyPanel.CloseCurrencyPanel();
                        break;
                    }
                default:
                    break;
            }
        }

    }
}

