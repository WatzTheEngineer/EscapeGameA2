using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public interface IRaycastable
    {
        void OnRaycastDo();
    }

    public class Raycast : MonoBehaviour
    {
        private const string Tag = "InteractiveObject";
        private const string Tag2 = "InteractiveComputer";
        private const string Tag3 = "InteractiveDoor";
        private const string Tag4 = "InterativeBombCase";
        private const string Tag5 = "InteractiveBombComputer";
        private const string Tag6 = "ElevatorButton";
        private const string Tag7 = "InteractiveBoardComputer";
        
        private const string TextTag = "TextTag";
        [SerializeField] private int rayLength;
        [SerializeField] private LayerMask layerMaskInterract;
        [SerializeField] private string exculdeLayerName;
        [SerializeField] private KeyCode openKey = KeyCode.E;
        [SerializeField] private GameObject crossAir;
        public GameObject _lock;
        private GameObject _bombCase;
        private lockPickingController _lockPickingController;
        private ComputerController _raycastComputerInteraction;
        private ComputerBombController _raycastComputerBombInteraction;
        private IRaycastable _raycastedInteractive;
        private ElevatorController _elevatorController;
        private ComputerBoardController _boardController;


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

                    if (Input.GetKeyDown(openKey)) _raycastedInteractive.OnRaycastDo();
                }
                else if (hit.collider.CompareTag(TextTag))
                {
                    if (Input.GetKeyDown(openKey)) hit.collider.gameObject.GetComponent<TextOnInterract>().Send();
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

            RaycastHit hit3;
            var fwd3 = transform.TransformDirection(Vector3.forward);
            var mask3 = (1 << LayerMask.NameToLayer(exculdeLayerName)) | layerMaskInterract.value;
            if (Physics.Raycast(transform.position, fwd3, out hit3, rayLength, mask3))
                if (hit.collider.CompareTag(Tag4))
                {
                    _bombCase = hit.collider.gameObject;
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 2.5f;


                    if (Input.GetKeyDown(openKey))
                    {
                        _bombCase.SetActive(false);
                    };
                }

            RaycastHit hit4;
            var fwd4 = transform.TransformDirection(Vector3.forward);
            var mask4 = (1 << LayerMask.NameToLayer(exculdeLayerName)) | layerMaskInterract.value;
            if (Physics.Raycast(transform.position, fwd4, out hit4, rayLength, mask4))
                if (hit.collider.CompareTag(Tag5))
                {
                    _raycastComputerBombInteraction = hit.collider.gameObject.GetComponent<ComputerBombController>();
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 2.5f;

                    if (Input.GetKeyDown(openKey)) _raycastComputerBombInteraction.WindowsLaunch();
                }

            RaycastHit hit5;
            var fwd5 = transform.TransformDirection(Vector3.forward);
            var mask5 = (1 << LayerMask.NameToLayer(exculdeLayerName)) | layerMaskInterract.value;
            if (Physics.Raycast(transform.position, fwd5, out hit5, rayLength, mask5))
                if (hit.collider.CompareTag(Tag6))
                {
                    _elevatorController = hit.collider.gameObject.GetComponent<ElevatorController>();
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 2.5f;

                    if (Input.GetKeyDown(openKey)) _elevatorController.Up();
                }

            RaycastHit hit6;
            var fwd6 = transform.TransformDirection(Vector3.forward);
            var mask6 = (1 << LayerMask.NameToLayer(exculdeLayerName)) | layerMaskInterract.value;
            if (Physics.Raycast(transform.position, fwd6, out hit6, rayLength, mask6))
                if (hit.collider.CompareTag(Tag7))
                {
                    _boardController = hit.collider.gameObject.GetComponent<ComputerBoardController>();
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 2.5f;

                    if (Input.GetKeyDown(openKey)) _boardController.WindowsLaunch();
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
                    crossAir.GetComponent<CanvasScaler>().scaleFactor = 1f;

            // ===================================================================
            //         TODO: CODE HORRIBLE ! DOIT ABSOLUMENT ETRE REVU !
            // ===================================================================
        }
    }
}