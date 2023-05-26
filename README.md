# Unity-Bug-Report-Animation-IN-42068

## About this issue

Modifying the "GravityWeight" curve using `PropertyStreamHandle` does not actually affect the gravity being applied to the character.

## How to reproduce

1. Open the "SampleScene".
2. Enter Play Mode.
3. Observer the "Player" object in the Game view or Scene view.

Expected result: The player is not affected by gravity(dose not fall).

Actual result: The player falls.
