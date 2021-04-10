﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1 {
    interface IFileReadModel {
        public void ReadFile(string FilePath);

        public int[][] GetDataLog();

        public delegate void UseLog();
        public event UseLog ReadFinished;
    }
}
