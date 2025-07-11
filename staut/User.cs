using System;
using System.Collections.Generic;

namespace Staut {
    public class User {
        int id;
        String username;
        String password;
        String name;
        String email;
        double balance;
        Library library;
        String description;
        Status status;
        Cart cart;
        int gems;

        bool addBalance(double value) {
            //implementation
            return true;
        }

        double checkBalance() {
            //implementation
            return 0.0;
        }

        List<Game> checkGames() {
            //implementation
            return null;
        }

        //checkItems
        //checkItemsOfGame
        //changeName
        //changeDescription
        //changeEmail
        //changePassword
        //changeStatus
        //changeCart
    }

    public enum Status {
        Online,
        Offline,
        Away,
        Busy,
        Invisible,
        DoNotDisturb
    }

}