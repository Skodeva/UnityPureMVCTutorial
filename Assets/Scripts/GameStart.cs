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
    public class GameStart : MonoBehaviour
    {
        public ApplicationFacade applicationFacade = null;
        private void Awake()
        {
            applicationFacade = new ApplicationFacade();
        }
        void Start()
        {
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
            applicationFacade.StartUpHandle();
        }

        private void OnDestroy()
        {
            applicationFacade.RemoveProxy(GlobalDataProxy.NAME);
            this.Log("存储");
        }

        private void OnDisable()
        {
            this.Log("OnDisable");
        }

        private void OnEnable()
        {
            this.Log("OnEnable");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GlobalDataProxy globalDataProxy = (GlobalDataProxy)applicationFacade.RetrieveProxy(GlobalDataProxy.NAME);
                globalDataProxy.SerializeData();
                this.Log("按键1");
            }
        }
    }
}
