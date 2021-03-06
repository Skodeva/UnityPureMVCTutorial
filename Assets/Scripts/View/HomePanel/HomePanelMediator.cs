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
    public class HomePanelMediator : Mediator
    {
        public static new string NAME = "HomePanelMediator";
        public HomePanelMediator(string mediatorName, object viewComponent = null) : base(mediatorName, viewComponent)
        {
        }

        protected HomePanel GetHomePanel
        {
            get
            {
                return ViewComponent as HomePanel;
            }
        }

        public override void OnRegister()
        {
            base.OnRegister();
            GetHomePanel.PlayAction = PlayActionHandle;
            GetHomePanel.SettingAction = SettingActionHandle;
        }


        public override void OnRemove()
        {
            base.OnRemove();
            GetHomePanel.PlayAction = null;
            GetHomePanel.SettingAction = null;
        }


        protected void PlayActionHandle()
        {
            //播放音效
            ManagerFacade.Instance.PlayMusic("Button");

            SendNotification(Notification.HomeToStoreCommond,null,null) ;
            SendNotification(Notification.CloseHomePanel, null, null);
        }
        protected void SettingActionHandle()
        {
            //播放音效
            ManagerFacade.Instance.PlayMusic("Button");

            SendNotification(Notification.HomeToSettingCommond, null,"UI");
            SendNotification(Notification.CloseHomePanel, null, null);
        }


        public override string[] ListNotificationInterests()
        {
            List<string> listNotificationInterests = new List<string>();
            listNotificationInterests.Add(Notification.CloseHomePanel);
            listNotificationInterests.Add(Notification.OpenHomePanel);

            return listNotificationInterests.ToArray();
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case Notification.OpenHomePanel:
                    {
                        GetHomePanel.OpenHomePanel();
                        break;
                    }
                case Notification.CloseHomePanel:
                    {
                        GetHomePanel.CloseHomePanel();
                        break;
                    }

                default:
                    break;
            }
        }
    }
}

