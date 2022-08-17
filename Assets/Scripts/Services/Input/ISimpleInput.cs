using System;
using CodeBase.Services;
using UnityEngine;

namespace DefaultNamespace
{
    public interface ISimpleInput : IService
    {
        event Action OnTaped;
        
        event Action OnUpClicked;
        event Action OnDownClicked;
        
        Vector2 Axis { get; }
    }
}