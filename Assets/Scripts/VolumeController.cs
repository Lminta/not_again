using System.Collections;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private void Start()
    {
        AudioListener.volume = 1.0f;
    }
    public void SetGlobalVolume(float sliderVolume)
    {
        AudioListener.volume = sliderVolume;
    }
}