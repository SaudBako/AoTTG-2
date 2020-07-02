﻿using Assets.Scripts.UI.Input;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.InGame.Controls
{
    public class ControlsMenu : MonoBehaviour
    {
        public GameObject TabViewContent;
        public Button TabViewButton;

        public GeneralControlsPage GeneralControlsPage;
        public RebindsPage RebindsPage;

        private void Awake()
        {
            var inputEnums = new List<Type>
            {
                typeof(InputCannon),
                typeof(InputHuman),
                typeof(InputHorse),
                typeof(InputTitan),
                typeof(InputUi)
            };

            foreach (var inputEnum in inputEnums)
            {
                var button = Instantiate(TabViewButton);
                var text = inputEnum.Name.Replace("Input", string.Empty);
                button.name = $"{text}Button";
                button.GetComponentInChildren<Text>().text = text;
                button.onClick.AddListener(delegate { ShowRebindPage(inputEnum); });
                button.transform.SetParent(TabViewContent.transform);
            }

            ShowGeneralControlsPage();
        }

        public void ShowGeneralControlsPage()
        {
            GeneralControlsPage.gameObject.SetActive(true);
            RebindsPage.gameObject.SetActive(false);
        }

        public void ShowRebindPage(Type type)
        {
            GeneralControlsPage.gameObject.SetActive(false);
            RebindsPage.gameObject.SetActive(true);
            RebindsPage.ShowRebinds(type);
        }
    }
}
