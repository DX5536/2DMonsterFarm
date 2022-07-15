using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PTWO_PR
{
    public class PlayLavaTileSoundFXEventHandler : MonoBehaviour
    {
        public void ActivatePlayLavaSound()
        {
            SoundFXEventManager.PlayLavaTileSound();
        }
    }
}