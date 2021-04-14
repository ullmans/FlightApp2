using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1 {
    interface IFileReadViewModel {
        string DataFilePath { set; get; }
        string DefinitionsFilePath { set; get; }

        public void ReadFile(FileType fileType);

        public List<double[]> GetDataLog();
        public double GetSampleRate();
        public List<string> GetDefinitions();

        public delegate void UseResult(Object sender, FileType fileType);
        public event UseResult FileReadFinished;
    }
}
