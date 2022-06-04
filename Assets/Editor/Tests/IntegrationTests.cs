using NUnit.Framework;
using Altom.AltUnityDriver;

public class IntegrationTests
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver =new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void TestFindShareButtonObject()
    {
    	//Here you can write the test
        var altUnityObjectShareBtn = altUnityDriver.FindObject(By.NAME, "Button_Share");
        altUnityDriver.Click(altUnityObjectShareBtn.getScreenPosition());
        Assert.NotNull(altUnityObjectShareBtn);
    }

}