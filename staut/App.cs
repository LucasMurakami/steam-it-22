namespace Staut;

public class App {
    public static void Main(string[] args) {
        User user = new User(
            username: "sharkboy99",
            password: "senha123",
            fullName: "Henrique Schultz",
            email: "henrique@devmail.com",
            description: "Fullstack-focused developer 🧠🔥",
            status: Status.Online
        );

        user.Cart.ShowCart();
        user.Cart.Purchase();
    }
}