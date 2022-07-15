using UnityEngine;

namespace PTWO_PR
{
    public class DialogWhenBuyingMiscBehaviour : MonoBehaviour
    {
        //Refer our S.O.
        [SerializeField] private DisplayText_Data myDisplayText_Data;

        //Refer our Story Canvas
        [SerializeField] private TextDisplayDialog currentNPCTextCanvas;

        [SerializeField] private string miscItemNameID;

        private void OnEnable()
        {
            NPCTextManager.onBuyingMiscNPCDialog += DisplayDialogWhenBuyingMisc;
        }

        private void OnDisable()
        {
            NPCTextManager.onBuyingMiscNPCDialog -= DisplayDialogWhenBuyingMisc;
        }

        private void DisplayDialogWhenBuyingMisc(string miscItemID)
        {
            if (miscItemID == this.miscItemNameID)
            {
                //Now I want the S.O. in NPC_Text Canvas to be replace with THE S.O. in THIS GameObject
                currentNPCTextCanvas.CurrentDisplayText_Data = myDisplayText_Data;

                //Once it's assigned to the S.O. in Story Canvas -> Trigger DisplayNPCDialog
                currentNPCTextCanvas.DisplayNPCDialog();
            }
        }
    }
}

