using System;
using HarmonyLib;
using UnityEngine;

namespace PeakForgivingFalls;

// [HarmonyPatch(typeof(CharacterMovement), "FixedUpdate")]
// public class CharacterMovementAwake
// {
//     // Compute the velocity based on the position diff
//     public static void Prefix(CharacterMovement __instance)
//     {
//         var character = __instance.GetType()
//             .GetField("character", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
//             ?.GetValue(__instance);
//         if (character == null)
//         {
//             Debug.LogError("Character data is null.");
//             return;
//         }
//
//         var characterData = character.GetType()
//             .GetField("data", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
//             ?.GetValue(character);
//         if (characterData == null)
//         {
//             Debug.LogError("Character data field is null.");
//             return;
//         }
//
//         var isClimbing = characterData.GetType().GetField("isClimbing",
//             System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
//         if (isClimbing == null)
//         {
//             Debug.LogError("isClimbing field is null.");
//             return;
//         }
//
//         var sinceGrounded = characterData.GetType().GetField("sinceGrounded",
//             System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
//         if (sinceGrounded == null)
//         {
//             Debug.LogError("sinceGrounded field is null.");
//             return;
//         }
//
//         var isClimbingValue = (bool) isClimbing.GetValue(characterData);
//         if (isClimbingValue)
//         {
//             sinceGrounded.SetValue(characterData, 0f);
//         }
//     }
// }

[HarmonyPatch(typeof(CharacterClimbing), "StartClimbRpc")]
public class CharacterClimbing_StartClimbRpc
{
    public static void Postfix(CharacterClimbing __instance)
    {
         var character = __instance.GetType()
             .GetField("character", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
             ?.GetValue(__instance);
         if (character == null)
         {
             Debug.LogError("Character data is null.");
             return;
         }

         var characterData = character.GetType()
             .GetField("data", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
             ?.GetValue(character);
         if (characterData == null)
         {
             Debug.LogError("Character data field is null.");
             return;
         }
         
         var sinceGrounded = characterData.GetType().GetField("sinceGrounded",
             System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
         if (sinceGrounded == null)
         {
             Debug.LogError("sinceGrounded field is null.");
             return;
         }
         
         var outOfStaminaFor = characterData.GetType()
             .GetField("outOfStaminaFor", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
         if (outOfStaminaFor == null)
         {
             Debug.LogError("outOfStaminaFor field is null.");
             return;
         }


         var playerSlide = __instance.GetType()
             .GetField("playerSlide",
                 System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         if (playerSlide == null)
         {
             Debug.LogError("playerSlide field is null.");
             return;
         }
        
         var outOfStaminaMethod = character.GetType()
             .GetMethod("OutOfStamina", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         
         var playerOutOfStamina = (bool) outOfStaminaMethod.Invoke(character, null);
         if (playerOutOfStamina)
         {
             playerSlide.SetValue(__instance, Vector2.down * 5f);
             outOfStaminaFor.SetValue(characterData, 0.5f);
         }
    }
}