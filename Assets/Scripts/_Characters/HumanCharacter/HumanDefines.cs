using UnityEngine;

namespace HumanScript
{
    [CreateAssetMenu]
    public class HumanDefines : ScriptableObject
    {
        [Header("Character Configuration")]
        public float characterMaxHealth = 200f;
        public float characterMaxSpeed = 5f;

        // ======================================================================================= \\

        [Header("Sound Configuration")]
        public AudioClip[] _fstepAudioRubber = default;
        public AudioClip[] _fstepAudioGrass = default;
        public AudioClip[] _fstepAudioMetal = default;
        public AudioClip[] _fstepAudioWood = default;
        public AudioClip[] _fstepAudioStairs = default;
        public AudioClip[] _fstepAudioAsphalt = default;

        // ======================================================================================= \\

        [Header("Other Configuration")]
        [Tooltip("The max distance the player/AI can interact with objects")]
        public float charInteractionDistance;

        [Tooltip("The layer of the objects the player/AI can interact with.")]
        public LayerMask charInteractionLayer;

        [Tooltip("Sets the layer where the IsGrounded checker will work from.")]
        public LayerMask groundLayer;

        // ======================================================================================= \\

        [Header("AI Configuration")]
        [Tooltip("How many objects the detection script can detect (AI).")]
        public int MaxDetectionArraySize = 1000;

        [Tooltip("Field of view range for detecting targets (AI).")]
        public float detectionFOV_AI;

        [Tooltip("Range within which targets can be detected (AI).")]
        public float detectionRange_AI;

        [Tooltip("Layers that represent the objects that the agent can detect.")]
        public LayerMask detectionTargetLayer;

        [Tooltip("Layers that represent obstructive objects to the detectable objects.")]
        public LayerMask detectionObstructionLayer;

        // ======================================================================================= \\

        [Header("Player Configuration")]
        [Range(0f, 1000f)] public float cameraSensibility = 90f;
        [Range(0f, 180f)] public float maxCameraRotation = 90f;

        public float swayAnimationSmooth = 8f;
        public float swayAnimationMultiplier = 2f;
        public float bobAnimationSmooth = 8f;
        public float bobAnimationFrequency = 10f;
        public float bobAnimationMultiplier = 0.002f;
    }
}