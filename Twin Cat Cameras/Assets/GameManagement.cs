using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{

    private Slider _audioSlider;
    private Slider _musicSlider;
    public float soundLevel = 1.0f;
    public float musicLevel = 1.0f;
    private AudioSource _as;

    void Start()
    {
        UpdateSounds();
    }

    public void UpdateSounds()
    {
        AudioListener.volume = soundLevel;
        if(_as == null)
        {
            FindMusicObject();
        }
        else
        {
            _as.volume = musicLevel;
        }
    }

    private void FindMusicObject()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            if (_as == null)
            {
                _as = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
                _as.volume = musicLevel;
            }
        }
    }
}
