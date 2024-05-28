using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    private Scene simulationScene;
    private PhysicsScene physicsScene;
    public Transform obstacle;
    void Start() {
        CreatePhysicsScene();
    }

    void OnEnable() {
        ballGrabbed.OnReleased += SimulateTrajectory;
    }

    void CreatePhysicsScene() {
        simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        physicsScene = simulationScene.GetPhysicsScene();
        var ghostObj = Instantiate(obstacle.gameObject, obstacle.position, obstacle.rotation);
        ghostObj.GetComponent<Terrain>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
    }

    [SerializeField] private LineRenderer line;
    [SerializeField] private int maxPhysicsFrameIterations = 100;
    void SimulateTrajectory() {
        var ghostObj = Instantiate(this.gameObject, transform.position, transform.rotation);
        ghostObj.GetComponent<Renderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
        Rigidbody originalRb = this.gameObject.GetComponent<Rigidbody>();
        Rigidbody ghostRb = ghostObj.GetComponent<Rigidbody>();
        if (originalRb != null && ghostRb != null) {
            ghostRb.velocity = originalRb.velocity;
            ghostRb.angularVelocity = originalRb.angularVelocity;
            ghostRb.mass = originalRb.mass;
        }

        line.positionCount = maxPhysicsFrameIterations;
        for (int i = 0; i < maxPhysicsFrameIterations; i++) {
            physicsScene.Simulate(Time.fixedDeltaTime);
            line.SetPosition(i, ghostObj.transform.position);
        }

        Destroy(ghostObj);
    }
}