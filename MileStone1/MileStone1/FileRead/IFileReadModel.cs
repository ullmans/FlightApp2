using System;
using System.Collections.Generic;
using System.Text;
using MileStone1;

namespace MileStone1 {
    interface IFileReadModel {

        public void ReadFile(string filePath, FileType fileType);  //done

        public List<double[]> GetDataLog(); //done
        public double GetSampleRate();
        public List<string> GetDefinitions();   //done

        public delegate void UseResult(object sender, FileType fileType);
        public event UseResult FileReadFinished;
    }
}
