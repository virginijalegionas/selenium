namespace SeleniumTests;

[TestClass]
public class FormsTests : TestBase
{
    [TestInitialize]

    public void AutoStartDriver()
    {
        StartDriver();
        OpenUrl();
    }

    [TestMethod]
    public void PracticeForms()
    {
        PracticeForms practiceForms = new PracticeForms(driver);
        practiceForms.MainPageMenu.ClickOnBlock("Forms");
        practiceForms.LeftPanel.ClickOnSubMenu("Practice Form");

        //Input test values for the form
        string firstName = $"first {Common.GenerateRandom()}";
        practiceForms.InputFirstName(firstName);
        string lastName = $"last {Common.GenerateRandom()}";
        practiceForms.InputLastName(lastName);
        string email = $"mail{Common.GenerateRandom()}@email.com";
        practiceForms.InputEmail(email);
        practiceForms.SelectGender("Female");
        string mobileNumber = "3334556667";
        practiceForms.InputMobile(mobileNumber);
        DateOnly birthDate = new DateOnly(2004, 03, 13);
        practiceForms.SelectDateOfBirth(birthDate);
        practiceForms.SelectSubjects("Maths");
        practiceForms.SelectSubjects("Arts");
        practiceForms.SelectHobby("Sports");
        practiceForms.SelectHobby("Reading");
        practiceForms.UploadFile("TestUpload.txt");
        string currentAddress = $"current address {Common.GenerateRandom()}";
        practiceForms.InputCurrentAddress(currentAddress);
        practiceForms.SelectState("NCR");
        practiceForms.SelectCity("Noida");
        practiceForms.ClickSubmit();

        Dictionary<string, string> setValues = practiceForms.GetSubmitValues();
        practiceForms.ClickClose();
        //Validating values
        Assert.AreEqual($"{firstName} {lastName}", setValues["Student Name"], $"Expected Student Name value to be: {firstName} {lastName}");
        Assert.AreEqual(email, setValues["Student Email"], $"Expected Student Email value to be: {email}");
        Assert.AreEqual("Female", setValues["Gender"], $"Expected Gender value to be: 'Female'");
        Assert.AreEqual(mobileNumber, setValues["Mobile"], $"Expected Mobile value to be: {mobileNumber}");
        Assert.AreEqual(birthDate.ToString("dd MMMM,yyyy"), setValues["Date of Birth"], $"Expected Date of Birth value to be: '13 March,2004'");
        Assert.AreEqual("Maths, Arts", setValues["Subjects"], $"Expected Subjects value to be: Maths, Arts");
        Assert.AreEqual("Sports, Reading", setValues["Hobbies"], $"Expected Hobbies value to be: Sports, Reading");
        Assert.AreEqual("TestUpload.txt", setValues["Picture"], $"Expected Picture value to be: TestUpload.txt");
        Assert.AreEqual(currentAddress, setValues["Address"], $"Expected Address value to be: {currentAddress}");
        Assert.AreEqual("NCR Noida", setValues["State and City"], $"Expected Permanant Address value to be: NCR Noida");
    }
}