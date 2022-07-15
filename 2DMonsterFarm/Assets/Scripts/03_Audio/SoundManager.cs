using UnityEngine;
using Random = UnityEngine.Random;

namespace PTWO_PR
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        [SerializeField] private AudioSource musicSource, effectsSource;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        
            AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 1);
        
        }

        public void PlaySound(AudioClip clip)
        {
            effectsSource.PlayOneShot(clip);
        }

        
        // method for playing the randomized sound in soundmanager
        public void PlayRandomizedSound(AudioClip clip)
        {
            RandomizeSoundEffect();
            effectsSource.PlayOneShot(clip);
        }

        // change pitch of sound effect to make sounds less generic if they happen more than once
        private void RandomizeSoundEffect()
        {
            effectsSource.pitch = Random.Range(.75f, 1.25f);
        }

        // effect sounds on/off
        public void ToggleEffects()
        {
            effectsSource.mute = !effectsSource.mute;
        }
    
        // music on/off
        public void ToggleMusic()
        {
            musicSource.mute = !musicSource.mute;
        }
    }

}