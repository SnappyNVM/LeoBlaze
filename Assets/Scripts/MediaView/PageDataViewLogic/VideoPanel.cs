using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanel : MonoBehaviour
{
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private Button _pressToPlayButton;

    public void OnPanelOpened(VideoClip clip)
    {
        _pressToPlayButton.gameObject.SetActive(true);
        _pressToPlayButton.onClick.RemoveAllListeners();
        _pressToPlayButton.onClick.AddListener(Show);
        _player.clip = clip;
        _player.time = 0;
        StopTheVideo();
    }

    public void Show()
    {
        StartCoroutine(PlayButtonDisable());
        PlayTheVideo();
    }

    public void PlayTheVideo() =>
        _player.Play();

    public void StopTheVideo() =>
        _player.Stop();

    public void EnableVolume() =>
        _player.SetDirectAudioMute(0, false);

    public void DisableVolume() =>
        _player.SetDirectAudioMute(0, true);

    public void TenSecondsForward() =>
        _player.time = _player.time + 10;

    public void TenSecondsBackward() =>
        _player.time = _player.time - 10;
    
    private IEnumerator PlayButtonDisable()
    {
        yield return new WaitForSeconds(0.2f);
        _pressToPlayButton.gameObject.SetActive(false);
    }
}
