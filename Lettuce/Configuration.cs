using System;
using System.Collections.Generic;
using System.Drawing;
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

	    public Dictionary<string, Point> WindowPositions;
	    public Dictionary<string, Size> WindowSizes;

	    public Configuration()
        {
            Keybindings = new Dictionary<string, Tuple<Keys, Keys>>();
			WindowPositions = new Dictionary<string, Point>();
			WindowSizes = new Dictionary<string, Size>();
        }
    }

    public static class ConfigurationManager
    {
        public static bool SaveConfiguration(Configuration config, string path)
        {
	        foreach ( var bind in config.Keybindings )
		        config._iniFile["keys", bind.Key] = bind.Value.Item1 + "," + bind.Value.Item2;
	        foreach ( var bind in config.WindowPositions )
		        config._iniFile["positions", bind.Key] = bind.Value.X + "," + bind.Value.Y;
	        foreach ( var bind in config.WindowSizes )
		        config._iniFile["sizes", bind.Key] = bind.Value.Width + "," + bind.Value.Height;

	        return INIFile.Write(path, config._iniFile);
        }

        public static Configuration LoadConfiguration(string path)
        {
            var config = new Configuration();
            config._iniFile = INIFile.Read(path);

            var bindings = config._iniFile.GetValuesInSection("keys");
            foreach (var kvp in bindings)
            {
                var func = kvp.Key;
                var rawKey = kvp.Value.Split(',');
                var key1 = (Keys) Enum.Parse(typeof(Keys), rawKey[0]);
                var key2 = (Keys) Enum.Parse(typeof(Keys), rawKey[1]);

                config.Keybindings.Add(func, Tuple.Create(key1, key2));
            }
	        bindings = config._iniFile.GetValuesInSection( "positions" );
	        foreach ( var kvp in bindings )
	        {
		        var window = kvp.Key;
		        var rawPos = kvp.Value.Split( ',' );
		        var x = Int32.Parse( rawPos[0] );
		        var y = Int32.Parse( rawPos[1] );
		        config.WindowPositions.Add( window, new Point( x, y ) );
	        }
			bindings = config._iniFile.GetValuesInSection( "sizes" );
			foreach( var kvp in bindings )
			{
				var window = kvp.Key;
				var rawPos = kvp.Value.Split( ',' );
				var x = Int32.Parse( rawPos[0] );
				var y = Int32.Parse( rawPos[1] );
				config.WindowSizes.Add( window, new Size(x, y) );
			}
            return config;
        }
    }
}
