using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Lettuce
{
    [Serializable]
    public class Config
    {
        [XmlIgnore]
        public string SettingFilename { get; set; }

        public string LastBinFile { get; set; }

        public Config()
        {
            SettingFilename = "";
        }
    }

    public static class ConfigManager
    {
        public static Config LoadConfig(string file)
        {
            FileStream stream = null;

            try
            {
                if(!File.Exists(file))
                    return new Config();

                stream = File.OpenRead(file);
                var ser = new XmlSerializer(typeof (Config));
                var config = (Config)ser.Deserialize(stream);
            }
            catch
            {
            }
            finally
            {
                if(stream != null)
                    stream.Close();
            }
            
            return new Config();
        }

        public static bool SaveConfig(string file, Config config)
        {
            FileStream stream = null;

            try
            {
                var ser = new XmlSerializer(typeof (Config));
                stream = File.OpenWrite(file);
                ser.Serialize(stream, config);
                return true;
            }
            catch
            {
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }
    }
}
