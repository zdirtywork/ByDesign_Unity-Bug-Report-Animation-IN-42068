using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

// About this issue:
// Modifying the GravityWeight curve using PropertyStreamHandle
// does not actually affect the gravity being applied to the character.
// 
// How to reproduce:
// 1. Open the "SampleScene".
// 2. Enter Play Mode.
// 3. Observer the "Player" object in the Game view or Scene view.
// Expected result: The player is not affected by gravity(dose not fall).
// Actual result: The player falls.

public struct PropertyJob : IAnimationJob
{
    public PropertyStreamHandle propertyHandle;

    public void ProcessAnimation(AnimationStream stream)
    {
        // Force set the value to 0.
        propertyHandle.SetFloat(stream, 0);
    }

    public void ProcessRootMotion(AnimationStream stream)
    {
    }
}

[RequireComponent(typeof(Animator))]
public class PropertyHandleTest : MonoBehaviour
{
    public AnimationClip clip;

    private PlayableGraph _graph;

    private void Start()
    {
        var animator = GetComponent<Animator>();

        _graph = PlayableGraph.Create("PropertyHandleDemo");

        var acp = AnimationClipPlayable.Create(_graph, clip);

        var jobData = new PropertyJob
        {
            // Bind to the "GravityWeight" curve
            propertyHandle = animator.BindStreamProperty(transform, typeof(Animator), "GravityWeight"),
        };
        var asp = AnimationScriptPlayable.Create(_graph, jobData);
        asp.AddInput(acp, 0, 1f);

        var output = AnimationPlayableOutput.Create(_graph, "Animation", animator);
        output.SetSourcePlayable(asp);

        _graph.Play();
    }

    private void OnDestroy()
    {
        if (_graph.IsValid()) _graph.Destroy();
    }
}
