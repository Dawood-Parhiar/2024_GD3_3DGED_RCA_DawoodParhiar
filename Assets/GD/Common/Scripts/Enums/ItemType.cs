namespace GD
{
    /// <summary>
    /// Used in a ScriptableObject to indicate the type of the item about which the SO is storing information
    /// </summary>
    /// <see cref="Objects.BaseObjectData"/>
    public enum ItemType : sbyte
    {
        Building, Equipment, Food, Medicine, PC, NPC, Player, Story, Weapon,
        Portal
    }
}