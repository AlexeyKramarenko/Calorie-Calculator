using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CalorieCalculator.POCO
{
    public class ResultDocument
    {

        public readonly string _folderPath;
        public readonly string _documentName;

        public ResultDocument(string folderPath, string documentName)
        {
            _folderPath = folderPath;
            _documentName = documentName;
        }

        public void OpenFolderWithCreatedDocument()
        {
            if (Directory.Exists(_folderPath))
            {
                var startInfo = new ProcessStartInfo
                {
                    Arguments = _folderPath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
        }

        public void OpenDocumentWithCalculatedCallories()
        {
            var path = Path.Combine(_folderPath, _documentName);

            new Process
            {
                StartInfo = new ProcessStartInfo(path)
                {
                    UseShellExecute = true
                }
            }.Start();
        }

        public void SaveDocument(string documentBody) =>
            File.WriteAllLinesAsync(_documentName, new List<string>() { documentBody });

    }
}
