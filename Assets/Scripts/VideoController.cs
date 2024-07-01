using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    // Butonlar� ekleme
    public Button forward10Button;
    public Button forward5Button;
    public Button backward5Button;
    public Button backward10Button;
    public Button playPauseButton;

    public Slider volumeSlider;

    public TMP_Text timeDisplayText;

    public Image buttonImage;

    public Sprite playIcon;
    public Sprite pauseIcon;

    public GameProgressManager mngr;

    public int level;

    private bool isPlaying = false;

    void Start()
    {
        // Butonlar�n onClick event'lerini ayarlama
        forward10Button.onClick.AddListener(() => ChangeVideoTime(10));
        forward5Button.onClick.AddListener(() => ChangeVideoTime(5));
        backward5Button.onClick.AddListener(() => ChangeVideoTime(-5));
        backward10Button.onClick.AddListener(() => ChangeVideoTime(-10));
        playPauseButton.onClick.AddListener(TogglePlayPause);
        videoPlayer.loopPointReached += OnVideoFinished;
        UpdateButtonIcon();

        // Ba�lang��ta slider'�n de�erini videonun ses seviyesine ayarla
        volumeSlider.value = videoPlayer.GetDirectAudioVolume(0);

        // Slider'�n de�eri de�i�ti�inde �a�r�lacak olan fonksiyonu tan�mla
        volumeSlider.onValueChanged.AddListener(delegate { SetVideoVolume(); });
    }
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            string currentTime = FormatTime(videoPlayer.time);
            string totalTime = FormatTime(videoPlayer.length);
            timeDisplayText.text = $"{currentTime}/{totalTime}";
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Video tamamland���nda log ver
        Debug.Log(level+".Video tamamland�.");
        if (mngr != null)
        {
            mngr.CompleteStar((level - 1) * 3);
        }
    }

    string FormatTime(double timeInSeconds)
    {
        int minutes = (int)(timeInSeconds / 60);
        int seconds = (int)(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void UpdateTimeDisplay()
    {
        string currentTime = FormatTime(videoPlayer.time);
        string totalTime = FormatTime(videoPlayer.length);
        timeDisplayText.text = $"{currentTime}/{totalTime}";
    }

    void ChangeVideoTime(int seconds)
    {
        // Video s�resini g�ncelle
        double newTime = videoPlayer.time + seconds;
        if (newTime < 0) newTime = 0;
        if (newTime > videoPlayer.length) newTime = videoPlayer.length;
        videoPlayer.time = newTime;
    }

    void TogglePlayPause()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
        isPlaying = !isPlaying;
        UpdateButtonIcon();
    }

    void UpdateButtonIcon()
    {
        buttonImage.sprite = isPlaying ? pauseIcon : playIcon;
    }

    void SetVideoVolume()
    {
        // Slider'�n de�erine g�re videonun ses seviyesini ayarla
        videoPlayer.SetDirectAudioVolume(0, volumeSlider.value);
    }
}
