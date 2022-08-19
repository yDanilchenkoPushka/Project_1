using UnityEngine;

namespace DefaultNamespace.Gizmos
{
    [RequireComponent(typeof(BoxCollider))]
    public class DrawingBoxCollider : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private BoxCollider _boxCollider;

        private void OnValidate() => 
            _boxCollider = GetComponent<BoxCollider>();

        
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.4f);

            Vector3 size = new Vector3(
                _boxCollider.size.x * transform.localScale.x,
                _boxCollider.size.y * transform.localScale.y,
                _boxCollider.size.z * transform.localScale.z);
            
            Gizmos.DrawCube(transform.position, size);
        }
    }
}