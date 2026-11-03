using BepInEx;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Text;

namespace BadTrackerMonke
{
    [BepInPlugin("com.username.badtrackermonke", "BadTrackerMonke", "1.0.0")]
    public class BadTrackerMonke : BaseUnityPlugin
    {
        private const string Alphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random RandomSource = new Random();

        void Awake()
        {
            var harmony = new Harmony("com.username.badtrackermonke");
            harmony.PatchAll();
            
            Logger.LogInfo("BadTrackerMonke has loaded successfully!");
        }

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Home))
            {
                string secureCode = GenerateSecureRoomCode(10);
                Logger.LogInfo($"[BTM] Generated Secure Room Code: {secureCode}");
                Logger.LogInfo("[BTM] Share this code with friends outside of public channels!");
                
            }
        }

        /// <summary>
        /// </summary>
        private string GenerateSecureRoomCode(int length)
        {
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int index = RandomSource.Next(Alphanumeric.Length);
                builder.Append(Alphanumeric[index]);
            }
            return builder.ToString();
        }
    }
}
