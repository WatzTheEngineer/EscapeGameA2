using UnityEngine;

namespace Utils
{
    public class Raycast : MonoBehaviour
    {
        private const string Tag = "InteractiveObject";
        [SerializeField] private int rayLength;
        [SerializeField] private LayerMask layerMaskInterract;
        [SerializeField] private string exculdeLayerName;
        [SerializeField] private KeyCode openKey = KeyCode.E;

        private InteractiveController _raycastedInteractive;


        private void Update()
        {
            RaycastHit hit;
            var fwd = transform.TransformDirection(Vector3.forward);
            var mask = (1 << LayerMask.NameToLayer(exculdeLayerName)) | layerMaskInterract.value;
            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
                if (hit.collider.CompareTag(Tag))
                {
                    _raycastedInteractive = hit.collider.gameObject.GetComponent<InteractiveController>();


                    if (Input.GetKeyDown(openKey))
                    {
                        _raycastedInteractive.PlayAnimation();
                    }
                }
        }
    }
}