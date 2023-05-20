namespace Ex03.GarageLogic.Models
{
    internal abstract class EnergySource
    {
        protected float m_EnergyLeft;
        protected readonly float m_MaxEnergyCapacity;

        public float EnergyPercentage => m_MaxEnergyCapacity / m_EnergyLeft;
    }
}
