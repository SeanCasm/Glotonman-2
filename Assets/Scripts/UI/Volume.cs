using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
namespace Glotonman2.UI
{
    public class Volume : MonoBehaviour
    {
        public AudioMixer m_SoundMixer;
        private AudioSource audioSource;
        private Slider soundSlider;
        void Start()
        {
            soundSlider = GetComponent<Slider>();
            audioSource = GetComponent<AudioSource>();
        }
        public void OnChange(float value)
        {
            audioSource.Stop();
            float volume = soundSlider.value;
            m_SoundMixer.SetFloat("volume", volume);
            audioSource.PlayDelayed(.5f);
        }
    }
}