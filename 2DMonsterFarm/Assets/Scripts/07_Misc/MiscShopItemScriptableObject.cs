using UnityEngine;

namespace PTWO_PR
{
    [CreateAssetMenu(fileName = "New MiscItem" , menuName = "Misc")]
    public class MiscShopItemScriptableObject : ScriptableObject
    {

        [SerializeField] private string miscDisplayName;

        public string MiscDisplayName
        {
            get { return miscDisplayName; }
        }

        [SerializeField] private int buyPrice;

        public int BuyPrice
        {
            get { return buyPrice; }
        }
        
        [SerializeField] private Sprite icon;

        public Sprite Icon
        {
            get { return icon; }
        }


    }

}
