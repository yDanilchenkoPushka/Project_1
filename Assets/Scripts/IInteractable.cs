using UnityEngine;

namespace Interactive
{
    public interface IInteractable
    {
        void Interact(object sender);
        Vector3 Position { get; }
    }
}