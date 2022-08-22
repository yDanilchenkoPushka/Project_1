using System;
using DefaultNamespace;

public interface IInteractiveHandler
{
    event Action<IInteractable> OnInteractiveEntered;
    event Action<IInteractable> OnInteractiveExited;
    void EnterInteractive(IInteractable interactable);
    void ExitInteractive(IInteractable interactable);
}