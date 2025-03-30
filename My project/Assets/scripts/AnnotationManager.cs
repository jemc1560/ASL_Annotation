using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;


[System.Serializable]
public class AnnotationQuestion
{
    public VideoClip videoClip;      // The video clip for the question
    public string[] answerOptions;   // The text to display on each answer button
    public int correctAnswerIndex;   // The index of the correct answer in the answerOptions array
}

public class AnnotationManager : MonoBehaviour
{
    [Header("Video Settings")]
    public VideoPlayer videoPlayer;

    [Header("UI Elements")]
    public Button[] answerButtons;
    public TextMeshProUGUI feedbackText;
    public Button nextButton;

    [Header("Questions Settings")]
    public AnnotationQuestion[] questions;

    // Tracking current question and score
    private int currentQuestionIndex = 0;
    private int correctAnswerIndex;
    private int score = 0;

    void Start()
    {
        // Hook up listeners for each answer button.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; // Capture current index for the listener.
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
        }

        // Set up the next button listener and hide it initially.
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextQuestion);
            nextButton.gameObject.SetActive(false);
        }

        // Display the first question if available.
        if (questions != null && questions.Length > 0)
        {
            DisplayQuestion(0);
        }
        else
        {
            Debug.LogWarning("No questions assigned in the AnnotationManager!");
        }
    }

    /// <summary>
    /// Displays the specified question on the UI.
    /// </summary>
    /// <param name="questionIndex">Index of the question to display.</param>
    void DisplayQuestion(int questionIndex)
    {
        // Safety check.
        if (questionIndex < 0 || questionIndex >= questions.Length)
        {
            Debug.LogError("Invalid question index!");
            return;
        }

        // Get the question data.
        AnnotationQuestion question = questions[questionIndex];
        correctAnswerIndex = question.correctAnswerIndex;
        feedbackText.text = ""; // Clear old feedback.

        // Play the video clip.
        if (question.videoClip != null && videoPlayer != null)
        {
            PlayVideo(question.videoClip);
        }

        // Set up each answer button with the corresponding text.
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Text buttonText = answerButtons[i].GetComponentInChildren<Text>();
            if (buttonText != null && i < question.answerOptions.Length)
            {
                buttonText.text = question.answerOptions[i];
            }
            else if (buttonText != null)
            {
                buttonText.text = "Option " + (i + 1);
            }
        }

        // Hide the Next button until an answer is correct.
        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Called when an answer button is pressed.
    /// </summary>
    /// <param name="index">The index of the selected answer.</param>
    public void OnAnswerSelected(int index)
    {
        if (index == correctAnswerIndex)
        {
            feedbackText.text = "Correct!";
            score++;

            // Show the Next button or automatically advance after a delay.
            if (nextButton != null)
            {
                nextButton.gameObject.SetActive(true);
            }
            else
            {
                Invoke("NextQuestion", 1f);
            }
        }
        else
        {
            feedbackText.text = "Wrong. Try again!";
            Debug.Log("Wrong answer selected.");
        }
    }

    /// <summary>
    /// Plays the given video clip using the VideoPlayer.
    /// </summary>
    /// <param name="clip">The video clip to play.</param>
    public void PlayVideo(VideoClip clip)
    {
        if (videoPlayer != null)
        {
            videoPlayer.clip = clip;
            videoPlayer.Play();
        }
    }

    /// <summary>
    /// Advances to the next question.
    /// </summary>
    public void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion(currentQuestionIndex);
        }
        else
        {
            // End of questions – display final score.
            feedbackText.text = "Quiz Complete! Score: " + score + "/" + questions.Length;
            foreach (var btn in answerButtons)
            {
                btn.interactable = false;
            }
            if (nextButton != null)
            {
                nextButton.gameObject.SetActive(false);
            }
        }
    }
}
