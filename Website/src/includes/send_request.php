<?php

include_once '../header.php';
require_once 'dbh.inc.php';
require_once 'functions.inc.php';
if (isset($_POST["new-reply"])) {
    if(!isset($_POST["state"]) || $_POST["state"]==""){
        header("location: ../Reply_Request.php?state=FORM_NOT_FILLED");
        exit();
    }
    $requesttext = $_POST["request-text"];
    $sendto = $_POST["send-to"];
    $title = $_POST["title"];
    if(!isset($_POST["state"])){
        header("location: ../Reply_Request.php?state=FORM_NOT_FILLED");
        exit();
    }
    $params_original = array($_POST["state"],$_SESSION["reqID"]);
    $params_replier = array($_SESSION["SSN"], $sendto, $title, $requesttext,$_POST["state"]);
    $stat = UpdateRequestStatus($conn, $params_original, $params_replier);
    unset($_SESSION["sender"]);
    unset($_SESSION["reqID"]);
    if($stat!==0){
        header("location: ../Contact.php?reply=NOT_SENT".$stat);
        exit();
    }
    header("location: ../Contact.php?reply=success");
    exit();
}else
if (isset($_POST["new-request"])) {
    $requesttext = $_POST["request-text"];
    $sendto = $_POST["send-to"];
    $title = $_POST["title"];
    if(empty($requesttext) || empty($sendto) || empty($title)){
        header("location: ../Contact.php?error=EMPTY_FIELDS");
        exit();
    }
    
    if(sendRequest($conn, array($_SESSION["SSN"], $sendto, $title, $requesttext))){
        header("location: ../Contact.php?state=success");
        exit();
    }
    header("location: ../Contact.php?error=NOT_SENT");
    exit();
}
else{
    if (isset($_SESSION["sender"])) {
        unset($_SESSION["sender"]);
        unset($_SESSION["reqID"]);
    }
    header("location: ../Contact.php?error=FORM_NOT_SUBMITTED");
    exit();
}