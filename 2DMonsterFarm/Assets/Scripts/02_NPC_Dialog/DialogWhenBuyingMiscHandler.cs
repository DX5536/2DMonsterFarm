using UnityEngine;

namespace PTWO_PR
{
    public class DialogWhenBuyingMiscHandler : MonoBehaviour
    {
        [Header("Attach to ItemBuy Button")]
        
        [SerializeField] private string miscItemNameID;

        //Will attach to the buy button and activate per Event
        public void ActivateNPCTextWhenBuyingMisc()
        {
            NPCTextManager.BuyingMiscNPCDialog(miscItemNameID);
        }
    }
}

