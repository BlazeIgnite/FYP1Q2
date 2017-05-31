using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyTimer : MonoBehaviour {

    Text m_TimerText;
    int m_OriginalFontSize;
    int m_ScaledFontSize;

    // Use this for initialization
    void Start()
    {
        m_TimerText = GetComponent<Text>();
        m_OriginalFontSize = m_TimerText.fontSize;
        m_ScaledFontSize = m_OriginalFontSize + 40;
    }

    // Update is called once per frame
    void Update()
    {
        int timer = (int)GameObject.Find("MasterLevelController").GetComponent<LobbySystem>().GetTimer();

        if (timer < 4)
        {
            m_TimerText.color = Color.red;
            m_TimerText.fontSize = m_ScaledFontSize;

            if (timer == 0)
            {
                m_TimerText.text = "GO!";
                return;
            }
        }
        else
        {
            m_TimerText.color = Color.white;
            m_TimerText.fontSize = m_OriginalFontSize;
        }

        m_TimerText.text = timer + "s";
    }
}
