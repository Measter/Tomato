using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lettuce
{
    public class INIFile
    {
        private List<INILine> _lines;

        public string this[string section, string key]
        {
            get
            {
                var line = _lines.FirstOrDefault(l => l.Section == section && l.Key == key);
                if (line == null)
                    return null;
                return line.Value;
            }
            set
            {
                int lastSecKey = -1;
                for (int i = 0; i < _lines.Count; i++)
                {
                    if (_lines[i].Section == section)
                    {
                        lastSecKey = i;
                        if (_lines[i].Key == key)
                        {
                            _lines[i].Value = value;
                            return;
                        }
                    }
                }

                var line = new INILine(section, key, value, null);
                if (lastSecKey != -1 && lastSecKey + 1 != _lines.Count)
                    _lines.Insert(lastSecKey + 1, line);
                else
                {
                    _lines.Add(new INILine(null, null, null, null));    // empty line
                    _lines.Add(new INILine(section, null, null, null)); // [foo]
                    _lines.Add(line);                                   // key=value
                }
            }
        }

        public KeyValuePair<string, string>[] GetValuesInSection(string section)
        {
            var values = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < _lines.Count; i++)
            {
                if(_lines[i].Section == section && _lines[i].Key != null)
                    values.Add(new KeyValuePair<string, string>(_lines[i].Key, _lines[i].Value));
            }
            return values.ToArray();
        }

        #region Read/Write
        public static INIFile Read(string file)
        {
            string [] rawLines = new string[0];
            try
            {
                rawLines = File.ReadAllLines(file);
            }
            catch
            {
            }
            var lines = new List<INILine>();

            string currentSection = "";

            foreach (var rawLine in rawLines)
            {
                var line = rawLine.TrimEnd();
                if (line.Length == 0)
                {
                    // empty line
                    lines.Add(new INILine(null, null, null, null));
                    continue;
                }
                string comment = null;

                if (line[0] == ';') // ; asdasd
                {
                    lines.Add(new INILine(null, null, null, line.Substring(1)));
                    continue;
                }
                if (line.Contains(';')) // comment at the end?
                {
                    var parts = line.Split(new[] { ';' }, 2);
                    line = parts[0].Trim();
                    comment = parts[1];
                }

                if (line[0] == '[') // [asd]    or    [asd] ; foo
                {
                    currentSection = line.Substring(1, line.Length - 2);
                    lines.Add(new INILine(currentSection, null, null, comment));
                }
                else // key=value      or      key=value ; foo
                {
                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length != 2)
                        continue;
                    lines.Add(new INILine(currentSection, parts[0], parts[1], comment));
                }
            }

            var iniFile = new INIFile();
            iniFile._lines = lines;
            return iniFile;
        }

        public static bool Write(string path, INIFile iniFile)
        {
            StreamWriter stream = null;
            try
            {
                stream = new StreamWriter(File.OpenWrite(path));

                foreach (var line in iniFile._lines)
                {
                    stream.WriteLine(line.ToString());
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }
        #endregion
    }

    public class INILine
    {
        public string Section;
        public string Key;
        public string Value;
        public string Comment;

        public INILine(string section, string key, string value, string comment)
        {
            Section = section;
            Key = key;
            Value = value;
            Comment = comment;
        }

        public override string ToString()
        {
            var retn = "";

            if (Value == null && Section != null)
                retn = "[" + Section + "]";
            else if (Key != null)
                retn = Key + "=" + Value;

            if (Comment != null)
                retn += (retn.Length != 0 ? " " : "") + ";" + Comment;

            return retn;
        }
    }
}
