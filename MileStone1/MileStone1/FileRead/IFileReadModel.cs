using System;
using System.Collections.Generic;
using System.Text;
using MileStone1;

namespace MileStone1 {
    interface IFileReadModel {

        public void ReadFile(string filePath, FileType fileType);  //done

        public List<double[]> GetDataLog(); //done
        public double GetSampleRate();  //waht is that func??
        public List<string> GetDefinitions();   //done

        public delegate void UseResult(Object sender, FileType fileType);
        public event UseResult FileReadFinished;
    }
}
