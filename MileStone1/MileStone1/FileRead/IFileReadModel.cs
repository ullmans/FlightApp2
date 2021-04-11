using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1 {
    interface IFileReadModel {
        public void ReadDataFile(string FilePath);

        public double[][] GetDataLog();

        public delegate void UseDataLog();
        public event UseDataLog DataReadFinished;

        public void ReadDefinitionFile(string FilePath);

        public double GetSampleRate();
        public double[] GetDefinitions();

        public delegate void UseDefinitions();
        public event UseDefinitions DefinitionReadFinished;
    }
}
