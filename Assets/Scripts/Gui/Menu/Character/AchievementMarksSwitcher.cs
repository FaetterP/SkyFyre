using UnityEngine;

namespace Assets.Scripts.Gui.Menu.Character
{
    class AchievementMarksSwitcher : MonoBehaviour
    {
        [SerializeField] private AchievementMark[] _marks;

        private void Start()
        {
            foreach (AchievementMark mark in _marks)
            {
                if (AchievementHolder.Achievements.Contains(mark.Achievement))
                {
                    mark.Enable();
                }
            }
        }
    }
}
