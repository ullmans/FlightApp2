using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1 {
    interface IFileReadModel {
        public void ReadDataFile(string filePath);  //done

        public List<double[]> GetDataLog(); //done

        public delegate void UseDataLog(object sender);
        public event UseDataLog DataReadFinished;   //used

        public void ReadDefinitionFile(string filePath);    //done

        public double GetSampleRate();
        public List<string> GetDefinitions();   //done

        public delegate void UseDefinitions(object sender);
        public event UseDefinitions DefinitionReadFinished;
    }
}
