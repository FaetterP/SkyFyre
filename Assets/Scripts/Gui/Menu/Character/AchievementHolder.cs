using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Scripts.Gui.Menu.Character
{
    class AchievementHolder
    {
        private static List<AchievementEnum> _achievements = new List<AchievementEnum> { };

        public static ReadOnlyCollection<AchievementEnum> Achievements => _achievements.AsReadOnly();

        public static void RegisterAchievement(AchievementEnum achievement)
        {
            _achievements.Add(achievement);
        }
    }
}
