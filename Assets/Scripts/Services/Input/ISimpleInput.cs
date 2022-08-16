using System;
using UnityEngine;

namespace DefaultNamespace
{
    public interface ISimpleInput
    {
        event Action OnTaped;
        
        Vector2 Axis { get; }
    }
}