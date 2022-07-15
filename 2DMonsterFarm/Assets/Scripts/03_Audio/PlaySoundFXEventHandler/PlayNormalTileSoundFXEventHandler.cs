using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PTWO_PR
{
    public class PlayNormalTileSoundFXEventHandler : MonoBehaviour
    {
        //Trigger the specific sound and its event 
        public void ActivatePlayNormalTileSound()
        {
            SoundFXEventManager.PlayNormalTileSound();
        }
    }
}