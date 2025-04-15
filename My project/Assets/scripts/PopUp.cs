using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;
using static UnityEngine.Rendering.DebugUI;

public class Popup : MonoBehaviour
{
    public VideoClip[] refvideos;
    public string[] signs;

    public GameObject popup;


    public VideoPlayer videoPlayer;

    public string GetSign(int index)
    {
        videoPlayer.clip = refvideos[index];
        videoPlayer.Prepare();
        return signs[index];
    }

    public void onstart()
    {
        popup.SetActive(true);
        videoPlayer.Play();
    }

    private void Start()
    {
        popup.SetActive(false);
    }

    public void close()
    {
        videoPlayer.Stop();
        popup.SetActive(false);
    }
}
