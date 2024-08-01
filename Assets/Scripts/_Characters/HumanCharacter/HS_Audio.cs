using System.Collections.Generic;
using UnityEngine;

namespace HumanScript
{
    public class HS_Audio : MonoBehaviour, IHumanScript
    {
        private HumanScriptController humanController;

        #region Audiosources

        [field: SerializeField] public AudioSource FootstepsAudioSource { get; private set; }
        [field: SerializeField] public AudioSource PlayerAudioSource { get; private set; }
        [field: SerializeField] public AudioSource WeaponAudioSource { get; private set; }

        #endregion

        #region Audiosources Footstep System

        // Stores all different footsteps sounds.
        private Dictionary<string, AudioClip[]> footstepAudioDictionary;

        // Will be store the current playing audio sounds.
        private AudioClip[] footstepAudioClips;

        // Delay between footstep sounds.
        private float footstepCounter = 2.15f;
        private float footstepPassedTime;

        #endregion

        public void HS_Start(HumanScriptController controller)
        {
            humanController = controller; 

            footstepAudioDictionary = new(){
                { "TerrainWood", humanController.Defines._fstepAudioWood },
                { "TerrainGrass", humanController.Defines._fstepAudioGrass },
                { "TerrainMetal", humanController.Defines._fstepAudioMetal },
                { "TerrainStairs", humanController.Defines._fstepAudioStairs },
                { "TerrainAsphalt", humanController.Defines._fstepAudioAsphalt },
                { "Untagged", humanController.Defines._fstepAudioRubber }
            };
        }

        public void Update()
        {
            this.AudioFootsteps();
        }

        // Is temporary because i want the real footsteps sounds to trigger from animation...
        private void AudioFootsteps()
        {
            // If player is not walking or is in air, then return.
            if (humanController.HS_Movement.HumanRigidBody.velocity.magnitude <= 0) return;

            // Run delay between footsteps.
            footstepPassedTime += Time.deltaTime * humanController.HS_Movement.HumanRigidBody.velocity.magnitude;

            // Reads the layer value from the ground.
            if (footstepPassedTime >= footstepCounter && Physics.Raycast(humanController.HS_Movement.GroundChecker.position,
                Vector3.down, out RaycastHit hit, 0.5f, humanController.Defines.groundLayer))
            {

                // Finds the corresponding layer value and plays the footstep sound then reset the timer.
                footstepAudioClips = footstepAudioDictionary[hit.collider.tag];
                FootstepsAudioSource.PlayOneShot(footstepAudioClips[Random.Range(0, footstepAudioClips.Length - 1)]);
                FootstepsAudioSource.pitch = Random.Range(0.9f, 1.1f);
                footstepPassedTime = 0f;
            }
        }
    }
}