# [By Design] Unity-Bug-Report-Animation-IN-42068

**Unity has stated that this was intentional by design.**

> The “Player“ GameObject continues to fall down because the Gravity Weight curve is not set to 0. According to the developers, the animation curve can not be changed through the script with PropertyStreamHandle. It is best to set the curve to zero manually (through the Inspector window).

## About this issue

Modifying the "GravityWeight" curve using `PropertyStreamHandle` does not actually affect the gravity being applied to the character.

## How to reproduce

1. Open the "SampleScene".
2. Enter Play Mode.
3. Observer the "Player" object in the Game view or Scene view.

Expected result: The player is not affected by gravity(dose not fall).

Actual result: The player falls.
