using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordMatch {
    /// <summary>
    /// Goal: Look at two files and return tokens they have in common
    /// </summary>
    class Program {
        static void Main(string[] args) {

            const string OUTPUT_FILENAME = "SharedTokens.txt";
            var outputFilePath = Path.Combine(Environment.CurrentDirectory, OUTPUT_FILENAME);

            char[] xmlSeperators = { ' ', '<', '/', '>', '"', '[' };
            var splitFlags = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
            var responseXMLTokens = FileStore.Resource.XMLResponse.Split(xmlSeperators, splitFlags);
            var backwardsXMLTokens = FileStore.Resource.bwdService.Split(xmlSeperators, splitFlags);

            IEnumerable<string> query = from sharedTokens in responseXMLTokens.Intersect(backwardsXMLTokens)
                                        select sharedTokens;

            using (StreamWriter outputFile = new StreamWriter(outputFilePath)) { 
                foreach (var token in query) {
                    outputFile.WriteLine(token);
                }
            }
        }
    }
}
