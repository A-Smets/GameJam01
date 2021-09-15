using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerInputs")]
public class PlayerInputs : ScriptableObject
{
    [SerializeField, TitleGroup("Axes")] private string horizontalLeft = "HorizontalLeft";
    public float HorizontalLeft { get { return Input.GetAxis(horizontalLeft); } }

    [SerializeField, TitleGroup("Axes")] private string verticalLeft = "VerticalLeft";
    public float VerticalLeft { get { return Input.GetAxis(verticalLeft); } }

    [SerializeField, TitleGroup("Axes")] private string horizontalRight = "HorizontalRight";
    public float HorizontalRight { get { return Input.GetAxis(horizontalRight); } }

    [SerializeField, TitleGroup("Axes")] private string verticalRight = "VerticalRight";
    public float VerticalRight { get { return Input.GetAxis(verticalRight); } }

    [SerializeField, TitleGroup("Axes")] private string horizontalArrows = "HorizontalArrows";
    public float HorizontalArrows { get { return Input.GetAxis(horizontalArrows); } }

    [SerializeField, TitleGroup("Axes")] private string verticalArrows = "VerticalArrows";
    public float VerticalArrows { get { return Input.GetAxis(verticalArrows); } }

    [SerializeField, TitleGroup("Axes")] private string triggerShared = "TriggerShared";
    public float TriggerShared { get { return Input.GetAxis(triggerShared); } }

    [SerializeField, TitleGroup("Axes")] private string triggerLeft = "TriggerLeft";
    public float TriggerLeft { get { return Input.GetAxis(triggerLeft); } }

    [SerializeField, TitleGroup("Axes")] private string triggerRight = "TriggerRight";
    public float TriggerRight { get { return Input.GetAxis(triggerRight); } }

    [SerializeField, TitleGroup("Buttons")] private string buttonA = "A";
    public bool A { get { return Input.GetButtonDown(buttonA); } }

    [SerializeField, TitleGroup("Buttons")] private string buttonB = "B";
    public bool B { get { return Input.GetButtonDown(buttonB); } }

    [SerializeField, TitleGroup("Buttons")] private string buttonX = "X";
    public bool X { get { return Input.GetButtonDown(buttonX); } }

    [SerializeField, TitleGroup("Buttons")] private string buttonY = "Y";
    public bool Y { get { return Input.GetButtonDown(buttonY); } }

    [SerializeField, TitleGroup("Buttons")] private string buttonLB = "LB";
    public bool LB { get { return Input.GetButtonDown(buttonLB); } }

    [SerializeField, TitleGroup("Buttons")] private string buttonRB = "RB";
    public bool RB { get { return Input.GetButtonDown(buttonRB); } }

    [SerializeField, TitleGroup("Buttons")] private string buttonView = "View";
    public bool View { get { return Input.GetButtonDown(buttonView); } }

    [SerializeField, TitleGroup("Buttons")] private string buttonMenu = "Menu";
    public bool Menu { get { return Input.GetButtonDown(buttonMenu); } }

    [SerializeField, TitleGroup("Buttons")] private string joystickLeft = "JoystickLeft";
    public bool JoystickLeft { get { return Input.GetButtonDown(joystickLeft); } }

    [SerializeField, TitleGroup("Buttons")] private string joystickRight = "JoystickRight";
    public bool JoystickRight { get { return Input.GetButtonDown(joystickRight); } }
}
