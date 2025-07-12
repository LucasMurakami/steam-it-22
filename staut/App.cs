namespace Staut;

public class App {
    public static void Main(string[] args) {
        User user = new User(
            username: "sharkboy99",
            password: "senha123",
            name: "Henrique Schultz",
            email: "henrique@devmail.com",
            description: "Fullstack-focused developer 🧠🔥",
            status: Status.Online
        );

        user.CheckCart.ShowCart();
        user.CheckCart.Purchase();
    }
}