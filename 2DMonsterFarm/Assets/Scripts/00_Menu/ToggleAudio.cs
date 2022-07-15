using UnityEngine;

namespace PTWO_PR
{
    public class ToggleAudio : MonoBehaviour
    {
        [SerializeField] private bool toggleMusic, toggleEffects;

        public void Toggle()
        {
            if (toggleEffects) SoundManager.instance.ToggleEffects();
            if (toggleMusic) SoundManager.instance.ToggleMusic();
        } 
    }

}