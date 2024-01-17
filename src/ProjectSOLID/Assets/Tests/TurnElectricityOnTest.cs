using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class TurnElectricityOnTests // Vaste fumisterie
    {
        [SetUp]
        public void SetUp()
        {
            // Créer une instance de l'objet TurnElectricityOn pour chaque test
            _electricityObject = new GameObject();
            _electricityScript = _electricityObject.AddComponent<TurnElectricityOn>();
        }

        [TearDown]
        public void TearDown()
        {
            // Détruire l'objet après chaque test
            Object.DestroyImmediate(_electricityObject);
        }

        private GameObject _electricityObject;
        private TurnElectricityOn _electricityScript;

        [Test]
        public void Trigger_TurnsOnGameObject()
        {
            // Act
            _electricityScript.Trigger();

            // Assert
            Assert.IsTrue(_electricityObject.activeSelf);
        }

        [Test]
        public void Trigger_SetsElectricityStateToTrue()
        {
            // Act
            _electricityScript.Trigger();

            // Assert
            Assert.IsTrue(_electricityScript.GetElectricityState());
        }
    }
}