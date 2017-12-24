using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using ZeroConfigServiceSettings;

namespace DynamicRepo.Business.Parsers
{
    public class HandleBarParser
    {
        //TODO: Leverage Concurrent Dictionary
        private static Regex _handelbarPattern = new Regex(@"{{([^{}]+)}}");
        private readonly IConfigurationSettings _configurationSettings;

        public HandleBarParser(IConfigurationSettings configurationSettings, Dictionary<string, string> dictionary)
        {
            this._configurationSettings = configurationSettings;
            this._variablePool = dictionary;
        }
        public HandleBarParser(IConfigurationSettings configurationSettings)
        {
            this._configurationSettings = configurationSettings;
            this._variablePool = new Dictionary<string, string>(); 
        }

        static HandleBarParser()
        {
            GlobalVariablePool = new Dictionary<string, string>();
        }

       

        public static Dictionary<string, string> GlobalVariablePool { get; set; }
        public Dictionary<string, string> _variablePool { get; set; }

        public static MatchCollection GetHandleBarVariables(string inputStr)
        {
            return _handelbarPattern.Matches(inputStr);
        }

        public static void UpsertGlobalVariablePool(Dictionary<string, string> globalVariablesCollection)
        {
            foreach (var item in globalVariablesCollection)
            {
                UpsertGlobalVariablePool(item.Key, item.Value);
            }
        }

        public static void UpsertGlobalVariablePool(string key, string value)
        {
            UpsertDictionary("{{" + key + "}}", value, GlobalVariablePool);
        }

        public string ProcessInputString(string value)
        {
            string result = value;
            if (!string.IsNullOrEmpty(result))
            {
                var matches = _handelbarPattern.Matches(result);
                do
                {
                    foreach (var item in matches)
                    {
                        string replaceVar = string.Empty;
                        string key = item.ToString();

                        if (key.Replace(" ", "").StartsWith("{{$", StringComparison.Ordinal))
                        {
                            replaceVar = GetPreDefValues(key: key.Replace(" ", ""));
                        }
                        if (!string.IsNullOrEmpty(_configurationSettings[key]))
                        {
                            replaceVar = _configurationSettings[key];
                        }
                        if (GlobalVariablePool.ContainsKey(key))
                        {
                            replaceVar = GlobalVariablePool[key];
                        }
                        if (_variablePool.ContainsKey(key))
                            replaceVar = _variablePool[key];

                        result = result.Replace(key, replaceVar);
                    }
                    matches = _handelbarPattern.Matches(result);
                } while (matches.Count > 0);
            }
            return result;
        }

        public Dictionary<string, string> ProcessInputString(Dictionary<string, string> headers)
        {
            var tempDictionary = new Dictionary<string, string>();
            foreach (var item in headers)
            {
                tempDictionary.Add(item.Key, ProcessInputString(item.Value));
            }
            return tempDictionary;
        }

        public string[] ProcessInputString(string[] expectedResponse)
        {
            var tempStrList = new List<string>();
            foreach (var item in expectedResponse)
            {
                tempStrList.Add(ProcessInputString(item));
            }
            return tempStrList.ToArray();
        }

        internal void UpsertLocalVariable(string key, string value)
        {
            //TODO: Handle CircularReference if value is as handler
            UpsertDictionary("{{" + key + "}}", value, _variablePool);
        }

        private static void UpsertDictionary(string key, string value, Dictionary<string, string> dictionary)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        private string GetPreDefValues(string key)
        {
            switch (key)
            {
                case "{{$guid}}": return Guid.NewGuid().ToString();
                case "{{$time}}": return DateTime.Now.ToShortTimeString();
                case "{{$date}}": return DateTime.Now.ToShortDateString();
                case "{{$rand}}": return new Random().NextDouble().ToString();
                default: return string.Empty;
            }
        }
    }
}