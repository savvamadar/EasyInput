# EasyInput
An input system for unity because I hate the new input system.

Supports multiple local players out of the box.

Remember to Edit > Project Settings > Script Execution Order
and add EasyInput - make sure that it is above "Default Time"

Any script that touches any of the "SetInput" methods should go above "Default Time" but below "EasyInput"


Features:
- Checking Input Press
- Checking Input Held
- Checking Input Time Held
- Checking Input Released
- Multiple Local Player Support
- Input Controller Swapping via Script


Example Lazy Usage:
- Create Object and add EasyInput component
- Look at [KeyboardInputLazy.cs](https://github.com/savvamadar/EasyInput/blob/main/Assets/Demo/LazyInput/KeyboardInputLazy.cs)
- Look at [PlayerMovementLazy.cs](https://github.com/savvamadar/EasyInput/blob/main/Assets/Demo/LazyInput/PlayerMovementLazy.cs)


Example Multiplayer Usage:
- Create Object and add EasyInput component
- Look at [KeyboardInput.cs](https://github.com/savvamadar/EasyInput/blob/main/Assets/Demo/Input/KeyboardInput.cs)
- Look at [PlayerMovement.cs](https://github.com/savvamadar/EasyInput/blob/main/Assets/Demo/Input/PlayerMovement.cs)

Example Controller Usage:
- Create Object and add EasyInput component
- Look at [ControllerInput.cs](https://github.com/savvamadar/EasyInput/blob/main/Assets/Demo/Input/ControllerInput.cs)
- Look at [PlayerMovement.cs](https://github.com/savvamadar/EasyInput/blob/main/Assets/Demo/Input/PlayerMovement.cs)
