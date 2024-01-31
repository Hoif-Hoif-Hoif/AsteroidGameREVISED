using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.IO;
//using Spaceship;

public class TheEditorWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/TheEditorWindow")]
    public static void ShowExample()
    {
        TheEditorWindow wnd = GetWindow<TheEditorWindow>();
        wnd.titleContent = new GUIContent("TheEditorWindow");
    }

    public TextField shipSpeedField;
    public TextField asteroidSpeedField;
    public TextField asteroidHitPointsField;
    public TextField shipHitPointsField;

    public Entity entityAsteroid;
    public Entity entitySpaceship;

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/TheEditorWindow.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        ///////////////////////////////////////////////

        VisualElement shipSpeedLabel = new Label("Ship Speed:");
        root.Add(shipSpeedLabel);
        shipSpeedField = new TextField();
        root.Add(shipSpeedField);

        VisualElement asteroidSpeedLabel = new Label("Asteroid Speed:");
        root.Add(asteroidSpeedLabel);
        asteroidSpeedField = new TextField();
        root.Add(asteroidSpeedField);

        VisualElement asteroidHitPointsLabel = new Label("Asteroid HP:");
        root.Add(asteroidHitPointsLabel);
        asteroidHitPointsField = new TextField();
        root.Add(asteroidHitPointsField);

        VisualElement shipHitPointsLabel = new Label("Ship HP:");
        root.Add(shipHitPointsLabel);
        shipHitPointsField = new TextField();
        root.Add(shipHitPointsField);

        ///////
        Button destroyAsteroidsButton = new Button(DestroyAsteroids);
        Button RefreshButton = new Button(Refresh);
        destroyAsteroidsButton.text = "Destroy All Asteroids";
        RefreshButton.text = "REFRESH & UPDATE";
        root.Add(destroyAsteroidsButton);
        root.Add(RefreshButton);

        shipSpeedField.value = entitySpaceship.speed.ToString();
        asteroidSpeedField.value = entityAsteroid.speed.ToString();
        asteroidHitPointsField.value = entityAsteroid.hitPoints.ToString();
        shipHitPointsField.value = entitySpaceship.hitPoints.ToString();
    }


    public void DestroyAsteroids()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }
    }

    public void Refresh()
    {
        entityAsteroid.speed = float.Parse(asteroidSpeedField.value);
        entitySpaceship.speed = float.Parse(shipSpeedField.value);
        entityAsteroid.hitPoints = int.Parse(asteroidHitPointsField.value);
        entitySpaceship.hitPoints = int.Parse(shipHitPointsField.value);
    }

}