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

    public Label asteroidNameLabel;

    public TextField shipSpeedField;
    public TextField asteroidSpeedField;
    public TextField asteroidHitPointsField;
    public TextField shipHitPointsField;

    public Entity entityAsteroid;
    public Entity entitySpaceship;

    public Entity asteroidVariant;

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

        VisualElement shipHitPointsLabel = new Label("Ship HP:");
        root.Add(shipHitPointsLabel);
        shipHitPointsField = new TextField();
        root.Add(shipHitPointsField);

        asteroidNameLabel = new Label("No Asteroid Selected");
        root.Add(asteroidNameLabel);

        VisualElement asteroidSpeedLabel = new Label("Asteroid Speed:");
        root.Add(asteroidSpeedLabel);
        asteroidSpeedField = new TextField();
        root.Add(asteroidSpeedField);

        VisualElement asteroidHitPointsLabel = new Label("Asteroid HP:");
        root.Add(asteroidHitPointsLabel);
        asteroidHitPointsField = new TextField();
        root.Add(asteroidHitPointsField);

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

    void OnGUI()
    {
        Event currentEvent = Event.current;
        if (currentEvent.type == EventType.MouseDown)
        {
            UpdateText();
        }
    }

    public void DestroyAsteroids()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }
    }

    public void UpdateText()
    {
        if (Selection.activeTransform != null)
        {
            if (Selection.activeTransform.gameObject.GetComponent<Asteroid>() != null)
            {
                asteroidVariant = Selection.activeTransform.GetComponent<Asteroid>().entity;

                asteroidNameLabel.text = Selection.activeTransform.GetComponent<Asteroid>().entity.debugName;
                asteroidSpeedField.value = Selection.activeTransform.GetComponent<Asteroid>().entity.speed.ToString();
                asteroidHitPointsField.value = Selection.activeTransform.GetComponent<Asteroid>().entity.hitPoints.ToString();
            }
        }
    }

    public void Refresh()
    {
        if (Selection.activeTransform != null)
        {
            if (Selection.activeTransform.gameObject.GetComponent<Asteroid>() != null)
            {
                Selection.activeTransform.GetComponent<Asteroid>().entity.speed = float.Parse(asteroidSpeedField.value);
                Selection.activeTransform.GetComponent<Asteroid>().entity.hitPoints = int.Parse(shipHitPointsField.value);
                //
            }
        }

        else
        {
            asteroidNameLabel.text = "No Asteroid Selected";
        }

        entitySpaceship.speed = float.Parse(shipSpeedField.value);
        entitySpaceship.hitPoints = int.Parse(shipHitPointsField.value);
    }
}