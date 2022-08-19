using System;
using DefaultNamespace;

public interface IInteractiveHandler
{
    event Action OnInteractiveEntered;
    event Action OnInteractiveExited;
    void EnterInteractive(IInteractable interactable);
    void ExitInteractive();
}