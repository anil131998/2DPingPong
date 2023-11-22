using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource scoreSound;
    [SerializeField] public AudioSource defeatSound;
    
    private void PlayScoreSound()
    {
        scoreSound.PlayOneShot(scoreSound.clip);
    }

    private void PlayDefeatSound()
    {
        defeatSound.PlayOneShot(defeatSound.clip);
    }


    private void OnEnable()
    {
        Ball.Evnt_Score += PlayScoreSound;
        Ball.Evnt_GameOver += PlayDefeatSound;
    }
    private void OnDisable()
    {
        Ball.Evnt_Score -= PlayScoreSound;
        Ball.Evnt_GameOver -= PlayDefeatSound;
    }

}
