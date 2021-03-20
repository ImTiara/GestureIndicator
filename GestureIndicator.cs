using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GestureIndicator
{
    public static class BuildInfo
    {
        public const string Name = "GestureIndicator";
        public const string Author = "ImTiara";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = "https://github.com/ImTiara/GestureIndicator/releases";
    }

    public class GestureIndicator : MelonMod
    {
        private bool m_Enable;

        private Text m_LeftGestureText;
        private Text m_RightGestureText;

        public override void OnApplicationStart()
        {
            MelonPreferences.CreateCategory(GetType().Name, "Gesture Indicator");
            MelonPreferences.CreateEntry(GetType().Name, "Enable", true, "Enable");
        }

        public override void VRChat_OnUiManagerInit()
        {
            CreateIndicators();

            OnPreferencesSaved();
        }

        public override void OnPreferencesSaved()
        {
            m_Enable = MelonPreferences.GetEntryValue<bool>(GetType().Name, "Enable");

            ToggleIndicators(m_Enable);
        }

        private IEnumerator CheckGesture()
        {
            while (m_Enable)
            {
                try
                {
                    if (Manager.GetLocalVRCPlayer() != null && m_LeftGestureText != null && m_RightGestureText != null)
                    {
                        if (Manager.GetGestureLeftWeight() >= 0.1f)
                        {
                            Manager.Gesture leftGesture = Manager.GetGesture(Manager.Hand.Left);
                            switch (leftGesture)
                            {
                                case Manager.Gesture.Fist:
                                    m_LeftGestureText.text = "Fist";
                                    break;
                                case Manager.Gesture.Open:
                                    m_LeftGestureText.text = "Hand Open";
                                    break;
                                case Manager.Gesture.Point:
                                    m_LeftGestureText.text = "Point";
                                    break;
                                case Manager.Gesture.Victory:
                                    m_LeftGestureText.text = "Victory";
                                    break;
                                case Manager.Gesture.RockNRoll:
                                    m_LeftGestureText.text = "RockNRoll";
                                    break;
                                case Manager.Gesture.Gun:
                                    m_LeftGestureText.text = "Hand Gun";
                                    break;
                                case Manager.Gesture.ThumbsUp:
                                    m_LeftGestureText.text = "Thumbs Up";
                                    break;
                            }
                        }
                        else m_LeftGestureText.text = "";

                        if (Manager.GetGestureRightWeight() >= 0.1f)
                        {
                            Manager.Gesture rightGesture = Manager.GetGesture(Manager.Hand.Right);
                            switch (rightGesture)
                            {
                                case Manager.Gesture.Fist:
                                    m_RightGestureText.text = "Fist";
                                    break;
                                case Manager.Gesture.Open:
                                    m_RightGestureText.text = "Hand Open";
                                    break;
                                case Manager.Gesture.Point:
                                    m_RightGestureText.text = "Point";
                                    break;
                                case Manager.Gesture.Victory:
                                    m_RightGestureText.text = "Victory";
                                    break;
                                case Manager.Gesture.RockNRoll:
                                    m_RightGestureText.text = "RockNRoll";
                                    break;
                                case Manager.Gesture.Gun:
                                    m_RightGestureText.text = "Hand Gun";
                                    break;
                                case Manager.Gesture.ThumbsUp:
                                    m_RightGestureText.text = "Thumbs Up";
                                    break;
                            }
                        }
                        else m_RightGestureText.text = "";
                    }
                }
                catch (Exception e) { MelonLogger.Error("Error checking gesture: " + e); }

                yield return new WaitForSeconds(.1f);
            }
        }

        private void CreateIndicators()
        {
            Transform hud = Manager.GetVRCUiManager().transform.Find("UnscaledUI/HudContent");

            Color color = Color.cyan;
            color.a = 0.85f;

            m_LeftGestureText = UnityEngine.Object.Instantiate(Manager.GetQuickMenu().transform.Find("QuickMenu_NewElements/_InfoBar/EarlyAccessText").gameObject, hud, true).GetComponent<Text>();
            RectTransform rectTransformLeft = m_LeftGestureText.GetComponent<RectTransform>();
            rectTransformLeft.anchoredPosition = new Vector3(290, -924, 0);
            rectTransformLeft.localScale = new Vector2(0.4f, 0.4f);
            m_LeftGestureText.text = "";
            m_LeftGestureText.alignment = TextAnchor.MiddleLeft;
            m_LeftGestureText.color = color;
            m_LeftGestureText.fontStyle = FontStyle.Normal;

            m_RightGestureText = UnityEngine.Object.Instantiate(Manager.GetQuickMenu().transform.Find("QuickMenu_NewElements/_InfoBar/EarlyAccessText").gameObject, hud, true).GetComponent<Text>();
            RectTransform rectTransformRight = m_RightGestureText.GetComponent<RectTransform>();
            rectTransformRight.anchoredPosition = new Vector3(780, -924, 0);
            rectTransformRight.localScale = new Vector2(0.4f, 0.4f);
            m_RightGestureText.text = "";
            m_RightGestureText.alignment = TextAnchor.MiddleRight;
            m_RightGestureText.color = color;
            m_RightGestureText.fontStyle = FontStyle.Normal;
        }

        private void ToggleIndicators(bool enable)
        {
            if (enable)
                MelonCoroutines.Start(CheckGesture());

            m_LeftGestureText.gameObject.SetActive(enable);
            m_RightGestureText.gameObject.SetActive(enable);
        }
    }
}
