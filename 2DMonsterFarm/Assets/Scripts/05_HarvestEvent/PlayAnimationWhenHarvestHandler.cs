using UnityEngine;

namespace PTWO_PR
{
    public class PlayAnimationWhenHarvestHandler : MonoBehaviour
    {
        public void ActivatePlayAnimationOnHarvest()
        {
            HarvestAnimationManager.PlayAnimationWhenHarvest();
            Debug.Log("Harvest Handler is called");
        }
    }
}

