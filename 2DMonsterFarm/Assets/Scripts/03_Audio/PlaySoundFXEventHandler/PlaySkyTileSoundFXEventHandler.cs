using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PTWO_PR
{
    public class PlaySkyTileSoundFXEventHandler : MonoBehaviour
    {
        public void ActivatePlaySkySound()
        {
            SoundFXEventManager.PlaySkyTileSound();
        }
    }
}