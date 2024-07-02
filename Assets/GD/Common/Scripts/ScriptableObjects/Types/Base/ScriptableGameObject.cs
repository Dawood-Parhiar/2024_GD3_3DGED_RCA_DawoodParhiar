using System;
using UnityEngine;

namespace GD
{
    public class ScriptableGameObject : ScriptableObject
    {
        [Header("Useful Info")]
        [ContextMenuItem("Reset Description", "ResetDescription")]
        public string Description;

        /*
           public ItemType Type;

           [TextArea(2, 4)]
           [Tooltip("Add any notes on potential changes to this value")]
           [ContextMenuItem("Reset Notes", "ResetNotes")]
           public string Notes;

           [ContextMenuItem("Set Now", "SetNow")]
           public string LastUpdated = DateTime.Now.ToString("dd/MM/yy");

           public void SetNow()
           {
               LastUpdated = DateTime.Now.ToString("dd/MM/yy");
           }

           public void ResetNotes()
           {
               Notes = "";
           }
        */

        public void ResetDescription()
        {
            Description = "";
        }
    }
}