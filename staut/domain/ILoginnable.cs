namespace Staut;

public interface ILoginnable {
    bool Login(string passwordAttempt, string usernameAttempt);
}