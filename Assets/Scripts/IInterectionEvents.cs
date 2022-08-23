using System;
using Interactive;

namespace Characters.Player
{
    public interface IInterectionEvents
    {
        event Action<IInteractable> OnEntered;
        event Action<IInteractable> OnExited;
        event Action OnUpdated;
    }
}