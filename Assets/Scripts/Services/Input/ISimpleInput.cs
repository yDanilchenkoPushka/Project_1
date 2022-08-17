using System;
using UnityEngine;

namespace Services.Input
{
    public interface ISimpleInput : IService
    {
        event Action<string> OnControlUpdated;
        event Action OnTaped;

        event Action OnUpClicked;
        event Action OnDownClicked;

        Vector2 Axis { get; }
    }
}