using System.ComponentModel;
using Microsoft.Win32;
using System.Collections.Generic;

namespace MileStone1 {
    class FileReadViewModel : IFileReadViewModel {
        private IFileReadModel model;

        public FileReadViewModel(IFileReadModel model) {
            this.model = model;
            this.model.FileReadFinished += UseResult;
        }

        public event IFileReadViewModel.UseResult FileReadFinished;

        private string dataFilePath;
        public string DataFilePath {
            get {
                return dataFilePath;
            }
            set {
                dataFilePath = value;
            }
        }

        private string definitionsFilePath;
        public string DefinitionsFilePath {
            get {
                return definitionsFilePath;
            }
            set {
                definitionsFilePath = value;
            }
        }

        public void ReadFile(FileType fileType) {
            string filePath = null;
            if (fileType == FileType.Data) {
                filePath = DataFilePath;
            } else if (fileType == FileType.Definitions) {
                filePath = DefinitionsFilePath;
            }
            model.ReadFile(filePath, fileType);
        }

        public List<double[]> GetDataLog() {
            return model.GetDataLog();
        }

        public double GetSampleRate() {
            return model.GetSampleRate();
        }

        public List<string> GetDefinitions() {
            return model.GetDefinitions();
        }

        public void UseResult(object sender, FileType fileType) {
            if (sender as IFileReadModel == model && FileReadFinished != null) {
                FileReadFinished(this, fileType);
            }
        }
    }
}