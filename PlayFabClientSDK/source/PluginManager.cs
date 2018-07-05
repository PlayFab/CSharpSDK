using System.Collections.Generic;

namespace PlayFab
{
    public class PluginManager
    {
        private Dictionary<PluginContract, IPlayFabPlugin> plugins = new Dictionary<PluginContract, IPlayFabPlugin>();

        /// <summary>
        /// The singleton instance of plugin manager.
        /// </summary>
        public static PluginManager Instance { get; private set; } = new PluginManager();

        private PluginManager()
        {
        }

        /// <summary>
        /// Gets a plugin.
        /// </summary>
        /// <param name="contract">The app contract of plugin.</param>
        /// <returns>The plugin implementation.</returns>
        public IPlayFabPlugin GetPlugin(PluginContract contract)
        {
            if (!this.plugins.ContainsKey(contract))
            {
                // throw new ArgumentException("Plugin for contract is not set", nameof(contract));
                return null;
            }

            return this.plugins[contract];
        }

        /// <summary>
        /// Sets a custom plugin.
        /// </summary>
        /// <param name="contract">The app contract of a custom plugin.</param>
        /// <param name="plugin">The custom plugin implementation.</param>
        public void SetPlugin(PluginContract contract, IPlayFabPlugin plugin)
        {
            this.plugins[contract] = plugin;
        }
    }
}