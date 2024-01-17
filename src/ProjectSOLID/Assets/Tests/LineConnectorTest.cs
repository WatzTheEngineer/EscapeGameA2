using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class LineControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            // Créer une instance de l'objet LineController pour chaque test
            _lineControllerGo = new GameObject();
            _lineControllerScript = _lineControllerGo.AddComponent<LineController>();
            _lineControllerGo.AddComponent<LineRenderer>();
            _lineControllerScript.points = new Transform[2];
            _lineControllerScript.points[0] = new GameObject().transform;
            _lineControllerScript.points[1] = new GameObject().transform;
        }

        [TearDown]
        public void TearDown()
        {
            // Détruire l'objet après chaque test
            Object.DestroyImmediate(_lineControllerGo);
        }

        private GameObject _lineControllerGo;
        private LineController _lineControllerScript;

        [Test]
        public void Start_PositionCountEqualsPointsLength()
        {
            // Act
            _lineControllerScript.Start();

            // Assert
            Assert.AreEqual(_lineControllerScript.LineRenderer.positionCount, _lineControllerScript.Points.Length);
        }

        [Test]
        public void UpdateLineRendererPositions_PositionsUpdatedCorrectly()
        {
            // Arrange
            _lineControllerScript.Start(); // Appeler Start manuellement pour initialiser LineRenderer

            // Act
            _lineControllerScript.UpdateLineRendererPositions();

            // Assert
            for (var i = 0; i < _lineControllerScript.Points.Length; i++)
                Assert.AreEqual(_lineControllerScript.LineRenderer.GetPosition(i),
                    _lineControllerScript.Points[i].position);
        }

        // Ajoutez d'autres tests pour les autres méthodes ou comportements de la classe LineController
    }
}