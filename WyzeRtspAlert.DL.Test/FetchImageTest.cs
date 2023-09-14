using WyzeRtspAlert.DL.Interface;

namespace WyzeRtspAlert.DL.Test
{
    public class FetchImageTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FetchImageTest_Success()
        {
            IFetchImage fetchImage = new FetchImage();

            var address = "192.168.1.247";
            var userName = "Wyze";
            var password = "MavieAnnie";

            fetchImage.Fetch(address, userName, password);
            Assert.Pass();
        }
    }
}