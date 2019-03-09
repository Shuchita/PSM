﻿// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace UICatalog
{
    partial class LiveJumpPanelScene
    {
        Panel contentPanel;
        LiveJumpPanel liveJumpPanel;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            contentPanel = new Panel();
            contentPanel.Name = "contentPanel";
            liveJumpPanel = new LiveJumpPanel();
            liveJumpPanel.Name = "liveJumpPanel";

            // LiveJumpPanelScene
            this.RootWidget.AddChildLast(contentPanel);

            // contentPanel
            contentPanel.BackgroundColor = new UIColor(153f / 255f, 153f / 255f, 153f / 255f, 0f / 255f);
            contentPanel.Clip = true;
            contentPanel.AddChildLast(liveJumpPanel);

            // liveJumpPanel
            liveJumpPanel.Clip = true;
            liveJumpPanel.BackgroundColor = new UIColor(34f / 255f, 34f / 255f, 34f / 255f, 255f / 255f);
            liveJumpPanel.JumpHeight = 350f;
            liveJumpPanel.JumpDelayTime = 1f;
            liveJumpPanel.JumpTime = 500f;
            liveJumpPanel.TiltAngle = 0.17f;

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 480;
                    this.DesignHeight = 854;

                    contentPanel.SetPosition(0, 211);
                    contentPanel.SetSize(480, 641);
                    contentPanel.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                    contentPanel.Visible = true;

                    liveJumpPanel.SetPosition(24, 29);
                    liveJumpPanel.SetSize(432, 585);
                    liveJumpPanel.Anchors = Anchors.None;
                    liveJumpPanel.Visible = true;

                    break;

                default:
                    this.DesignWidth = 854;
                    this.DesignHeight = 480;

                    contentPanel.SetPosition(0, 110);
                    contentPanel.SetSize(854, 370);
                    contentPanel.Anchors = Anchors.Top | Anchors.Bottom;
                    contentPanel.Visible = true;

                    liveJumpPanel.SetPosition(0, 1);
                    liveJumpPanel.SetSize(854, 370);
                    liveJumpPanel.Anchors = Anchors.Top | Anchors.Bottom | Anchors.Left | Anchors.Right;
                    liveJumpPanel.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

    }
}