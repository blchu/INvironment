using UnityEngine;
using Leap;
using System.Collections;

public class KeyInteraction : MonoBehaviour
{
    private Controller controller;
    private float cooldown;
    public enum RotationState {left, right, up, down, stay};
    public static RotationState state;

    // Use this for initialization
    void Start()
    {
        state = RotationState.stay;
        controller = new Controller();
        controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
        controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
        controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f);
        controller.Config.Save();
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (state == RotationState.right)
                foreach (Transform child in transform)
                    child.RotateAround(Vector3.zero, Vector3.up, 288 * Time.deltaTime);
            else if (state == RotationState.left)
                foreach (Transform child in transform)
                    child.RotateAround(Vector3.zero, Vector3.up, -288 * Time.deltaTime);
        }
        else
        {
            state = RotationState.stay;
            Frame frame = controller.Frame();
            GestureList gestures = frame.Gestures();
            for (int i = 0; i < gestures.Count; i++)
            {
                Gesture gesture = gestures[i];
                if (gesture.Type == Gesture.GestureType.TYPESWIPE)
                {
                    SwipeGesture swipe = new SwipeGesture(gesture);
                    Vector dir = swipe.Direction;
                    if (dir.y < -Mathf.Abs(dir.x) && !Selection.inSelection)
                        Selection.Select();
                    else if (dir.y > Mathf.Abs(dir.x))
                        Selection.Unselect();
                    else if (dir.x < 0 && !Selection.inSelection)
                        state = RotationState.right;
                    else if (!Selection.inSelection)
                        state = RotationState.left;
                    cooldown = 15 * Time.deltaTime;
                }
            }
        }

    }


}