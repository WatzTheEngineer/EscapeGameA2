using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public interface IRaycastable
    {
        void PlayAnimation();
    }

    public class Raycast : MonoBehaviour
    {
        private const string Tag = "InteractiveObject";
        private const string Tag2 = "InteractiveComputer";
        private const string Tag3 = "InteractiveDoor";
        [SerializeField] private int rayLength;
        [SerializeField] private LayerMask layerMaskInterract;
        [SerializeField] private string exculdeLayerName;
        [SerializeField] private KeyCode openKey = KeyCode.E;
        [SerializeField] private GameObject crossAir;
        public GameObject _lock;
        private lockPickingController _lockPickingController;
        private ComputerController _raycastComputerInteraction;
        private IRaycastable _raycastedInteractive;


        private void Update()
        {
            RaycastHit hit;
            var fwd = transform.TransformDirection(Vector3.forward);
            var mask = (1 << LayerMask.NameToLayer(exculdeLayerName)) | layerMaskInterract.value;
            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
                if (hit.collider.CompareTag(Tag))
                {
                    _raycastedInteractive = hit.collider.gameObject.GetComponent<IRaycastable>();
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 2.5f;

                    if (Input.GetKeyDown(openKey)) _raycastedInteractive.PlayAnimation();
                }

            RaycastHit hit2;
            var fwd2 = transform.TransformDirection(Vector3.forward);
            var mask2 = (1 << LayerMask.NameToLayer(exculdeLayerName)) | layerMaskInterract.value;
            if (Physics.Raycast(transform.position, fwd2, out hit2, rayLength, mask2))
                if (hit.collider.CompareTag(Tag2))
                {
                    _raycastComputerInteraction = hit.collider.gameObject.GetComponent<ComputerController>();
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 2.5f;

                    if (Input.GetKeyDown(openKey)) _raycastComputerInteraction.WindowsLaunch();
                }

            RaycastHit hitDoor;
            var fwdDoor = transform.TransformDirection(Vector3.forward);
            var maskDoor = (1 << LayerMask.NameToLayer(exculdeLayerName)) | layerMaskInterract.value;
            if (Physics.Raycast(transform.position, fwdDoor, out hitDoor, rayLength, maskDoor))
                if (hit.collider.CompareTag(Tag3))
                {
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 2.5f;


                    if (Input.GetKeyDown(openKey))
                    {
                        _lockPickingController = _lock.GetComponent<lockPickingController>();
                        _lockPickingController.launchLockPicking();
                    }
                }

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
                if (!hit.collider.CompareTag(Tag) && !hit.collider.CompareTag(Tag2) && !hit.collider.CompareTag(Tag3))
                {
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 1f;
                }

            // ===================================================================
            //         TODO: CODE HORRIBLE ! DOIT ABSOLUMENT ETRE REVU !
            // ===================================================================
        }
    }
}