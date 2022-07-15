using UnityEngine;
using UnityEngine.UI;

namespace PTWO_PR
{
    public class Progressbar : MonoBehaviour
    {
        [SerializeField] private Slider monsterProgressbar;

        [SerializeField] private PlotManager plotManager;

        [SerializeField] private Vector3 offset;

        [SerializeField] private Image fillColor;

        private void Update()
        {
            // disable progressbars when game is paused
            if (PauseMenu.isPaused)
            {
                monsterProgressbar.gameObject.SetActive(false);
            }
            else
            {
                monsterProgressbar.gameObject.SetActive(true);
            }

            monsterProgressbar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);

            monsterProgressbar.maxValue = plotManager.SelectedMonster.MonsterHatchTime;

            monsterProgressbar.value = plotManager.FullTimer;

        }
    }
}

