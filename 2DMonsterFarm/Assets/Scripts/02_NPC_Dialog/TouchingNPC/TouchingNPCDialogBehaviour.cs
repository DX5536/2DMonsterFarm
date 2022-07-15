using UnityEngine;

namespace PTWO_PR
{
    public class TouchingNPCDialogBehaviour : MonoBehaviour
    {
        //Refer our S.O.
        [SerializeField] private DisplayText_Data myDisplayText_Data;

        //Refer our Story Canvas
        [SerializeField] private TextDisplayDialog currentNPCTextCanvas;

        [SerializeField] private string bodyPartNameID;

        private void OnEnable()
        {
            NPCTextManager.onTouchingNPCDialog += DisplayDialogWhenTouched;
        }

        private void OnDisable()
        {
            NPCTextManager.onTouchingNPCDialog -= DisplayDialogWhenTouched;
        }

        private void DisplayDialogWhenTouched(string touchedBodyPartID)
        {
            if (touchedBodyPartID == this.bodyPartNameID)
            {
                //Now I want the S.O. in NPC_Text Canvas to be replace with THE S.O. in THIS GameObject
                currentNPCTextCanvas.GetComponent<TextDisplayDialog>().CurrentDisplayText_Data = myDisplayText_Data;

                //Once it's assigned to the S.O. in Story Canvas -> Trigger DisplayNPCDialog
                currentNPCTextCanvas.GetComponent<TextDisplayDialog>().DisplayNPCDialog();
            }
        }
    }
}

