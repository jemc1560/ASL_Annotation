using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class videoFetcher : MonoBehaviour
{
    // A list of potential words
    // https://docs.unity3d.com/540/Documentation/Manual/UnityWebRequest.html
    string[] words = new string[]
    {
        "after", "airplane", "all", "alligator", "animal", "another", "any", "apple", "arm", "aunt", "awake",
        "backyard", "bad", "balloon", "bath", "because", "bed", "bedroom", "bee", "before", "beside", "better",
        "bird", "black", "blow", "blue", "boat", "book", "boy", "brother", "brown", "bug", "bye", "callonphone",
        "can", "car", "carrot", "cat", "cereal", "chair", "cheek", "child", "chin", "chocolate", "clean",
        "close", "closet", "cloud", "clown", "cow", "cowboy", "cry", "cut", "cute", "dad", "dance", "dirty",
        "dog", "doll", "donkey", "down", "drawer", "drink", "drop", "dry", "dryer", "duck", "ear", "elephant",
        "empty", "every", "eye", "face", "fall", "farm", "fast", "feet", "find", "fine", "finger", "finish",
        "fireman", "first", "fish", "flag", "flower", "food", "for", "frenchfries", "frog", "garbage", "gift",
        "giraffe", "girl", "give", "glasswindow", "go", "goose", "grandma", "grandpa", "grass", "green", "gum",
        "hair", "happy", "hat", "hate", "have", "haveto", "head", "hear", "helicopter", "hello", "hen", "hesheit",
        "hide", "high", "home", "horse", "hot", "hungry", "icecream", "if", "into", "jacket", "jeans", "jump",
        "kiss", "kitty", "lamp", "later", "like", "lion", "lips", "listen", "look", "loud", "mad", "make", "man",
        "many", "milk", "minemy", "mitten", "mom", "moon", "morning", "mouse", "mouth", "nap", "napkin", "night",
        "no", "noisy", "nose", "not", "now", "nuts", "old", "on", "open", "orange", "outside", "owie", "owl",
        "pajamas", "pen", "pencil", "penny", "person", "pig", "pizza", "please", "police", "pool", "potty",
        "pretend", "pretty", "puppy", "puzzle", "quiet", "radio", "rain", "read", "red", "refrigerator", "ride",
        "room", "sad", "same", "say", "scissors", "see", "shhh", "shirt", "shoe", "shower", "sick", "sleep",
        "sleepy", "smile", "snack", "snow", "stairs", "stay", "sticky", "store", "story", "stuck", "sun",
        "table", "talk", "taste", "thankyou", "that", "there", "think", "thirsty", "tiger", "time", "tomorrow",
        "tongue", "tooth", "toothbrush", "touch", "toy", "tree", "tv", "uncle", "underwear", "up", "vacuum",
        "wait", "wake", "water", "wet", "weus", "where", "white", "who", "why", "will", "wolf", "yellow", "yes",
        "yesterday", "yourself", "yucky", "zebra", "zipper"
    };
    string word = "after";
    void Start()
    {
        StartCoroutine(DownloadVideo());
    }

    void rollWords(){
        word = words[Random.Range(0, words.Length)];
    }

    IEnumerator DownloadVideo(){
        rollWords();
        string fileName = $"{word}.tar";
        string url = $"https://signdata.cc.gatech.edu/data/popsign_v1_0/game/train/{fileName}";
        string localPath = Path.Combine(Application.persistentDataPath, fileName);
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
        unityWebRequest.downloadHandler = new DownloadHandlerFile(localPath);
        //Debug.Log("Started downloading!");
        yield return unityWebRequest.SendWebRequest();
        // Log in case fail
        if(unityWebRequest.result != UnityWebRequest.Result.Success){
            //do something if result fails, maybe has a pop up or something?
            //Debug.Log("Failed");
        } else{
            //Debug.Log("Done downloading!");
        }
    }

}
