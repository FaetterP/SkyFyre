namespace Assets.Scripts.Gui.Menu.Character
{
    class StatsCounter
    {
        private int _value;
        private static int s_points = 5;
        public int Value => _value;
        public static int Points => s_points;

        public StatsCounter(int value)
        {
            _value = value;
        }

        public void AddValue()
        {
            if (s_points <= 0)
                return;

            s_points--;
            _value++;
        }

        public static void AddPoints(int count)
        {
            s_points += count;
        }
    }
}
