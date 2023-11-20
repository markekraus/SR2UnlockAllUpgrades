using System.Linq;
using Il2Cpp;
using Il2CppAssets.Script.Util.Extensions;
using Il2CppMonomiPark.SlimeRancher.DataModel;
using Il2CppMonomiPark.World;
using MelonLoader;
using UnityEngine;

namespace UnlockAllUpgrades
{
    internal class Entry : MelonMod
    {
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            if (sceneName != "LoadScene")
                return;

            var upgradeModel = Resources.FindObjectsOfTypeAll<PlayerState>()
                .FirstOrDefault(x => x.name == "SceneContext")._model.upgradeModel;
            foreach (var upgrade in upgradeModel.upgradeDefinitions.items)
            {
                while (upgradeModel.IncrementUpgradeLevel(upgrade))
                    continue;
            }
        }
    }
}
