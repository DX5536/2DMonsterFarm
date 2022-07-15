using UnityEngine;


namespace PTWO_PR
{
    public class PlayAnimationWhenHarvestBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Animator energyAnimator;

        [SerializeField]
        private string energyBeamUpStateName;

        private void OnEnable()
        {
            HarvestAnimationManager.onPlayAnimationWhenHarvest += PlayAnimationOnHarvest;
        }

        private void OnDisable()
        {
            HarvestAnimationManager.onPlayAnimationWhenHarvest -= PlayAnimationOnHarvest;
        }

        private void PlayAnimationOnHarvest()
        {
            //If the EnergyBeamUp animation is currently NOT playing
            if (!energyAnimator.GetCurrentAnimatorStateInfo(0).IsName(energyBeamUpStateName))
            {
                //Then play it
                energyAnimator.Play(energyBeamUpStateName);
                Debug.Log("Harvest Behaviour is called");
            }
        }
    }

}

