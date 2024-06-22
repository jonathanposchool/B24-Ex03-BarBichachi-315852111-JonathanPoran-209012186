namespace Ex03.GarageLogic.Utils
{
    public class ValueOutOfRangeException : Exception
    {
        public float m_MinValue { get; }
        public float m_MaxValue { get; }

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue)
            : base(i_Message)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
