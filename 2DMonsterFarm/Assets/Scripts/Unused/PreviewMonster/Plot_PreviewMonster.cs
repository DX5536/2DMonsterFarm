using System.Collections;
using System.Collections.Generic;
using PTWO_PR;
using UnityEngine;

namespace PTWO_PR
{
    public class Plot_PreviewMonster : MonoBehaviour
    {
        [Header("Components")]

        [SerializeField] 
        private PreviewMonster selectedPreviewMonster;

        [SerializeField] 
        private FarmManager farmManager;

        [SerializeField]
        private GameObject monsterPreview;

        [Header("Sprites")]

        [SerializeField] 
        private SpriteRenderer monsterPreviewRenderer;

        // Start is called before the first frame update
        void Start()
        {
            monsterPreviewRenderer = monsterPreview.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (selectedPreviewMonster.SelectedMonsterInShop)
            {
                monsterPreviewRenderer = selectedPreviewMonster.MonsterSpriteRenderer;
            }
        }
    }
}

