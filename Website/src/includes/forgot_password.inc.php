<?php

include_once '../header.php';
include_once 'functions.inc.php';
require_once 'dbh.inc.php';

if(isset($_POST["uid"])){
    if(empty($_POST["uid"])){
        header("location: ../../Forgot_password.php?status=FILL");
        exit();
    }
    $userdata = getUserDetails($conn, $_POST["uid"], $_POST["uid"]);//email username password
    if($userdata==false){
        header("location: ../../Email_sent.php?status=USER_NOT_FOUND");
        exit();
    }

    $link = "LINK";

    $header = "MIME-Version: 1.0" . "\r\n";
    $header .= "Content-type:text/html;charset=UTF-8" . "\r\n";
    $header = "From: fahdseddik@gmail.com \r\n";
    $header .= "Cc: fahdseddik@gmail.com \r\n";
    //$header .= "MIME-Version: 1.0\r\n";
    if (mail('fahdseddik@gmail.com', 'Password Reset', 'Please click on the following link to reset your password: ' . $link, $header)) {
        header("location: ../../Email_Sent.php?status=done");
        exit();
    }else{
        header("location: ../../Forgot_password.php?status=FILL");
        exit();
    }
}else{
    header("location: logout.inc.php");
    exit();
}

