<?php

include_once '../header.php';
include_once 'functions.inc.php';
require_once 'dbh.inc.php';

if(isset($_POST["new-pwd"]) && isset($_SESSION["username"])){
    $newpwd = $_POST["new-pwd"];
    $confirm = $_POST["confirm-pwd"];
    if($newpwd!==$confirm){
        header("location: ../../Reset_password.php?error=NO_MATCH");
        exit();
    }
    $ehandle = "?error=";
    $errorsPWD = "";
    if($newpwd ==='0000'){
        $ehandle = "?error=PASS_TOO_WEAK";
        $errorsPWD .= "&d=true";
    }
    if(strlen($newpwd)<8){
        $ehandle = "?error=PASS_TOO_WEAK";
        $errorsPWD .= "&l=true";
    }
    if ($ehandle!=="?error=") {
        header("location: ../../Reset_Password.php".$ehandle.$errorsPWD);
        exit();
    }
    $state = UpdatePassword($conn, $newpwd);
    if ($state!==0) {
        header("location: ../../Reset_password.php?error=PASS_NOT_UPDATED");
        exit();
    }
    
    header("location: ../../index.php?reset=success");
    exit();
}else{
    header("location: logout.inc.php");
    exit();
}

