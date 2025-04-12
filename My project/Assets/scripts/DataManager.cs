using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Video;

[System.Serializable]
public class AnnotatedVideo
{
    // eg properties; you can edit to match the actual data
    public VideoClip videoID;
    public string annotation;  // could store associated annotation info

    public AnnotatedVideo(VideoClip videoID, string annotation)
    {
        this.videoID = videoID;
        this.annotation = annotation;
    }
}

public class DataManager : MonoBehaviour
{
    // singleton instance for persistent in-memory storage
    public static DataManager Instance;

    // list of annotated videos across scenes
    public List<AnnotatedVideo> annotatedVideos = new List<AnnotatedVideo>();

    // file path for saving the data permanently
    private string saveFilePath;

    private void Awake()
    {
        // make sure that we only have one instance
        if (Instance == null)
        {
            Instance = this;
            // persist this obj through scene loads
            DontDestroyOnLoad(gameObject);
            saveFilePath = Path.Combine(Application.persistentDataPath, "annotatedVideos.json");
            // try to load any prev saved data when the game starts
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// add a new annotated video and save da updated data.
    /// </summary>
    public void AddAnnotatedVideo(AnnotatedVideo video)
    {
        annotatedVideos.Add(video);
        SaveData();
    }

    /// <summary>
    /// save the annotated video data to a JSON file.
    /// </summary>
    public void SaveData()
    {
        // wrap the list into a container class bc JsonUtility works best w single object
        DataWrapper wrapper = new DataWrapper();
        wrapper.annotatedVideos = annotatedVideos;
        string json = JsonUtility.ToJson(wrapper, true);

        File.WriteAllText(saveFilePath, json);
        Debug.Log("Data saved to " + saveFilePath);
    }

    /// <summary>
    /// load annotated video data from a JSON file (if we have that).
    /// </summary>
    public void LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            DataWrapper wrapper = JsonUtility.FromJson<DataWrapper>(json);
            annotatedVideos = wrapper.annotatedVideos;
            Debug.Log("Data loaded from " + saveFilePath);
        }
        else
        {
            Debug.Log("No saved data found at " + saveFilePath);
        }
    }

    // a simple wrapper class to help in JSON serialization
    [System.Serializable]
    private class DataWrapper
    {
        public List<AnnotatedVideo> annotatedVideos;
    }
}
