using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Basic;

public static class InputManager
{
	private static KeyboardState _currentKeyboard;
	private static KeyboardState _lastKeyboard;

	private static MouseState _currentMouseState;
	private static MouseState _lastMouseState;

	// Keyboard Methods
	public static bool KeyPressed(Keys key) => _currentKeyboard.IsKeyDown(key) && _lastKeyboard.IsKeyUp(key);
	public static bool KeyDown(Keys key) => _currentKeyboard.IsKeyDown(key);


	// Mouse Methods
	/// <summary>
	/// Method to see if the wheel was scrolled up in this frame.
	/// </summary>
	/// <returns></returns>
	public static bool WheelUp => _currentMouseState.ScrollWheelValue > _lastMouseState.ScrollWheelValue;
	/// <summary>
	/// Method to see if the wheel was scrolled down in this frame.
	/// </summary>
	/// <returns></returns>
	public static bool WheelDown => _currentMouseState.ScrollWheelValue < _lastMouseState.ScrollWheelValue;

	public static bool LeftMousePressed => _lastMouseState.LeftButton == ButtonState.Released && _currentMouseState.LeftButton == ButtonState.Pressed;
	public static bool RightMousePressed => _lastMouseState.RightButton == ButtonState.Released && _currentMouseState.RightButton == ButtonState.Pressed;

	public static bool LeftMouseDown => _currentMouseState.LeftButton == ButtonState.Pressed;
	public static bool RightMouseDown => _currentMouseState.RightButton == ButtonState.Pressed;

	public static Point MousePosition => _currentMouseState.Position;

	public static void Update()
	{
		_lastKeyboard = _currentKeyboard;
		_currentKeyboard = Keyboard.GetState();

		_lastMouseState = _currentMouseState;
		_currentMouseState = Mouse.GetState();
	}
}
