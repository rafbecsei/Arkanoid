using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FimController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextScene;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }
}