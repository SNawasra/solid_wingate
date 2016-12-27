using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NLog;
using wingateCSharp;
using Xunit;
using wingateCSharp.Interfaces;

namespace WinGate.Test
{
    public class WingateImporterTests
    {
        [Fact]
        public void ImportWingateFileReaderIsCalledOnce()
        {
            //arrange 
            var IReaderMock = new Mock<FileReader>();
            var validators = new List<IValidator>();
            var iecon = new Mock<wingateCSharp.EConnct.IEConnect.taPmTransaction>();
            var loggerMock = new Mock<ILogger>();
            var trySplitRes = new List<wingateSchema>();
            IReaderMock.Setup(x => x.TrySplit(out trySplitRes)).Returns(true);
            
            var sut = new WingateImporter(IReaderMock.Object, validators, iecon.Object, loggerMock.Object);

            //Act 
            sut.ImportWingate();

            //Assert
            IReaderMock.Verify(x => x.TrySplit(out trySplitRes), Times.Once);

        }
    }
}
