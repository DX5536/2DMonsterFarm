using UnityEngine;

namespace PTWO_PR
{
    [CreateAssetMenu(fileName = "New Monster" , menuName = "Monster")]
    public class MonsterScriptableObject : ScriptableObject
    {

        [SerializeField] private string monsterDisplayName;

        public string MonsterDisplayName
        {
            get { return monsterDisplayName; }
        }

        [SerializeField] private Sprite[] monsterStages;

        public Sprite[] MonsterStages
        {
            get { return monsterStages; }
        }

        [SerializeField] private float timeBetweenStages;

        public float TimeBetweenStages
        {
            get { return timeBetweenStages; }
        }

        [SerializeField] private float monsterHatchTime;

        public float MonsterHatchTime
        {
            get { return monsterHatchTime; }
        }

        [SerializeField] private int buyPrice;

        public int BuyPrice
        {
            get { return buyPrice; }
        }

        [SerializeField] private int sellPrice;

        public int SellPrice
        {
            get { return sellPrice; }
        }

        [SerializeField] private Sprite icon;

        public Sprite Icon
        {
            get { return icon; }
        }


    }

}
