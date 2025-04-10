using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using System;
using Unity.VisualScripting;

public class classroommanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public VideoClip[] videoClip;
    public VideoPlayer videoPlayer;
    

    public bool isPlaying;

    private int index;

    public RawImage screen;

    public GameObject cbg;

    [Header("UI Elements")]
    public Button play;
    public Button[] answerButtons;
    public Button nextButton;
    public Button speed;

    public string[] signs;
    void Start()
    {
        isPlaying = false;
        screen.gameObject.SetActive(false);
        index = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayVideo()
    {
        if (!isPlaying)
        {
            if (videoPlayer != null)
            {
                play.gameObject.SetActive(false);
                screen.gameObject.SetActive(true);
                cbg.gameObject.SetActive(true);
                isPlaying = true;
                videoPlayer.clip = videoClip[index];
                videoPlayer.Play();
            }
        } else
        {

            videoPlayer.Pause();
        }
    }

    public void playback()
    {
        if(isPlaying)
        {
            char curspeed = speed.gameObject.GetComponentInChildren<Text>().text.ToCharArray()[1];
            Debug.Log(curspeed); 
            int numspeed = int.Parse(curspeed.ToString());
            Debug.Log(numspeed);
            Debug.Log("x" + Convert.ToString((numspeed + 1) % 3));
            speed.gameObject.GetComponentInChildren<Text>().text = "x"+ Convert.ToString((numspeed + 1) % 3);
            videoPlayer.playbackSpeed = (numspeed + 1)% 3;
        }
    }
}
