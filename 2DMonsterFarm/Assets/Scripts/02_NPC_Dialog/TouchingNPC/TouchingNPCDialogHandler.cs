using UnityEngine;


namespace PTWO_PR
{
    public class TouchingNPCDialogHandler : MonoBehaviour
    {
        [SerializeField] private string bodyPartNameID;

        private void OnMouseOver()
        {
            //Player hit a part with Collider > Click L.Click = Play Dialog
            if (Input.GetMouseButtonDown(0))
            {
                NPCTextManager.TouchingNPCDialog(bodyPartNameID);
                Debug.Log("Player touch with MouseOver " + this.gameObject.name);
            }
        }

    }
}

