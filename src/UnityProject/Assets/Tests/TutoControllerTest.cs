using Controllers;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class TutorialControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            // Créer une instance de l'objet TutorialController pour chaque test
            _tutorialControllerGo = new GameObject();
            _tutorialControllerScript = _tutorialControllerGo.AddComponent<TutorialController>();
            _tutorialControllerScript.canvasGroup = _tutorialControllerGo.AddComponent<CanvasGroup>();

            // Initialiser les panels (GameObject) dans la classe de test
            _tutorialControllerScript.zqsdPanel = new GameObject();
            _tutorialControllerScript.spacePanel = new GameObject();
            _tutorialControllerScript.ePanel = new GameObject();
            _tutorialControllerScript.clickPanel = new GameObject();
            _tutorialControllerScript.shiftPanel = new GameObject();
        }

        [TearDown]
        public void TearDown()
        {
            // Détruire l'objet après chaque test
            Object.DestroyImmediate(_tutorialControllerGo);
        }

        private GameObject _tutorialControllerGo;
        private TutorialController _tutorialControllerScript;

        [Test]
        public void FadeOutPanel_FadesOutCorrectly()
        {
            // Arrange
            _tutorialControllerScript.canvasGroup.alpha = 1;

            // Act
            var fadeOutCoroutine = _tutorialControllerScript.FadeOutPanel(_tutorialControllerScript.zqsdPanel);

            while (fadeOutCoroutine.MoveNext())
            {
            }

            // Assert
            Assert.IsFalse(_tutorialControllerScript.zqsdPanel.activeSelf);
            Assert.AreEqual(0, _tutorialControllerScript.canvasGroup.alpha);
        }
        
        [Test]
        public void FadeOutPanel_FadesInCorrectly()
        {
            // Arrange
            _tutorialControllerScript.canvasGroup.alpha = 1;

            // Act
            var fadeInCoroutine = _tutorialControllerScript.FadeInPanel(_tutorialControllerScript.zqsdPanel, 0);

            while (fadeInCoroutine.MoveNext())
            {
            }

            // Assert
            Assert.IsTrue(_tutorialControllerScript.zqsdPanel.activeSelf);
            Assert.AreEqual(1, _tutorialControllerScript.canvasGroup.alpha);
        }
    }
}