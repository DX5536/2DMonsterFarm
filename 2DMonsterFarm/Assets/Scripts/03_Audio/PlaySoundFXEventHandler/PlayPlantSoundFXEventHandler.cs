using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PTWO_PR
{
    public class PlayPlantSoundFXEventHandler : MonoBehaviour
    {
        //Trigger the specific sound and its event
        public void ActivatePlayPlantSound()
        {
            SoundFXEventManager.PlayPlantSound();
        }
    }
}