using System;
using BepInEx;
using HarmonyLib;

namespace FakeID
{
    [BepInPlugin("xenon.fake.id", "Fake ID", "1.0.0")]
    public class Mod : BaseUnityPlugin
    {
        void Awake() => new Harmony("xenon.fake.id").PatchAll();
    }
    
    [HarmonyPatch(typeof(KIDManager))]
    [HarmonyPatch("KidEnabled", MethodType.Getter)]
    internal class IDPatch
    {
        private static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}