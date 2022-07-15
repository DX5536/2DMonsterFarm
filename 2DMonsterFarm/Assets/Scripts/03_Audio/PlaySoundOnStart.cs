using UnityEngine;

namespace PTWO_PR
{
    public class PlaySoundOnStart : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        void Start()
        {
            SoundManager.instance.PlaySound(clip);
        }

    }
}
