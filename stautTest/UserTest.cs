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
            fullName: "Henrique Schultz",
            email: "henrique@devmail.com",
            description: "Desenvolvedor focado em ser fullstack 🧠🔥",
            status: Status.Online
        );
    }
}