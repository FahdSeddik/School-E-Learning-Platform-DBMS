<?php


if (isset($_POST["submit"])){
    
    $name =  $_POST["name"];
    $email = $_POST["email"];
    $username = $_POST["uid"];
    $pwd = $_POST["pwd"];
    $pwdRepeat = $_POST["pwdrepeat"];

    require_once 'dbh.inc.php';
    require_once 'functions.inc.php';

    // Check if empty input 
    if (emptyInputSignup($name,$email,$username,$pwd,$pwdRepeat) !== false) {
        header("location: ../signup.php?error=emptyinput");
        exit();
    }

    // Check validity of Uid
    if (invalidUid($username) !== false) {
        header("location: ../signup.php?error=invaliduid");
        exit();
    }

    // Check validity of email
    if (invalidEmail($email) !== false) {
        header("location: ../signup.php?error=invalidemail");
        exit();
    }

    // Check same pwd
    if (pwdMatch($pwd,$pwdRepeat) !== false) {
        header("location: ../signup.php?error=passwordsdontmatch");
        exit();
    }

    // If username exists
    if (uidExists($conn,$username,$email) !== false) {
        header("location: ../signup.php?error=usernametaken");
        exit();
    }

    createUser($conn, $name,$email,$username,$pwd);


}else{
    header("location: ../signup.php");
    exit();
}