using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class PickableObjectTests
    {
        [SetUp]
        public void SetUp()
        {
            // Créer une instance de l'objet PickableObject pour chaque test
            _pickableObjectGo = new GameObject();
            _pickableObjectScript = _pickableObjectGo.AddComponent<PickableObject>();
            _pickableObjectGo.AddComponent<Rigidbody>();
            _pickableObjectScript.player = new GameObject().transform;
            _pickableObjectScript.playerCam = new GameObject().transform;
            _pickableObjectScript.throwForce = 10f;
            _pickableObjectScript.pickDistance = 2f;
            _pickableObjectScript.Start(); // Appeler Start manuellement pour initialiser rigidbody
        }

        [TearDown]
        public void TearDown()
        {
            // Détruire l'objet après chaque test
            Object.DestroyImmediate(_pickableObjectGo);
        }

        private GameObject _pickableObjectGo;
        private PickableObject _pickableObjectScript;

        [Test]
        public void PickObject_PlayerNearAndNotCarriedAndNoOtherCarriedObject_CarriesObject()
        {
            // Arrange
            _pickableObjectScript.isPlayerNear = true;
            _pickableObjectScript.isBeingCarried = false;
            PickableObject.CarriedObject = null;

            // Act
            _pickableObjectScript.PickObject();

            // Assert
            Assert.IsTrue(_pickableObjectScript.isBeingCarried);
            Assert.AreEqual(_pickableObjectGo, PickableObject.CarriedObject);
        }

        // Ajoutez d'autres tests pour les autres méthodes de la classe PickableObject
    }
}