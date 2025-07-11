namespace stautTest;
using Staut;

[TestFixture]
public class UserTests
{
    private User _user;

    [SetUp]
    public void Setup()
    {
        _user = new User(
            username: "sharkboy99",
            password: "senha123",
            name: "Henrique Schultz",
            email: "henrique@devmail.com",
            description: "Desenvolvedor focado em ser fullstack 🧠🔥",
            status: Status.Online
        );
    }

    [TestCase(100.0, 50.0, 150.0)]
    [TestCase(100.0, 0.0, 100.0)]
    [TestCase(100.0, -20.0, 100.0)]
    public void Balance_UpdateValue_ValidatesBehavior(double initialBalance, double valueToAdd, double expected)
    {
        _user.Balance = initialBalance;
        _user.Balance = valueToAdd;
        Assert.That(_user.Balance, Is.EqualTo(expected).Within(0.001));
    }
}