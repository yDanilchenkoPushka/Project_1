using System;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IInteractable
    {
        void Interact(object sender);
        Vector3 Position { get; }
    }
}