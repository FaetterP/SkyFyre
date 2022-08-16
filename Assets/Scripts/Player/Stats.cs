namespace Assets.Scripts.Player
{
    class Stats
    {
        private static int s_money;

        public static int Money => s_money;

        public static void AddMoney(int value)
        {
            s_money += value;
        }

        public static bool RemoveMoney(int value)
        {
            if (s_money < value)
                return false;

            s_money -= value;
            return true;
        }
    }
}
