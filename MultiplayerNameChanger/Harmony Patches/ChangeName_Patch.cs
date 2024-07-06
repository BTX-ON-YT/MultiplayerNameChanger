using System.Reflection;

using BS_Utils.Utilities;

using HarmonyLib;
using IPA.Utilities;
using MultiplayerNameChanger.Configuration;


namespace MultiplayerNameChanger.HarmonyPatches {


    [HarmonyPatch]
    public class ChangeName_Patch {

        public static ConstructorInfo TargetMethod() {
            return typeof(UserInfo).GetConstructors()[0];
        }

        public static void Postfix(UserInfo __instance) {
            if (PluginConfig.Instance.UseValue && PluginConfig.Instance.NameValue != null && PluginConfig.Instance.NameValue?.Length > 0) {
                string finalName;
                if (PluginConfig.Instance.ClanValue != null && PluginConfig.Instance.ClanValue.Length > 0) {
                    finalName = "[" + PluginConfig.Instance.ClanValue + "] " + PluginConfig.Instance.NameValue;
                }
                else {
                    finalName = PluginConfig.Instance.NameValue;
                }
                __instance.SetField("userName", finalName);
                Plugin.Log.Log(IPA.Logging.Logger.Level.Info, "Username patched to: " + __instance.userName);
            }
        }
    }
}
