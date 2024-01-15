using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class PickableObjectTests
{
    private GameObject pickableObjectGO;
    private PickableObject pickableObjectScript;

    [SetUp]
    public void SetUp()
    {
        // Créer une instance de l'objet PickableObject pour chaque test
        pickableObjectGO = new GameObject();
        pickableObjectScript = pickableObjectGO.AddComponent<PickableObject>();
        pickableObjectGO.AddComponent<Rigidbody>();
        pickableObjectScript.player = new GameObject().transform;
        pickableObjectScript.playerCam = new GameObject().transform;
        pickableObjectScript.throwForce = 10f;
        pickableObjectScript.pickDistance = 2f;
        pickableObjectScript.Start(); // Appeler Start manuellement pour initialiser rigidbody
    }

    [TearDown]
    public void TearDown()
    {
        // Détruire l'objet après chaque test
        Object.DestroyImmediate(pickableObjectGO);
    }

    [Test]
    public void CheckPlayerProximity_PlayerNear_ReturnsTrue()
    {
        // Arrange
        pickableObjectScript.player.position = Vector3.zero;
        pickableObjectGO.transform.position = Vector3.zero;

        // Act
        pickableObjectScript.CheckPlayerProximity();

        // Assert
        Assert.IsTrue(pickableObjectScript.isPlayerNear);
    }

    [Test]
    public void CheckPlayerProximity_PlayerFar_ReturnsFalse()
    {
        // Arrange
        pickableObjectScript.player.position = Vector3.zero;
        pickableObjectGO.transform.position = new Vector3(5f, 0f, 0f);

        // Act
        pickableObjectScript.CheckPlayerProximity();

        // Assert
        Assert.IsFalse(pickableObjectScript.isPlayerNear);
    }

    [Test]
    public void PickObject_PlayerNearAndNotCarriedAndNoOtherCarriedObject_CarriesObject()
    {
        // Arrange
        pickableObjectScript.isPlayerNear = true;
        pickableObjectScript.isBeingCarried = false;
        PickableObject.carriedObject = null;

        // Act
        pickableObjectScript.PickObject();

        // Assert
        Assert.IsTrue(pickableObjectScript.isBeingCarried);
        Assert.AreEqual(pickableObjectGO, PickableObject.carriedObject);
    }

    // Ajoutez d'autres tests pour les autres méthodes de la classe PickableObject
}
