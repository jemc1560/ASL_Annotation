using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using System;
using Unity.VisualScripting;
using System.Linq;


public class classroommanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public VideoClip[] videoClip;
    public VideoPlayer videoPlayer;
    

    public bool isPlaying;

    private int index;

    public RawImage screen;

    public GameObject manager;
    public GameObject popup;

    public GameObject cbg;
    // actual images
    public Sprite bbg;
    public Sprite ogbg;

    [Header("UI Elements")]
    public Button play;
    public Button[] answerButtons;
    public Button nextButton;
    public Button speed;

    public String choice;

    public TMP_Text label;

    public string[] signs;

    private int fast = 0;
    void Start()
    {
        isPlaying = false;
        screen.gameObject.SetActive(false);
        cbg.GetComponent<SpriteRenderer>().sprite = ogbg;
        index = 0;
        choice = null;
        
        label.GetComponent<TMP_Text>().text = "Sign: " + popup.GetComponent<Popup>().GetSign(index);
        videoPlayer.clip = videoClip[index];
        videoPlayer.Prepare();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void startit()
    {
        popup.GetComponent<Popup>().onstart();
        return;
    }

    public void setChoice(Button b)
    {
        choice = b.gameObject.GetComponentInChildren<TMP_Text>().text;
    }
    public void PlayVideo()
    {
        if (!isPlaying)
        {
            if (videoPlayer != null)
            {
                play.gameObject.SetActive(false);
                screen.gameObject.SetActive(true); 
                cbg.GetComponent<SpriteRenderer>().sprite = bbg;
                isPlaying = true;
                videoPlayer.Play();
            }
        } else
        {

            videoPlayer.Pause();
            play.gameObject.SetActive(true);
            isPlaying = false;
        }
    }

    public void NextVideo()
    {
        if (choice == null)
        {
            //give warning to make a choice 
        } else
        {
            //save result to array
            manager.GetComponent<DataManager>().AddAnnotatedVideo(new AnnotatedVideo(index, choice));


            if ((index + 2) == videoClip.Length)
            {
                nextButton.GetComponentInChildren<TMP_Text>().text = "submit";
                //reload or sum
            }
            else if ((index + 1) == videoClip.Length)
            {
                //close scene 

                SceneController.entergame();
            }
            play.gameObject.SetActive(true);
            index += 1;
            isPlaying = false;
            videoPlayer.Stop();
            screen.gameObject.SetActive(false);
            cbg.GetComponent<SpriteRenderer>().sprite = ogbg;
            videoPlayer.clip = videoClip[index];
            label.GetComponent<TMP_Text>().text = "Sign: " + popup.GetComponent<Popup>().GetSign(index);
            videoPlayer.Prepare();
        }
    }

    

    public void speedUp(){
        if(fast == -1){
            fast = 0;
            videoPlayer.playbackSpeed = 1.0f;
            speed.GetComponentInChildren<TextMeshProUGUI>().text = "x1";
        }
        else if (fast == 0){
            fast = 1;
            videoPlayer.playbackSpeed = 2.0f;
            speed.GetComponentInChildren<TextMeshProUGUI>().text = "x2";
        }
        else{
            fast = -1;
            videoPlayer.playbackSpeed = 0.5f;
            speed.GetComponentInChildren<TextMeshProUGUI>().text = "x.5";
        }
    }
}
