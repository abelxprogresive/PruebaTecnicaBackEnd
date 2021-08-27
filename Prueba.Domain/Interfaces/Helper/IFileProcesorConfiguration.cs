using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Domain.Interfaces.Helper {
    public interface IFileProcesorConfiguration {
        string GetInitVector();
        byte[] GetPassPhrase();
        int GetKeysize();
        char GetSeparadorCsv();

    }
}
