using System;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Player
{
    public class PlayerAgent
    {
        public event Action<float> OnAreaChanged;
        
        private Transform _transform;

        private int _currentAreaIndex = -1;

        public void Construct(Transform transform) => 
            _transform = transform;

        public void Tick() => 
            CheckArea();

        private void CheckArea()
        {
            Vector3 position = _transform.position;

            position.y -= 0.5f;
        
            NavMeshHit hit;
            NavMesh.SamplePosition(position, out hit, 0.1f, NavMesh.AllAreas);

            int index = IndexFromMask(hit.mask);

            if (_currentAreaIndex != index)
            {
                _currentAreaIndex = index;
                
                float coast = NavMesh.GetAreaCost(_currentAreaIndex);
                
                OnAreaChanged?.Invoke(coast);
            }
        }

        private int IndexFromMask(int mask)
        {
            for (int i = 0; i < 32; ++i)
            {
                if ((1 << i) == mask)
                    return i;
            }
            
            return -1;
        }
    }
}