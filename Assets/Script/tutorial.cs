using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{

    [SerializeField] private GameObject TutorialPanel;

    private void HideTutorial()
    {
        TutorialPanel.SetActive(false);
    }
    private void ShowTutorial()
    {
        TutorialPanel.SetActive(true);
    }

    private void OnEnable()
    {
        Ball.Evnt_Score += HideTutorial;
        Ball.Evnt_GameOver += ShowTutorial;
    }

}
