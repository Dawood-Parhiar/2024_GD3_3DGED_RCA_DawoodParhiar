namespace GD
{
    /// <summary>
    /// Defines the type of unit that an NPC will attack
    /// </summary>
    /// <see cref="GD.Objects.PlaceableObjectData"/>
    public enum AttackTargetType : sbyte
    {
        Any, Building, None, Unit, Vehicle
    }
}