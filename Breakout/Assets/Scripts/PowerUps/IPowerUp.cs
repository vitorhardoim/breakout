using UnityEngine;

//Defines contractual obligations that a Power-up item must adhere to.
public interface IPowerUp {
    void Activate();
    void Deactivate();
}