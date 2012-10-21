using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lettuce.Config
{
    public class Configuration
    {
        internal INIFile _iniFile;

        //              function        Key    Mod
        public Dictionary<string, Tuple<Keys, Keys>> Keybindings;

        public Configuration()
        {
            Keybindings = new Dictionary<string, Tuple<Keys, Keys>>();
        }
    }

    public static class ConfigurationManager
    {
        public static bool SaveConfiguration(Configuration config, string path)
        {
            foreach (var bind in config.Keybindings)
            {
                config._iniFile["keys", bind.Key] = bind.Value.Item1 + ";" + bind.Value.Item2;
            }
            return INIFile.Write(path, config._iniFile);
        }

        public static Configuration LoadConfiguration(string path)
        {
            var config = new Configuration();
            config._iniFile = INIFile.Read(path);

            var keyBindings = config._iniFile.GetValuesInSection("keys");
            foreach (var kvp in keyBindings)
            {
                var func = kvp.Key;
                var rawKey = kvp.Value.Split(';');
                var key1 = (Keys) Enum.Parse(typeof(Keys), rawKey[0]);
                var key2 = (Keys) Enum.Parse(typeof(Keys), rawKey[1]);

                config.Keybindings.Add(func, Tuple.Create(key1, key2));
            }
            return config;
        }
    }
}
