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
            pas: "senha123",
            fullName: "Henrique Schultz",
            email: "henrique@devmail.com",
            description: "",
            status: Status.Online
        );
    }
    
    [TestCase(100.0, 50.0, 150.0)]
    [TestCase(100.0, 0.0, 100.0)]
    [TestCase(100.0, -20.0, 100.0)]
    public void AddBalance_WithValidAndInvalidValues_UpdatesBalanceProperly(double initialBalance, double valueToAdd, double expected)
    {
        _user.AddBalance(initialBalance);

        _user.AddBalance(valueToAdd);
        
        Assert.That(_user.Balance, Is.EqualTo(expected).Within(0.001));
    }

    [TestCase(100.0, 50.0, 50.0)]
    [TestCase(100.0, 0.0, 100.0)]
    [TestCase(100.0, -50.0, 100.0)]
    public void SubtractBalance_WithValidAndInvalidValues_UpdatesBalanceProperly(double initialBalance, double valueToSubtract, double expected)
    {
        _user.AddBalance(initialBalance);

        _user.SubtractBalance(valueToSubtract);
        
        Assert.That(_user.Balance, Is.EqualTo(expected).Within(0.001));
    }
    
    [TestCase(100, 50, 150)]
    [TestCase(100, 0, 100)]
    [TestCase(100, -20, 100)]
    public void AddGems_WithValidAndInvalidValues_UpdatesGemsProperly(int initialGems, int valueToAdd, int expected)
    {
        _user.AddGems(initialGems);

        _user.AddGems(valueToAdd);
        
        Assert.That(_user.Gems, Is.EqualTo(expected));
    }

    [TestCase(100, 50, 50)]
    [TestCase(100, 0, 100)]
    [TestCase(100, -50, 100)]
    public void SubtractGemas_WithValidAndInvalidValues_UpdatesGemsProperly(int initialGems, int valueToSubtract, int expected)
    {
        _user.AddGems(initialGems);

        _user.SubtractGems(valueToSubtract);
        
        Assert.That(_user.Gems, Is.EqualTo(expected));
    }

    [TestCase("Dev focado em backend", "Dev focado em backend")]
    [TestCase("", "")]
    public void updateDescription_WithValidAndInvalidValues_UpdatesDescriptionProperly(string description, string expected)
    {
        _user.UpdateDescription(description);
        Assert.That(_user.Description, Is.EqualTo(expected));
    }

    [TestCase("lucas@devmail.com", "lucas@devmail.com")]
    [TestCase("", "henrique@devmail.com")]
    public void updateEmail_WithValidAndInvalidValues_UpdatesEmailProperly(string email, string expected)
    {
        _user.UpdateEmail(email);
        Assert.That(_user.Email, Is.EqualTo(expected));
    }
 
    [TestCase("Lucas Murakami", "Lucas Murakami")]
    [TestCase("", "Henrique Schultz")]
    public void updateFullName_WithValidAndInvalidValues_UpdatesFullNameProperly(string fullName, string expected)
    {
        _user.UpdateFullName(fullName);
        Assert.That(_user.FullName, Is.EqualTo(expected));
    }
}