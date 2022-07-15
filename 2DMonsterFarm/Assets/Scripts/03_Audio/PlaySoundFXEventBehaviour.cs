using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PTWO_PR
{
    public class PlaySoundFXEventBehaviour : MonoBehaviour
    {
        [Header("Audio")]

        [SerializeField] private AudioClip harvestSound;

        [SerializeField] private AudioClip plantSound;

        [SerializeField] private AudioClip foodSound;

        [SerializeField] private AudioClip normalTileSound;

        [SerializeField] private AudioClip skyTileSound;

        [SerializeField] private AudioClip lavaTileSound;

        [SerializeField] private AudioClip readyToHarvestSound;

        private void OnEnable()
        {
            SoundFXEventManager.onPlayHarvestSound += PlayHarvestSoundWhenCall;
            SoundFXEventManager.onPlayPlantSound += PlayPlantSoundWhenCall;
            SoundFXEventManager.onPlayFoodSound += PlayFoodSoundWhenCall;

            SoundFXEventManager.onPlayNormalTileSound += PlayNormalTileSoundWhenCall;
            SoundFXEventManager.onPlaySkyTileSound += PlaySkyTileSoundWhenCall;
            SoundFXEventManager.onPlayLavaTileSound += PlayLavaTileSoundWhenCall;

            SoundFXEventManager.onPlayReadyToHarvestSound += PlayReadyToHarvestSoundWhenCall;
        }

        private void OnDisable()
        {
            SoundFXEventManager.onPlayHarvestSound -= PlayHarvestSoundWhenCall;
            SoundFXEventManager.onPlayPlantSound -= PlayPlantSoundWhenCall;
            SoundFXEventManager.onPlayFoodSound -= PlayFoodSoundWhenCall;

            SoundFXEventManager.onPlayNormalTileSound -= PlayNormalTileSoundWhenCall;
            SoundFXEventManager.onPlaySkyTileSound -= PlaySkyTileSoundWhenCall;
            SoundFXEventManager.onPlayLavaTileSound -= PlayLavaTileSoundWhenCall;

            SoundFXEventManager.onPlayReadyToHarvestSound -= PlayReadyToHarvestSoundWhenCall;
        }

        private void PlayHarvestSoundWhenCall()
        {
            SoundManager.instance.PlayRandomizedSound(harvestSound);
        }

        private void PlayPlantSoundWhenCall()
        {
            SoundManager.instance.PlayRandomizedSound(plantSound);
        }

        private void PlayFoodSoundWhenCall()
        {
            SoundManager.instance.PlayRandomizedSound(foodSound);
        }

        private void PlayNormalTileSoundWhenCall()
        {
            SoundManager.instance.PlayRandomizedSound(normalTileSound);
        }

        private void PlaySkyTileSoundWhenCall()
        {
            SoundManager.instance.PlayRandomizedSound(skyTileSound);
        }

        private void PlayLavaTileSoundWhenCall()
        {
            SoundManager.instance.PlayRandomizedSound(lavaTileSound);
        }

        private void PlayReadyToHarvestSoundWhenCall()
        {
            SoundManager.instance.PlayRandomizedSound(readyToHarvestSound);
        }
    }
}
